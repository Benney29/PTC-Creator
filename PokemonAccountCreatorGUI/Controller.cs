using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using PokemonAccountCreatorGUI.Classes;
using System.Threading.Tasks;
using System.Net.Http;

namespace PokemonAccountCreatorGUI
{
    class Controller
    {
        public static List<Thread> threadList = new List<Thread>();
        private DateTime updateProxy = new DateTime(1999, 1, 1);
        private DateTime lastTimeAddedPool = DateTime.Now.AddMinutes(1);
        private List<Creator> creatorObjList = new List<Creator>();
        private Regex proxyRe = new Regex(@"\d+.\d+.\d+.\d+:\d+");

        public void main()
        {
            decimal d;
            StaticVars.title = new consoleTitle();
            if (StaticVars.existProxy.Count < 1)
            {
                GetFileProxy().Wait();
                GetWebProxy().Wait();
                foreach (HttpClientItem item in StaticVars.httpClientPool)
                {
                    StaticVars.UsableClientPool.Enqueue(item);
                }
            }

            //Create threads according to user selected value
            for (var i = 0; i < StaticVars.threadA && i < StaticVars.UsableClientPool.Count; i++)
            {
                Thread temp = new Thread(new Creator(StaticVars.UsableClientPool.Dequeue()).Main);
                temp.IsBackground = true;
                temp.Name = i.ToString();
                temp.SetApartmentState(ApartmentState.STA);
                threadList.Add(temp);
                temp.Start();
                Debug.WriteLine(i.ToString());
            }
            Thread.Sleep(2000);

            //Check whether there are useful proxies
            Thread httpItemCheck = new Thread(CheckProxyPool);
            httpItemCheck.Name = "Check Proxy Pool";
            httpItemCheck.Start();

            while (true)
            {                
                if (StaticVars.stop)
                {
                    lock (StaticVars.LogText)
                    {
                        MainWindow.main.StartButtonText = "Hold on... Stopping";
                        StaticVars.LogText += DateTime.Now + " : Stopped" + Environment.NewLine + StaticVars.stopReason;
                    }
                    break;
                }

                for (int i = 0; i < threadList.Count && i < StaticVars.threadA; i++)
                {
                    if (StaticVars.stop)
                    {
                        break;
                    }
                    else if (!threadList[i].IsAlive)
                    {
                        addAgain:
                        if (StaticVars.UsableClientPool.Count > 0)
                        {
                            Thread temp = new Thread(new Creator(StaticVars.UsableClientPool.Dequeue()).Main);
                            temp.IsBackground = true;
                            temp.Name = i.ToString();
                            temp.SetApartmentState(ApartmentState.STA);
                            threadList[i] = temp;
                            temp.Start();
                            Debug.WriteLine(i.ToString() + " Reset");
                        }
                        else
                        {
                            Thread.Sleep(15000);
                            //Update UI content
                            MainWindow.main.SuccessLabelText = StaticVars.title.success.ToString();
                            MainWindow.main.FailLabelText = StaticVars.title.fail.ToString();
                            MainWindow.main.TotalLabelText = (StaticVars.title.success + StaticVars.title.fail).ToString();
                            try
                            {
                                d = (decimal)StaticVars.title.success / (StaticVars.title.success + StaticVars.title.fail);
                                MainWindow.main.RateLabelText = String.Format("{0:P2}", d);
                            }
                            catch { }
                            MainWindow.main.LogText = StaticVars.LogText;
                            goto addAgain;
                        }
                    }
                }

                //Speed up
                int count = threadList.Count;
                while (count < StaticVars.threadA && count < StaticVars.httpClientPool.Count)
                {
                    if (StaticVars.UsableClientPool.Count > 0)
                    {
                        Thread temp = new Thread(new Creator(StaticVars.UsableClientPool.Dequeue()).Main);
                        temp.IsBackground = true;
                        temp.Name = count.ToString();
                        temp.SetApartmentState(ApartmentState.STA);
                        threadList.Add(temp);
                        temp.Start();
                        Debug.WriteLine(count.ToString() + " Added");
                        count += 1;
                    }
                    else
                    {
                        Thread.Sleep(15000);
                    }
                }

                if (DateTime.Now.Subtract(updateProxy).TotalMinutes > 15)
                {
                    GetWebProxy().Wait();
                }

                //Update UI content
                MainWindow.main.SuccessLabelText = StaticVars.title.success.ToString();
                MainWindow.main.FailLabelText = StaticVars.title.fail.ToString();
                MainWindow.main.TotalLabelText = (StaticVars.title.success + StaticVars.title.fail).ToString();
                try
                {
                    d = (decimal)StaticVars.title.success / (StaticVars.title.success + StaticVars.title.fail);
                    MainWindow.main.RateLabelText = String.Format("{0:P2}", d);
                }
                catch { }
                MainWindow.main.LogText = StaticVars.LogText;
                GC.Collect();
                GC.WaitForPendingFinalizers();

                Thread.Sleep(10000);
            }

            while (true)
            {
                bool check = true;
                foreach (Thread t in threadList)
                {
                    check = check && !t.IsAlive;
                }
                if (check)
                {
                    break;
                }
                MainWindow.main.SuccessLabelText = StaticVars.title.success.ToString();
                MainWindow.main.FailLabelText = StaticVars.title.fail.ToString();
                MainWindow.main.TotalLabelText = (StaticVars.title.success + StaticVars.title.fail).ToString();
                try
                {
                    d = (decimal)StaticVars.title.success / (StaticVars.title.success + StaticVars.title.fail);
                    MainWindow.main.RateLabelText = String.Format("{0:P2}", d);
                }
                catch { }
                MainWindow.main.LogText = StaticVars.LogText;
                Thread.Sleep(2000);
            }

            MainWindow.main.StartButtonText = "Start";
        }

