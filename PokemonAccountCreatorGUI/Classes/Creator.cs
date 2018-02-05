using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Net.Http;
using System.Net;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;
using PokemonAccountCreatorGUI.Classes;
using Newtonsoft.Json;

namespace PokemonAccountCreatorGUI
{
    class Creator
    {
        HttpClientItem client;
        private bool proxyDead = false;

        UserInputModel m;

        public Creator(HttpClientItem c)
        {
            lock (c)
            {
                c.inUse = true;
                client = c;
            }
        }

        public void Main()
        {
            if (StaticVars.stop)
            {
                Thread.CurrentThread.Abort();
            }

            int count = 0;
            while (count < 5)
            {
                if (StaticVars.stop)
                {
                    threadAbort();
                }
                lock (StaticVars.random)
                {
                    m = GetRandom();
                }
                while (!CheckUsername(client.client))
                {
                    if (proxyDead)
                    {
                        threadAbort();
                    }
                    m = GetRandom();
                }
                if (doWork(client))
                {
                    client.failCount = 0;
                    writeToFile();
                    count += 1;
                    client.ClearCookie();
                }
                else
                {
                    threadAbort();
                }
            }
            threadAbort();
        }

        private bool doWork(HttpClientItem client)
        {
            // check which captcha service to use
            try
            {
                string pageSource = "";
                // start registration
                pageSource = client.GetAsync("/us/pokemon-trainer-club/sign-up").Result;

                //Get csrf token
                Regex re = new Regex(@"csrfmiddlewaretoken' value='\w+");
                string csrf = re.Match(pageSource).Value.Replace("csrfmiddlewaretoken' value='", "");
                if (csrf != "")
                {
                    pageSource = client.PostAsync("/us/pokemon-trainer-club/sign-up/", getAgeVerify(csrf)).Result;
                    int count = 0;
                    while (true)
                    {
                        //Check page passed age verification
                        if (!pageSource.Contains("With a Pokémon Trainer Club account, you can:"))
                        {
                            break;
                        }
                        count += 1;
                        if (count > 10) //Check for 10 times, if none works, proxy dead
                        {
                            StaticVars.LogText += DateTime.Now.ToString() + ": Proxy " + client.proxy + " failed to view club.pokemon.com website" + Environment.NewLine;
                            client.failCount += 1;
                            return false;
                        }
                        Thread.Sleep(1000);
                        pageSource = client.PostAsync("/us/pokemon-trainer-club/sign-up/", getAgeVerify(csrf)).Result;
                    }
                    if (StaticVars.stop)
                    {
                        return false;
                    }
                    //get new captcha

                    CaptchaReturn captcha = GetCaptcha();
                    //Post registration to server
                    FormUrlEncodedContent createForm = AccountContent(csrf, captcha.captcha_response);
                    pageSource = client.PostAsync("/us/pokemon-trainer-club/parents/sign-up", createForm).Result;
                    //Check registration successful or not
                    if (pageSource.Contains("Hello! Thank you for creating an account!"))
                    {
                        return true;
                    }
                    else if (pageSource.Contains("Verify Age"))
                    {
                        client.failCount += 1;
                        StaticVars.LogText += DateTime.Now.ToString() + ": " + m.Username + " failed while using proxy " + client.proxy + Environment.NewLine;
                    }
                    else if (pageSource.Contains("There is a problem with your email address.") || pageSource.Contains("Unexpected Error"))
                    {
                        StaticVars.LogText += DateTime.Now.ToString() + ": " + m.Username + " failed with unexpected error from Niantic website" + Environment.NewLine;
                    }
                    else if (pageSource.Contains("Access Denied"))
                    {
                        client.failCount += 1;
                        StaticVars.LogText += DateTime.Now.ToString() + ": " + m.Username + " failed with access denied from Niantic website" + Environment.NewLine;
                    }
                    else
                    {
                        /*
                        if (StaticVars.addToDB)
                        {
                            WriteErrorMessage(pageSource);
                        }*/
                        //PostBadCaptcha(captcha.server_index, captcha.captcha_id);
                        client.failCount += 1;
                    }
                    StaticVars.title.fail += 1;
                }
                else
                {
                    Debug.WriteLine(Thread.CurrentThread.Name + " No csrf Token");
                    client.failCount += 1;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                client.failCount += 1;
            }
            return false;
        }


        //Get random user info
        private UserInputModel GetRandom()
        {
            UserInputModel m = new UserInputModel();
            m.Username = generateUsername();
            m.Password = RandomPassword();
            m.Email = m.Username + "@" + StaticVars.domain;
            m.Dob = RandomDate().ToString("yyyy-MM-dd");
            return m;
        }

        private DateTime RandomDate()
        {
            DateTime start = new DateTime(1986, 1, 1);
            int range = (DateTime.Parse("1995-1-1") - start).Days;
            return start.AddDays(StaticVars.random.Next(range));
        }


        private string RandomPassword()
        {
            if (StaticVars.password != "")
            {
                return StaticVars.password;
            }
            string PASSWORD_CHARS_LCASE = "abcdefgijkmnopqrstwxyz";
            string PASSWORD_CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";
            string PASSWORD_CHARS_NUMERIC = "23456789";
            string PASSWORD_CHARS_SPECIAL = "*$-+?_&=!%{}/";
            string pass;
            pass = new string(Enumerable.Repeat(PASSWORD_CHARS_LCASE, 3)
              .Select(s => s[StaticVars.random.Next(s.Length)]).ToArray());
            pass += new string(Enumerable.Repeat(PASSWORD_CHARS_UCASE, 3)
              .Select(s => s[StaticVars.random.Next(s.Length)]).ToArray());
            pass += new string(Enumerable.Repeat(PASSWORD_CHARS_NUMERIC, 3)
              .Select(s => s[StaticVars.random.Next(s.Length)]).ToArray());
            pass += new string(Enumerable.Repeat(PASSWORD_CHARS_SPECIAL, 3)
              .Select(s => s[StaticVars.random.Next(s.Length)]).ToArray());
            return pass;
        }

        private string generateUsername()
        {
            int maxLength = 14;
            string name = "";
            if (StaticVars.usernamePrefix != "")
            {
                name = StaticVars.usernamePrefix;
            }
            if (name.Length < 1)
            {
                while (true)
                {
                    name += StaticVars.nameGenObj.GenerateRandomFirstName().Replace(" ", "");
                    if (name.Length < maxLength)
                    {
                        break;
                    }
                };
            }
            var charSwitch = name.Select(x => StaticVars.random.Next() % 2 == 0 ? (char.IsUpper(x) ? x.ToString().ToLower().First() : x.ToString().ToUpper().First()) : x);
            name = new String(charSwitch.ToArray()).Replace("l", "L").Replace("I", "i").Replace("O", "o").Replace("0", "1");//Try to avoid confused words
            if (name.Length > 13)
            {
                return name;
            }
            const string chars = "0123456789";
            string randomNumber = new string(Enumerable.Repeat(chars, maxLength - name.Length)
              .Select(s => s[StaticVars.random.Next(s.Length)]).ToArray());
            return name + randomNumber;
        }

        //Check username
        private bool CheckUsername(HttpClient client)
        {
            var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("name", m.Username)
                });
            while (true)
            {
                try
                {
                    using (HttpResponseMessage res = client.PostAsync("https://club.pokemon.com/api/signup/verify-username", formContent).Result)
                    {
                        string check = res.Content.ReadAsStringAsync().Result;
                        if (res.StatusCode == HttpStatusCode.Forbidden || res.StatusCode == HttpStatusCode.ServiceUnavailable ||
                            check.Contains("Request was throttled") || check.Contains("forbidden") || check.Contains("request could not be"))
                        {
                            proxyDead = true;
                            return false;
                        }
                        return check.Contains("true");
                    }
                }
                catch (Exception e)
                { Debug.WriteLine(e.Message); proxyDead = true; return false; }
            }
        }

