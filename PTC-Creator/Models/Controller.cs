using RandomNameGeneratorLibrary;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PTC_Creator.Models
{
    internal class Controller
    {
        const string PASSWORD_CHARS_LCASE = "abcdefgijkmnopqrstwxyz";
        const string PASSWORD_CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";
        const string PASSWORD_CHARS_NUMERIC = "23456789";
        const string PASSWORD_CHARS_SPECIAL = "*$-+?_&=!%{}/";

        List<Thread> threadList = new List<Thread>();
        ConcurrentBag<HttpClient> worker = new ConcurrentBag<HttpClient>();
        Object lockObj = new object();
        Thread webProxyThread;

        public void Start()
        {
            GlobalSettings.worker_stop = false;
            
            GlobalSettings.creationStatus.Clear();
            GlobalSettings.workers.Clear();

            Initiate_accounts(GlobalSettings.creatorSettings.createAmount);

            if (GlobalSettings.webProxy.Count > 0)
            {
                webProxyThread = new Thread(WebProxyThread);
                webProxyThread.Start();
            }

            Initiate_worker();

            StartWorkers();

            GlobalSettings.worker_stop = true;

            try
            {
                webProxyThread.Abort();
            }
            catch { }
        }

        private void StartWorkers()
        {
            while (GlobalSettings.creationStatus.ToList().Count(_ => _.status == CreationStatus.Created) < GlobalSettings.creatorSettings.createAmount)
            {
                foreach (StatusModel _ in GlobalSettings.creationStatus.ToList())
                {
                    if (GlobalSettings.worker_stop)
                    {
                        return;
                    }
                    if (_.status != CreationStatus.Waiting)
                    {
                        continue;
                    }

                    CheckPending();

                    while (threadList.Count > GlobalSettings.creatorSettings.threadAmount)
                    {
                        Thread.Sleep(5000);
                        threadList = threadList.Where(__ => __.IsAlive).ToList();
                    }

                    WorkerModel worker = null;
                    while (worker == null)
                    {
                        lock (lockObj)
                        {
                            worker = GlobalSettings.workers.FirstOrDefault(__ => __.IsUsable());
                        }
                        if (worker != null)
                        {
                            worker.inUse = true;
                        }
                        else
                        {
                            Thread.Sleep(10000);
                        }
                    }
                    _.ChangeStatus(CreationStatus.Processing);
                    Thread t = new Thread(new Creator(worker, _).Start);
                    t.Start();
                    threadList.Add(t);
                    Thread.Sleep(200);
                }

                threadList.ForEach(_ => _.Join());

                //Check failed count and add new slots
                Initiate_accounts(GlobalSettings.creatorSettings.createAmount - GlobalSettings.creationStatus.Count(_ => _.status == CreationStatus.Failed));
            }
        }

        private void CheckPending()
        {
            StatusModel pending;
            while (GlobalSettings.creationPendingList.TryTake(out pending))
            {
                if (GlobalSettings.worker_stop)
                {
                    return;
                }
                WorkerModel worker = null;
                //found pending account
                while (threadList.Count > GlobalSettings.creatorSettings.threadAmount)
                {
                    Thread.Sleep(5000);
                    threadList = threadList.Where(__ => __.IsAlive).ToList();
                }

                while (worker == null)
                {
                    lock (lockObj)
                    {
                        worker = GlobalSettings.workers.FirstOrDefault(__ => __.IsUsable());
                    }
                    if (worker != null)
                    {
                        worker.inUse = true;
                    }
                    else
                    {
                        Thread.Sleep(10000);
                    }
                }

                pending.ChangeStatus(CreationStatus.Processing);
                Thread t = new Thread(new PendingChecker(worker, pending).Check);
                t.Start();
                threadList.Add(t);
            }
        }

        #region account

        public void Initiate_accounts(int amount)
        {
            List<Task> threadList = new List<Task>();
            Random random = new Random();
            PersonNameGenerator nameGenObj = new PersonNameGenerator();
            for (int i = GlobalSettings.creationStatus.Count(_ => _.status == CreationStatus.Waiting); i < amount; i++)
            {
                GetRandomAccount(random, nameGenObj);
            }
            GlobalSettings.createForm.UpdateStatus();
        }

        private void GetRandomAccount(Random random, PersonNameGenerator nameGenObj)
        {
            string username = GetUsername(random, nameGenObj);
            string password = GetPassword(random);
            string dob = GetDob(random).ToString("yyyy-MM-dd");
            StatusModel _ = new StatusModel();
            _.username = username;
            _.password = password;
            _.dob = dob;
            _.email = username + "@" + GlobalSettings.creatorSettings.domain;
            _.status = CreationStatus.Waiting;
            GlobalSettings.creationStatus.Add(_);
        }

        private string GetUsername(Random random, PersonNameGenerator nameGenObj)
        {
            int maxLength = 14;
            nameGenObj.GenerateRandomFirstName().Replace(" ", "");
            string name = GlobalSettings.creatorSettings.username == "" ?
                nameGenObj.GenerateRandomFirstName().Replace(" ", "") : GlobalSettings.creatorSettings.username;

            var charSwitch = name.Select(x => random.Next() % 2 == 0 ? (char.IsUpper(x) ? x.ToString().ToLower().First() : x.ToString().ToUpper().First()) : x);
            name = new String(charSwitch.ToArray()).Replace("l", "L").Replace("I", "i").Replace("O", "o").Replace("0", "1");//Try to avoid confused words
            if (name.Length > 14) return name.Substring(0, 14);
            string randomNumber = new string(Enumerable.Repeat(PASSWORD_CHARS_NUMERIC, maxLength - name.Length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return name + randomNumber;
        }

        private string GetPassword(Random random)
        {
            if (GlobalSettings.creatorSettings.password != "")
            {
                return GlobalSettings.creatorSettings.password;
            }
            string pass;
            pass = new string(Enumerable.Repeat(PASSWORD_CHARS_LCASE, 3)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            pass += new string(Enumerable.Repeat(PASSWORD_CHARS_UCASE, 3)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            pass += new string(Enumerable.Repeat(PASSWORD_CHARS_NUMERIC, 3)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            pass += new string(Enumerable.Repeat(PASSWORD_CHARS_SPECIAL, 3)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return pass;
        }

        private DateTime GetDob(Random random)
        {
            DateTime start = new DateTime(1986, 1, 1);
            int range = (DateTime.Parse("1995-1-1") - start).Days;
            return start.AddDays(random.Next(range));
        }

        #endregion

        #region proxy
        private void Initiate_worker()
        {
            GlobalSettings.proxyList.Where(_ => _.usable).ToList().ForEach(_ =>
            {                
                for (int i = 0; i < _.thread_amount; i++)
                {
                    CookieContainer cookieJar = new CookieContainer();
                    if (_.type == ProxyType.HTTP)
                    {
                        HttpClientHandler handler = new HttpClientHandler
                        {
                            UseCookies = true,
                            CookieContainer = cookieJar,
                            UseProxy = true,
                            Proxy = new WebProxy(_.proxy, false)
                            {
                                UseDefaultCredentials = false,
                                Credentials = new NetworkCredential(_.username, _.password)
                            }
                        };
                        GlobalSettings.workers.Add(new WorkerModel(new HttpClient(handler), _, cookieJar));
                    }                  
                }
            });
        }

        private void WebProxyThread()
        {
            while (!GlobalSettings.worker_stop)
            {
                using (HttpClient client = new HttpClient())
                {
                    foreach (WebProxyItem _ in GlobalSettings.webProxy)
                    {
                        string content = client.GetStringAsync(_.url).Result;

                        List<Proxy> proxyList = GlobalSettings.webProxyForm.GetProxies(content, true);

                        lock (lockObj)
                        {
                            foreach(Proxy p in proxyList)
                            {
                                CookieContainer cookieJar = new CookieContainer();
                                if (_.type == ProxyType.HTTP)
                                {
                                    HttpClientHandler handler = new HttpClientHandler
                                    {
                                        UseCookies = true,
                                        CookieContainer = cookieJar,
                                        UseProxy = true,
                                        Proxy = new WebProxy(p.proxy)
                                    };
                                    GlobalSettings.workers.Add(new WorkerModel(new HttpClient(handler), p, cookieJar));
                                }
                            }
                        }
                        _.AddAmount(proxyList.Count());
                        _.last_check_date = DateTime.Now;
                    }
                }
                Thread.Sleep(900000);
            }
        }
        #endregion
    }
}
