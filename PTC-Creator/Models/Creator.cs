using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PTC_Creator.Models
{
    public class Creator
    {
        WorkerModel worker;
        StatusModel status;

        bool proxy_dead = false;

        public Creator(WorkerModel _worker, StatusModel _status)
        {
            worker = _worker;
            status = _status;
        }

        public void Start()
        {
            status.AddLog("Start Checking Username");

            //If check username failed
            if (!CheckUsername())
            {
                if (proxy_dead)
                {
                    status.AddLog("Proxy Dead " + worker.proxyItem.proxy);
                    worker.failed_amount += 1;
                    status.ChangeStatus(CreationStatus.Waiting);
                }
                else
                {
                    status.AddLog("Username already used");
                    status.ChangeStatus(CreationStatus.Failed);
                }
                worker.inUse = false;
                return;
            }
            status.AddLog("Username check passed");
            string pageSource = "";

            //Get age verification page 
            pageSource = worker.client.GetStringAsync("/us/pokemon-trainer-club/sign-up").Result.Replace("\r\n", "").Replace("\t", "").Replace("\"", "").Replace("\n", "");
            worker.inUse = false;
            return;
        }

        private bool CheckUsername()
        {
            FormUrlEncodedContent formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("name", status.username)
                });

            try
            {
                using (HttpResponseMessage res = worker.client.PostAsync("https://club.pokemon.com/api/signup/verify-username", formContent).Result)
                {
                    string check = res.Content.ReadAsStringAsync().Result;
                    if (res.StatusCode == HttpStatusCode.Forbidden || res.StatusCode == HttpStatusCode.ServiceUnavailable ||
                        check.Contains("Request was throttled") || check.Contains("forbidden") || check.Contains("request could not be"))
                    {
                        worker.proxyItem.IncrementFail();
                        proxy_dead = true;
                        return false;
                    }
                    return check.Contains("true");
                }
            }
            catch { proxy_dead = true; return false; }
        }
    }
}
