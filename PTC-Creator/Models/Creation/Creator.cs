﻿using PTC_Creator.Models.Captchas;
using PTC_Creator.Models.Captchas.AntiCaptcha;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace PTC_Creator.Models.Creation
{
    public class Creator
    {
        WorkerModel worker;
        StatusModel status;
        
        public Creator(WorkerModel _worker, StatusModel _status)
        {
            worker = _worker;
            status = _status;
        }

        public void Start()
        {
            if (GlobalSettings.worker_stop)
            {
                status.AddLog("Stopped.", CreationStatus.Waiting, LogType.Warning);
                terminateWorker(false, true);
            }
            status.AddLog("Start Checking Username", CreationStatus.Processing, LogType.Info);

            //If check username failed
            CheckUsername();
            status.AddLog("Username check passed, getting first page...", CreationStatus.Processing, LogType.Info);

            string pageSource = GetFirstWebPage();
            status.AddLog("Page received, looking for csrf token...", CreationStatus.Processing, LogType.Info);

            string token = GetCsrfToken(pageSource);
            status.AddLog("Csrf token found, starting to submit age verification...", CreationStatus.Processing, LogType.Info);

            SubmitAgeVerification(token);
            status.AddLog("Age verification passed, start creating account", CreationStatus.Processing, LogType.Info);

            if (GlobalSettings.worker_stop)
            {
                status.AddLog("Stopped.", CreationStatus.Waiting, LogType.Warning);
                terminateWorker(false, true);
            }

            string captcha_response = "";
            while (captcha_response == "")
            {
                captcha_response = GetCaptcha();
            }
            status.AddLog("Starting to submit account creation data...", CreationStatus.Processing, LogType.Info);

            SubmitAccountCreation(token, captcha_response);
            status.AddLog("Account Created", CreationStatus.Created, LogType.Success);

            SaveAccount(status);

            terminateWorker(true);
            return;

        }

        #region Process 
        private void CheckUsername()
        {
            FormUrlEncodedContent formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("name", status.username)
                });

            HttpResponseMessage response = null;
            try
            {
                response = worker.client.PostAsync("https://club.pokemon.com/api/signup/verify-username", formContent).Result;
            }
            catch
            {
                status.AddLog("Username check failed.", CreationStatus.Waiting, LogType.Warning);
                terminateWorker(false);
            }

            string check = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.ServiceUnavailable ||
                        check.Contains("Request was throttled") || check.Contains("forbidden") || check.Contains("request could not be"))
            {
                status.AddLog("Failed to check username due to proxy banned...", CreationStatus.Waiting, LogType.Warning);
                response.Dispose();
                terminateWorker(false);
            }
            else if (!check.Contains("true"))
            {
                status.AddLog("Failed to check username due to username used...", CreationStatus.Failed, LogType.Critical);
                response.Dispose();
                terminateWorker(false, true);
            }
            response.Dispose();
        }

        private string GetFirstWebPage()
        {
            string pageSource = "";
            try
            {
                using (HttpResponseMessage response = worker.client.GetAsync("/us/pokemon-trainer-club/sign-up").Result)
                {
                    pageSource = response.Content.ReadAsStringAsync().Result;
                    pageSource = pageSource.Replace("\r\n", "").Replace("\t", "").Replace("\"", "").Replace("\n", "");
                }
            }
            catch { }

            if (pageSource == "" || !pageSource.Contains("Verify Age"))
            {
                status.AddLog("Failed to receive first page...", CreationStatus.Waiting, LogType.Warning);
                terminateWorker(false);
            }
            return pageSource;
        }

        private string GetCsrfToken(string content)
        {
            Regex re = new Regex(@"csrfmiddlewaretoken' value='\w+");
            string token = "";
            try
            {
                token = re.Match(content).Value.Replace("csrfmiddlewaretoken' value='", "");
            }
            catch { }

            if (token == "")
            {
                status.AddLog("No csrf token found...", CreationStatus.Waiting, LogType.Warning);
                terminateWorker(false);
            }

            return token;
        }

        private FormUrlEncodedContent GetAgeVerificationContent(string token)
        {
            FormUrlEncodedContent ret = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("csrfmiddlewaretoken", token),
                new KeyValuePair<string, string>("picker__year", status.dob.Split('-')[0].ToString()),
                new KeyValuePair<string, string>("picker__month", (int.Parse(status.dob.Split('-')[1].ToString()) - 1).ToString()),
                new KeyValuePair<string, string>("dob", status.dob),
                new KeyValuePair<string, string>("country", "US")
            });
            return ret;
        }

        private void SubmitAgeVerification(string token)
        {
            string pageSource = "";
            try
            {
                using (HttpResponseMessage response = worker.client.PostAsync("/us/pokemon-trainer-club/sign-up/", GetAgeVerificationContent(token)).Result)
                {
                    pageSource = response.Content.ReadAsStringAsync().Result;
                    pageSource = pageSource.Replace("\r\n", "").Replace("\t", "").Replace("\"", "").Replace("\n", "");
                }
                    
            }
            catch { }

            if (pageSource == "") // || !pageSource.Contains("With a Pokémon Trainer Club account, you can:") um... Still thinking about adding this
            {
                status.AddLog("Submitting age verification failed, possibly proxy issue...", CreationStatus.Waiting, LogType.Warning);
                terminateWorker(false);
            }

            return;
        }

        private string GetCaptcha()
        {
            List<CaptchaAPI> serviceList = GlobalSettings.captchaSettings.Where(_ => _.enabled).ToList();
            if (serviceList.Count == 0)
            {
                GlobalSettings.worker_stop = true;
                terminateWorker(false, true);
            }
            string response = "";
            foreach (CaptchaAPI _ in GlobalSettings.captchaSettings.Where(_ => _.enabled))
            {
                try
                {
                    switch (_.provider)
                    {
                        case CaptchaProvider.AntiCaptcha:
                            status.AddLog("Getting captcha response from " + _.provider.ToString() + "...", CreationStatus.Processing, LogType.Info);
                            response = AntiCaptcha(_);
                            if (response != "")
                            {
                                status.AddLog(_.provider.ToString() + " solution received...", CreationStatus.Processing, LogType.Success);
                                return response;
                            }
                            else
                            {
                                status.AddLog(_.provider.ToString() + " no solution received...", CreationStatus.Processing, LogType.Warning);
                            }
                            break;
                        case CaptchaProvider.ImageTyperz:
                            status.AddLog("Getting captcha response from " + _.provider.ToString() + "...", CreationStatus.Processing, LogType.Info);
                            response = ImageTyperz(_);
                            if (response != "")
                            {
                                status.AddLog(_.provider.ToString() + " solution received...", CreationStatus.Processing, LogType.Success);
                                return response;
                            }
                            else
                            {
                                status.AddLog(_.provider.ToString() + " no solution received...", CreationStatus.Processing, LogType.Warning);
                            }
                            break;
                        case CaptchaProvider.TwoCaptcha:
                            status.AddLog("Getting captcha response from " + _.provider.ToString() + "...", CreationStatus.Processing, LogType.Info);
                            response = TwoCaptcha(_);
                            if (response != "")
                            {
                                status.AddLog(_.provider.ToString() + " solution received...", CreationStatus.Processing, LogType.Success);
                                return response;
                            }
                            else
                            {
                                status.AddLog(_.provider.ToString() + " no solution received...", CreationStatus.Processing, LogType.Warning);
                            }
                            break;
                    }
                }
                catch(Exception ex) {
                    status.AddLog("Captcha Exception: " + _.provider.ToString(), CreationStatus.Processing, LogType.Critical);
                    status.AddLog("Captcha Exception: " + ex.ToString(), CreationStatus.Processing, LogType.Critical);
                }
            }
            status.AddLog("Failed Receive any recaptcha response...", CreationStatus.Waiting, LogType.Critical);
            terminateWorker(false, true);
            return "";
        }

        private FormUrlEncodedContent GetAccountCreationContent(string token, string captcha_response)
        {
            List<KeyValuePair<string, string>> pair = new List<KeyValuePair<string, string>>();
            pair.Add(new KeyValuePair<string, string>("csrfmiddlewaretoken", token));
            pair.Add(new KeyValuePair<string, string>("username", status.username));
            pair.Add(new KeyValuePair<string, string>("email", status.email));
            pair.Add(new KeyValuePair<string, string>("confirm_email", status.email));
            pair.Add(new KeyValuePair<string, string>("password", status.password));
            pair.Add(new KeyValuePair<string, string>("confirm_password", status.password));
            pair.Add(new KeyValuePair<string, string>("public_profile_opt_in", "False"));
            pair.Add(new KeyValuePair<string, string>("screen_name", ""));
            pair.Add(new KeyValuePair<string, string>("terms", "on"));
            pair.Add(new KeyValuePair<string, string>("g-recaptcha-response", captcha_response));
            return new FormUrlEncodedContent(pair);
        }

        private void SubmitAccountCreation(string token, string captcha_response)
        {
            FormUrlEncodedContent content = GetAccountCreationContent(token, captcha_response);

            string pageSource = "";

            try
            {
                using (HttpResponseMessage response = worker.client.PostAsync("/us/pokemon-trainer-club/parents/sign-up", content).Result)
                {
                    pageSource = response.Content.ReadAsStringAsync().Result;
                    pageSource = pageSource.Replace("\r\n", "").Replace("\t", "").Replace("\"", "").Replace("\n", "");
                }
            }
            catch { }

            if (pageSource.Contains("Hello! Thank you for creating an account!"))
            {
                return;
            }
            else if (pageSource.Contains("Verify Age"))
            {
                status.AddLog("Oops, this proxy has been used by others and hit the limit... Try again 2 hours later...", CreationStatus.Failed, LogType.Critical);
                worker.ForceWait();
                Thread.CurrentThread.Abort();
            }
            else if (pageSource.Contains("Access Denied") || pageSource.Contains("The request could not be satisfied."))
            {
                status.AddLog("Oops, PTC website returned access denied... Failed...", CreationStatus.Failed, LogType.Critical);
                terminateWorker(false);
            }
            else if (pageSource.Contains("There is a problem with your email address.") || pageSource.Contains("Unexpected Error"))
            {
                GlobalSettings.creationPendingList.Add(status);
                status.AddLog("Oops, Unexpected error from PTC website... Added this too check list...", CreationStatus.Pending, LogType.Warning);
                terminateWorker(false);
            }
            else
            {
                GlobalSettings.creationPendingList.Add(status);
                status.AddLog("Unknow state. Proxy issue. Added this to check list...", CreationStatus.Pending, LogType.Warning);
                terminateWorker(false);
            }

        }

        private void SaveAccount(StatusModel _save)
        {
            if (GlobalSettings.creatorSettings.saveDB)
            {
                SaveToDb(_save);
            }
            else
            {
                lock (GlobalSettings.fileLocker)
                {
                    SaveToFile(_save);
                }
            }
        }

        private void SaveToDb(StatusModel _save)
        {
            while (true)
            {
                try
                {
                    List<KeyValuePair<string, string>> content = new List<KeyValuePair<string, string>>();
                    content.Add(new KeyValuePair<string, string>("api", GlobalSettings.creatorSettings.api));
                    content.Add(new KeyValuePair<string, string>("type", "1"));//Pokemon accounts
                    content.Add(new KeyValuePair<string, string>("account", string.Format("{0}:{1}", _save.username, _save.password)));
                    content.Add(new KeyValuePair<string, string>("account_level", "0"));
                    content.Add(new KeyValuePair<string, string>("email", string.Format("{0}@{1}", _save.username, GlobalSettings.creatorSettings.domain)));
                    FormUrlEncodedContent sendContent = new FormUrlEncodedContent(content);
                    using (HttpClient client = new HttpClient())
                    {
                        using (HttpResponseMessage response = client.PostAsync("https://api.shuffletanker.com/api/v2/Account/AddAccount/", sendContent).Result)
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                break;
                            }
                        }
                    }
                }
                catch { }
            }
            status.AddLog("Account saved in database...", CreationStatus.Created, LogType.Success);
        }

        private void SaveToFile(StatusModel _save)
        {
            string path = Directory.GetCurrentDirectory() + @"\" + GlobalSettings.creatorSettings.domain + ".txt";
            if (!File.Exists(path))
            {
                StreamWriter sw = File.CreateText(path);
                sw.Close();
            }
            while (true)
            {
                try
                {
                    if (!GlobalSettings.creatorSettings.rocketMapFormat)
                    {
                        File.AppendAllText(path, string.Format("{0}:{1}" + Environment.NewLine, _save.username, _save.password));
                    }
                    else
                    {
                        File.AppendAllText(path, string.Format("ptc,{0},{1}" + Environment.NewLine, _save.username, _save.password));
                    }
                    break;
                }
                catch { Thread.Sleep(1000); }
            }
            status.AddLog("Account saved in file...", CreationStatus.Created, LogType.Success);
        }


        #region Sub Captcha Section
        private string AntiCaptcha(CaptchaAPI model)
        {
            NoCaptchaProxyless api = new NoCaptchaProxyless
            {
                ClientKey = model.api,
                WebsiteUrl = new Uri("https://club.pokemon.com/us/pokemon-trainer-club/parents/sign-up"),
                WebsiteKey = "6LdpuiYTAAAAAL6y9JNUZzJ7cF3F8MQGGKko1bCy",

            };
            if (!api.CreateTask() || !api.WaitForResult())
            {
                if (api.ErrorMessage.Contains("ERROR_KEY_DOES_NOT_EXIST") ||
                    api.ErrorMessage.Contains("ERROR_ZERO_BALANCE") ||
                    api.ErrorMessage.Contains("ERROR_IP_NOT_ALLOWED") ||
                    api.ErrorMessage.Contains("ERROR_IP_BLOCKED")
                    )
                {
                    model.IncrementFail();
                    model.enabled = false;
                }
                return "";
            }
            else
            {
                model.IncrementSuccess();
                return api.GetTaskSolution();
            }
        }

        private string TwoCaptcha(CaptchaAPI model)
        {
            string captcha_response = "";
            string captcha_id = "";
            string post_end_point = "http://2captcha.com/in.php?" +
                "key=" + model.api + "&" +
                "method=userrecaptcha&" +
                "googlekey=6LdpuiYTAAAAAL6y9JNUZzJ7cF3F8MQGGKko1bCy&" +
                "pageurl=https://club.pokemon.com/us/pokemon-trainer-club/parents/sign-up&" +
                "here=now&" +
                "soft_id=2099"; //Do not change without Shuffle Permission
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(post_end_point).Result)
                {
                    captcha_id = response.Content.ReadAsStringAsync().Result;
                    captcha_id = captcha_id.Replace("\"", "");
                    if (captcha_id.Contains("OK"))
                    {
                        captcha_id = captcha_id.Replace("OK|", "");
                    }
                    else if (captcha_id.Contains("ERROR_WRONG_USER_KEY") ||
                        captcha_id.Contains("ERROR_KEY_DOES_NOT_EXIST") ||
                        captcha_id.Contains("ERROR_ZERO_BALANCE") ||
                        captcha_id.Contains("ERROR_IP_NOT_ALLOWED") ||
                        captcha_id.Contains("IP_BANNED")
                        )
                    {
                        model.IncrementFail();
                        model.enabled = false;
                        return "";
                    }
                    else
                    {
                        return "";
                    }
                }


                string get_end_point = "http://2captcha.com/res.php?" +
                        "key=" + model.api + "&" +
                        "action=get&" +
                        "id=" + captcha_id;
                int count = 0;
                while (count < 8)
                {
                    Thread.Sleep(15000);
                    using (HttpResponseMessage response = client.GetAsync(get_end_point).Result)
                    {
                        captcha_response = response.Content.ReadAsStringAsync().Result;
                        if (captcha_response.Contains("OK|"))
                        {
                            model.IncrementSuccess();
                            return captcha_response.Replace("OK|", "").Replace("\"", "");
                        }
                        else if (captcha_response.Contains("ERROR_WRONG_USER_KEY") ||
                            captcha_response.Contains("ERROR_KEY_DOES_NOT_EXIST")
                            )
                        {
                            model.IncrementFail();
                            model.enabled = false;
                            break;
                        }
                        else if (captcha_response.Contains("ERROR_CAPTCHA_UNSOLVABLE"))
                        {
                            break;
                        }
                        count += 1;
                    }
                }
                return "";
            }
        }

        private string ImageTyperz(CaptchaAPI model)
        {
            ImagetyperzAPI i = new ImagetyperzAPI(model.api);
            try
            {
                string id = i.submit_recaptcha("https://club.pokemon.com/us/pokemon-trainer-club/parents/sign-up", "6LdpuiYTAAAAAL6y9JNUZzJ7cF3F8MQGGKko1bCy");
                while (i.in_progress(id))
                {
                    Thread.Sleep(10000);
                }
                model.IncrementSuccess();
                return i.retrieve_captcha(id);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("AUTHENTICATION_FAILED"))
                {
                    model.IncrementFail();
                    model.enabled = false;
                }
                return "";
            }
        }
        #endregion

        #endregion

        private void terminateWorker(bool success, bool is_proxy_good = false)
        {
            if (success)
            {
                worker.create_amount += 1;
                worker.proxyItem.IncrementSuccess();
                worker.ResetCookies();
                worker.inUse = false;
            }
            else
            {
                if (!is_proxy_good)
                {
                    worker.failed_amount += 1;
                    worker.proxyItem.IncrementFail();
                }
                worker.ResetCookies();
                worker.inUse = false;
                Thread.CurrentThread.Abort();
            }
        }
    }
}
