using RandomNameGeneratorLibrary;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
        ConcurrentBag<HttpClient> worker = new ConcurrentBag<HttpClient>();
        Object lockObj = new object();

        public void Start()
        {
            Initiate_accounts(GlobalSettings.creatorSettings.createAmount);

            if (GlobalSettings.webProxy.Count > 0)
            {
                new Thread(WebProxyThread).Start();
            }

            Initiate_worker();

            StartWorkers();
        }

        private void StartWorkers()
        {
            List<Task> taskList = new List<Task>();

            while (GlobalSettings.creationStatus.Count(_ => _.status == CreationStatus.Created) < GlobalSettings.creatorSettings.createAmount)
            {
                foreach (StatusModel _ in GlobalSettings.creationStatus)
                {
                    if (_.status != CreationStatus.Waiting)
                    {
                        continue;
                    }

                    while (taskList.Count > GlobalSettings.creatorSettings.threadAmount)
                    {
                        Thread.Sleep(5000);
                        taskList = taskList.Where(__ => __.Status == TaskStatus.Running).ToList();
                    }

                    WorkerModel worker = null;
                    while (worker == null)
                    {
                        lock (lockObj)
                        {
                            worker = GlobalSettings.workers.FirstOrDefault(__ => __.IsUsable());
                            if (worker != null)
                            {
                                worker.inUse = true;
                            }
                        }
                        if (worker == null)
                        {
                            Thread.Sleep(10000);
                        }
                    }
                    _.ChangeStatus(CreationStatus.Processing);
                    Task t = Task.Run(() => new Creator(worker, _).Start());
                    taskList.Add(t);
                }

                Task.WaitAll(taskList.ToArray());

                //Check failed count and add new slots
                Initiate_accounts(GlobalSettings.creatorSettings.createAmount - GlobalSettings.creationStatus.Count(_ => _.status == CreationStatus.Failed));
            }

        }

        #region account

        public void Initiate_accounts(int amount)
        {
            List<Task> taskList = new List<Task>();
            Random random = new Random();
            PersonNameGenerator nameGenObj = new PersonNameGenerator();
            for (int i = 0; i < amount; i++)
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
            GlobalSettings.creatorSettings.username = "";
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
                        GlobalSettings.workers.Add(new WorkerModel(new HttpClient(handler), _));
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

                        lock (lockObj)
                        {
                            GlobalSettings.webProxyForm.GetProxies(content, true);
                        }
                    }
                }
                Thread.Sleep(900000);
            }
        }
        #endregion
    }
}
