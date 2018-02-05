using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;

namespace PokemonAccountCreatorGUI
{
    class Verification
    {
        public string path = "";
        public static Queue<string> accountsQueue = new Queue<string>();
        private static int verified = 0;
        private static int unverified = 0;
        public Verification(string p)
        {
            path = p;
        }

        public void doWork()
        {
            GetAccountQueue();
            if (accountsQueue.Count > 0)
            {
                //Create thread list 
                List<Thread> tList = new List<Thread>();
                for (int i = 0; i < 5; i++)
                {
                    Thread t = new Thread(verify);
                    t.Name = "Verify - " + (i + 1).ToString();
                    tList.Add(t);
                    t.Start();
                }
                bool check = true;
                // check all threads are stopped and there is no accounts left in Queue
                while (true)
                {
                    check = true;
                    for (int i = 0; i < tList.Count; i++)
                    {
                        if (accountsQueue.Count > 0 && !tList[i].IsAlive && !StaticVars.stop)
                        {
                            Thread t = new Thread(verify);
                            t.Name = "Verify - " + (i + 1).ToString();
                            tList[i] = t;
                            t.Start();
                        }
                        check = check && !tList[i].IsAlive;
                    }
                    if (check)
                    {
                        break;
                    }
                    Thread.Sleep(2000);
                }
            }
            //Reset button
            MainWindow.main.VerifyButtonText = "Select File";
        }

        //Read all lines from file which contains account per line
        private void GetAccountQueue()
        {
            string[] readText = File.ReadAllLines(path);
            foreach (string s in readText)
            {
                if (s != "" && s != null)
                {
                    accountsQueue.Enqueue(s);
                }
            }
        }

        //Verification process
        private void verify()
        {
            while (accountsQueue.Count > 0 && !StaticVars.stop)
            {
                string account = "";
                lock (accountsQueue)
                {
                    if (accountsQueue.Count > 0)
                    {
                        account = accountsQueue.Dequeue();
                    }
                }
                if (account != "")
                {
                    using (HttpClient client = GetLoginHttpClient())
                    {
                        //Get username and password
                        string username = account.Split(':')[0].ToString();
                        string password = account.Split(':')[1].ToString();
                        try
                        {
                            //Get lt, excution, eventID from webpage which needed to login
                            string pageSource = client.GetAsync("/sso/login?locale=en&service=https://club.pokemon.com/us/pokemon-trainer-club/caslogin").Result.Content.ReadAsStringAsync().Result.Replace("\r\n", "").Replace("\t", "").Replace("\"", "").Replace("\n", "");
                            string ltToken = GetltToken(pageSource);
                            string execution = GetExcution(pageSource);
                            string eventId = GetEventID(pageSource);
                            pageSource = client.PostAsync("/sso/login?locale=en&service=https://club.pokemon.com/us/pokemon-trainer-club/caslogin", GetLoginContent(ltToken, execution, eventId, username, password)).Result.Content.ReadAsStringAsync().Result.Replace("\r\n", "").Replace("\t", "").Replace("\"", "").Replace("\n", "");
                            if (pageSource.Contains("Now you can customize your Trainer"))//This means verified
                            {
                                lock (StaticVars.VerifiedLogText)
                                {
                                    Debug.WriteLine(username + " Verified");
                                    StaticVars.VerifiedLogText += account + Environment.NewLine;
                                    verified += 1;
                                    MainWindow.main.VerifiedLogText = StaticVars.VerifiedLogText;
                                    MainWindow.main.VerifyGroupBoxText = "Verified: " + verified.ToString();
                                    WriteToFile(account, true);
                                }
                            }
                            else if (pageSource.Contains("The request could not be satisfied"))// Too much request in period of time, wait for 1 min and try again.
                            {
                                lock (accountsQueue)
                                {
                                    Debug.WriteLine("Too much requests");
                                    accountsQueue.Enqueue(account);
                                    Thread.Sleep(60000);
                                }
                            }
                            else// Not verified
                            {
                                lock (StaticVars.UnverifiedLogText)
                                {
                                    Debug.WriteLine(username + " Unverified");
                                    StaticVars.UnverifiedLogText += account + Environment.NewLine;
                                    unverified += 1;
                                    MainWindow.main.UnverifiedLogText = StaticVars.UnverifiedLogText;
                                    MainWindow.main.UnverifyGroupBoxText = "Unverified: " + unverified.ToString();
                                    WriteToFile(account, false);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
                            break;
                        }
                    }
                }
            }
        }

        private string GetltToken(string pageSource)
        {
            Regex re = new Regex(@"lt value=\w+-\w+-\w+");
            return re.Match(pageSource).Value.Replace("lt value=", "");
        }

        private string GetExcution(string pageSource)
        {
            Regex re = new Regex(@"execution value=\w+");
            return re.Match(pageSource).Value.Replace("execution value=", "");
        }

        private string GetEventID(string pageSource)
        {
            Regex re = new Regex(@"_eventId value=\w+");
            return re.Match(pageSource).Value.Replace("_eventId value=", "");
        }

        private FormUrlEncodedContent GetLoginContent(string lt, string execution, string eventID, string username, string password)
        {
            FormUrlEncodedContent ret = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("lt", lt),
                new KeyValuePair<string, string>("execution", execution),
                new KeyValuePair<string, string>("_eventId", eventID),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("Login", "Sign In"),
            });
            return ret;

        }

        //Set headers and stuff
        private HttpClient GetLoginHttpClient()
        {
            CookieContainer cookieJar = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler() { CookieContainer = cookieJar, UseCookies = true };
            handler.AllowAutoRedirect = true;
            HttpClient client = new HttpClient(handler) { BaseAddress = new Uri("https://sso.pokemon.com/") };
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
            client.DefaultRequestHeaders.Add("Origin", "https://sso.pokemon.com");
            client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            client.DefaultRequestHeaders.Add("Referer", ":https://sso.pokemon.com/sso/login?locale=en&service=https://club.pokemon.com/us/pokemon-trainer-club/caslogin");
            client.DefaultRequestHeaders.Add("DNT", "1");
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
            client.Timeout = new TimeSpan(0, 0, 30);
            return client;
        }

        //Output to different files.
        private void WriteToFile(string account, bool verified)
        {
            string path = Directory.GetCurrentDirectory();
            if (verified)
            {
                path += @"\verified.txt";
            }
            else
            {
                path += @"\unverified.txt";
            }
            if (!File.Exists(path))
            {
                StreamWriter sw = File.CreateText(path);
                sw.Close();
            }
            while (true)
            {
                try
                {
                    File.AppendAllText(path, account + Environment.NewLine);
                    break;
                }
                catch { Thread.Sleep(1000); }
            }
        }
    }
}