        //Return age verify formcontent
        private FormUrlEncodedContent getAgeVerify(string token)
        {
            FormUrlEncodedContent ret = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("csrfmiddlewaretoken", token),
                new KeyValuePair<string, string>("picker__year", m.Dob.Split('-')[0].ToString()),
                new KeyValuePair<string, string>("picker__month", (int.Parse(m.Dob.Split('-')[1].ToString()) - 1).ToString()),
                new KeyValuePair<string, string>("dob", m.Dob),
                new KeyValuePair<string, string>("country", "US")
            });
            return ret;
        }

        //Return registration formcontent
        private FormUrlEncodedContent AccountContent(string token, string captcha)
        {
            List<KeyValuePair<string, string>> pair = new List<KeyValuePair<string, string>>();
            pair.Add(new KeyValuePair<string, string>("csrfmiddlewaretoken", token));
            pair.Add(new KeyValuePair<string, string>("username", m.Username));
            pair.Add(new KeyValuePair<string, string>("email", m.Email));
            pair.Add(new KeyValuePair<string, string>("confirm_email", m.Email));
            pair.Add(new KeyValuePair<string, string>("password", m.Password));
            pair.Add(new KeyValuePair<string, string>("confirm_password", m.Password));
            pair.Add(new KeyValuePair<string, string>("public_profile_opt_in", "False"));
            pair.Add(new KeyValuePair<string, string>("screen_name", ""));
            pair.Add(new KeyValuePair<string, string>("terms", "on"));
            pair.Add(new KeyValuePair<string, string>("g-recaptcha-response", captcha));
            return new FormUrlEncodedContent(pair);
        }

        private CaptchaReturn GetCaptcha()
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0, 10, 0);
                retry:
                List<KeyValuePair<string, string>> content = new List<KeyValuePair<string, string>>();
                content.Add(new KeyValuePair<string, string>("API", StaticVars.CaptchaAPI));
                content.Add(new KeyValuePair<string, string>("WebsiteUrl", "https://club.pokemon.com/us/pokemon-trainer-club/parents/sign-up"));
                content.Add(new KeyValuePair<string, string>("WebsiteKey", "6LdpuiYTAAAAAL6y9JNUZzJ7cF3F8MQGGKko1bCy"));
                FormUrlEncodedContent sendContent = new FormUrlEncodedContent(content);
                try
                {
                    if (StaticVars.stop)
                    {
                        Thread.CurrentThread.Abort();
                    }
                    string response = client.PostAsync("http://captcha.shuffletanker.com/api/Captcha/GetResponse", sendContent).Result.Content.ReadAsStringAsync().Result;
                    //string response = client.PostAsync("http://localhost:39663/api/Captcha/GetResponse", sendContent).Result.Content.ReadAsStringAsync().Result;
                    CaptchaReturn cr = JsonConvert.DeserializeObject<CaptchaReturn>(response);
                    if (cr.status)
                    {
                        cr.tryCount = 0;
                        return cr;
                    }
                    else
                    {
                        if (cr.captcha_response.Contains("Zero Balance"))
                        {
                            StaticVars.stop = true;
                            StaticVars.LogText += "No Balance" + Environment.NewLine;
                            Thread.CurrentThread.Abort();
                        }
                        else if (cr.captcha_response.Contains("Please use your referral account"))
                        {
                            StaticVars.stop = true;
                            StaticVars.LogText += "Please use your 2Captcha referral account" + Environment.NewLine;
                            Thread.CurrentThread.Abort();
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                goto retry;
            }
        }

        private void PostBadCaptcha(string serverIndex, string captchaID)
        {
            try
            {
                List<KeyValuePair<string, string>> content = new List<KeyValuePair<string, string>>();
                content.Add(new KeyValuePair<string, string>("API", StaticVars.CaptchaAPI));
                content.Add(new KeyValuePair<string, string>("WebsiteUrl", "https://club.pokemon.com/us/pokemon-trainer-club/parents/sign-up"));
                content.Add(new KeyValuePair<string, string>("WebsiteKey", "6LdpuiYTAAAAAL6y9JNUZzJ7cF3F8MQGGKko1bCy"));
                content.Add(new KeyValuePair<string, string>("ServerIndex", serverIndex.ToString()));
                content.Add(new KeyValuePair<string, string>("CaptchaId", captchaID.ToString()));
                FormUrlEncodedContent sendContent = new FormUrlEncodedContent(content);
                using (HttpClient client = new HttpClient())
                {
                    string response = client.PostAsync("http://captcha.shuffletanker.com/api/Captcha/BadCaptcha", sendContent).Result.Content.ReadAsStringAsync().Result;
                    //string response = client.PostAsync("http://localhost:39663/api/Captcha/BadCaptcha", sendContent).Result.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine("Bad Captcha Submitted");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private void writeToFile()
        {
            lock (this)
            {
                if (!StaticVars.addToDB)
                {
                    string path = Directory.GetCurrentDirectory() + @"\" + StaticVars.domain + ".txt";
                    if (!File.Exists(path))
                    {
                        StreamWriter sw = File.CreateText(path);
                        sw.Close();
                    }
                    try
                    {
                        if ((StaticVars.Amount - StaticVars.title.success) < (StaticVars.threadA / 6))
                        {
                            StaticVars.stop = true;
                        }
                    }
                    catch { }
                    while (true)
                    {
                        try
                        {
                            if (!StaticVars.rocketMapOutPut)
                            {
                                File.AppendAllText(path, string.Format("{0}:{1}" + Environment.NewLine, m.Username, m.Password));
                            }
                            else
                            {
                                File.AppendAllText(path, string.Format("ptc,{0},{1}" + Environment.NewLine, m.Username, m.Password));
                            }
                            StaticVars.title.success += 1;
                            StaticVars.LogText += DateTime.Now + " :" + m.Username + " Created." + Environment.NewLine;
                            break;
                        }
                        catch { Thread.Sleep(1000); }
                    }
                }
                else if (StaticVars.addToDB)
                {
                    addToDB();
                    StaticVars.title.success += 1;
                    StaticVars.LogText += DateTime.Now + " :" + m.Username + " Created." + Environment.NewLine;
                }
            }
        }

        private void addToDB()
        {
            tryAgain:
            try
            {
                List<KeyValuePair<string, string>> content = new List<KeyValuePair<string, string>>();
                content.Add(new KeyValuePair<string, string>("api", StaticVars.CaptchaAPI));
                content.Add(new KeyValuePair<string, string>("account", string.Format("{0}:{1}", m.Username, m.Password)));
                content.Add(new KeyValuePair<string, string>("levem", "0"));
                FormUrlEncodedContent sendContent = new FormUrlEncodedContent(content);
                using (HttpClient client = new HttpClient())
                {
                    string response = client.PostAsync("http://ptc.shuffletanker.com/Add/Accounts", sendContent).Result.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception e)
            {
                StaticVars.LogText += e.Message;
                goto tryAgain;
            }
        }
        
        private void threadAbort(string message = "")
        {
            client.ClearCookie();
            client.inUse = false;
            client.lastUseTime = DateTime.Now;
            Thread.CurrentThread.Abort(message);
        }

        private void WriteErrorMessage(string pageSource)
        {
            string path = Directory.GetCurrentDirectory() + @"ErrorHttpRequest - " + client.proxy + ".txt";
            if (!File.Exists(path))
            {
                StreamWriter sw = File.CreateText(path);
                sw.Close();
            }
            try
            {
                File.WriteAllText(path, pageSource + Environment.NewLine);
            }
            catch { }
        }

        private void WriteFailLog(string message)
        {
            string path = Directory.GetCurrentDirectory() + @"\FailLog.txt";
            if (!File.Exists(path))
            {
                StreamWriter sw = File.CreateText(path);
                sw.Close();
            }
            while (true)
            {
                try
                {
                    File.AppendAllText(path, DateTime.Now.ToString() + ": " + message + Environment.NewLine);
                    return;
                }
                catch { Thread.Sleep(1000); }
            }
        }

    }
}