        private Task GetFileProxy()
        {
            Regex proxyFileRe = new Regex(@"\d+.\d+.\d+.\d+:\d+:\d+:\d+");
            if (StaticVars.fileProxy != "" && StaticVars.fileProxy != null && File.Exists(StaticVars.fileProxy))
            {
                string[] proxyList = null;
                proxyList = File.ReadAllLines(StaticVars.fileProxy);
                try
                {
                    foreach (string s in proxyList)
                    {
                        Match proxyReMatch = proxyFileRe.Match(s);
                        string[] proxies = proxyReMatch.Value.Split(':');
                        StaticVars.existProxy.Add(proxyReMatch.Value);
                        for (int i = 0; i < int.Parse(proxies[2]); i++)
                        {
                            StaticVars.httpClientPool.Add(new HttpClientItem(proxies[0] + ":" + proxies[1], int.Parse(proxies[3])));
                        }
                    }
                    StaticVars.LogText += "Loaded File Proxies" + DateTime.Now + Environment.NewLine;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return Task.FromResult(0);
        }

        private Task GetWebProxy()
        {
            if (StaticVars.proxyAPI != "" && StaticVars.proxyAPI != null)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.Timeout = new TimeSpan(0, 30, 0);
                        string proxyStringList = client.GetAsync(StaticVars.proxyAPI).Result.Content.ReadAsStringAsync().Result;
                        if (proxyStringList.Contains("Error") || proxyStringList.Contains("Denied") || proxyStringList.Contains("bad"))
                        {
                            return Task.FromResult(0);
                        }
                        MatchCollection proxyReMatchCollection = proxyRe.Matches(proxyStringList);

                        foreach (Match m in proxyReMatchCollection)
                        {
                            if (m.Success && !StaticVars.existProxy.Contains(m.Value))
                            {
                                StaticVars.existProxy.Add(m.Value);
                                StaticVars.httpClientPool.Add(new HttpClientItem(m.Value, 900));
                            }
                        }
                        StaticVars.LogText += "Loaded Web Proxies" + DateTime.Now + Environment.NewLine;
                        updateProxy = DateTime.Now;
                    }                    

                }
                catch (Exception e)
                {
                    StaticVars.LogText += DateTime.Now + ": Failed to get web proxies";
                }
            }
            return Task.FromResult(0);
        }
        
        private void CheckProxyPool()
        {
            while (true)
            {
                StaticVars.LogText = "";
                List<HttpClientItem> modified_pool = StaticVars.httpClientPool;
                List<string> modified_existing_proxies = StaticVars.existProxy;
                lock (StaticVars.UsableClientPool)
                {
                    if (StaticVars.UsableClientPool.Count == 0)
                    {
                        for (int i = 0; i < StaticVars.httpClientPool.Count; i++)
                        {
                            if (StaticVars.httpClientPool[i].failCount >= 10)
                            {
                                modified_pool.RemoveAt(i);
                                modified_existing_proxies.Remove(StaticVars.httpClientPool[i].proxy);
                            }
                        }
                        StaticVars.httpClientPool = modified_pool;
                        StaticVars.existProxy = modified_existing_proxies;

                        foreach (HttpClientItem item in StaticVars.httpClientPool)
                        {
                            if (item.failCount < 10 && DateTime.Now.Subtract(item.lastUseTime).TotalSeconds > item.delaySec  && !item.inUse)
                            {
                                StaticVars.UsableClientPool.Enqueue(item);
                            }
                        }
                        lastTimeAddedPool = DateTime.Now;
                        StaticVars.LogText += DateTime.Now + ": Reset Proxy Pool";
                        StaticVars.LogText += DateTime.Now + ": " + StaticVars.UsableClientPool.Count + " proxies in queue" + Environment.NewLine;
                    }
                    else
                    {
                        StaticVars.LogText += DateTime.Now + ": " + StaticVars.UsableClientPool.Count + " proxies in queue" + Environment.NewLine;
                    }
                    Thread.Sleep(30000);
                }
            }
        }
        

    }
}
