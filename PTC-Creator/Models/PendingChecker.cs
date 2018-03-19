using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace PTC_Creator.Models
{
    class PendingChecker
    {
        WorkerModel worker;
        StatusModel status;
        CancellationTokenSource cts;
        
        public PendingChecker(WorkerModel _worker, StatusModel _status, CancellationTokenSource _cts)
        {
            worker = _worker;
            status = _status;
            cts = _cts;
        }

        public void Check()
        {
            status.AddLog("Start verify account statusm, getting first page...");
            string pageSource = GetFirstPage();
            status.AddLog("Page received, looking for lt, execution, and eventid...");

            string ltToken = GetltToken(pageSource);
            string execution = GetExecution(pageSource);
            string eventId = GetEventID(pageSource);
            status.AddLog("lt, execution, and eventid received, starting verify");

            pageSource = SubmitLoginData(ltToken, execution, eventId);
            status.AddLog("Login data submitted, checking account state...");

            if (CheckAccountState(pageSource))
            {
                status.AddLog("Account created");
                terminateWorker(true);
            }
            else
            {
                status.ChangeStatus(CreationStatus.Failed);
                status.AddLog("Account failed to create...");
                terminateWorker(false, true);
            }
        }

        #region Process
        private string GetFirstPage()
        {
            string pageSource = "";
            try
            {
                pageSource = worker.client.GetAsync("/sso/login?locale=en&service=https://club.pokemon.com/us/pokemon-trainer-club/caslogin").Result
                    .Content.ReadAsStringAsync().Result.Replace("\r\n", "").Replace("\t", "").Replace("\"", "").Replace("\n", "");
            }
            catch { }

            if (pageSource == "")
            {
                status.ChangeStatus(CreationStatus.Pending);
                status.AddLog("Failed to receive first page...");
                terminateWorker(false);
            }

            return pageSource;
        }

        private string GetltToken(string pageSource)
        {
            Regex re = new Regex(@"lt value=\w+-\w+-\w+");
            string token = re.Match(pageSource).Value.Replace("lt value=", "");
            if (token == "")
            {
                status.ChangeStatus(CreationStatus.Pending);
                status.AddLog("No lt token found...");
                terminateWorker(false);
            }
            return token;
        }

        private string GetExecution(string pageSource)
        {
            Regex re = new Regex(@"execution value=\w+");
            string token = re.Match(pageSource).Value.Replace("execution value=", "");
            if (token == "")
            {
                status.ChangeStatus(CreationStatus.Pending);
                status.AddLog("No execution token found...");
                terminateWorker(false);
            }
            return token;
        }

        private string GetEventID(string pageSource)
        {
            Regex re = new Regex(@"_eventId value=\w+");
            string token = re.Match(pageSource).Value.Replace("_eventId value=", "");
            if (token == "")
            {
                status.ChangeStatus(CreationStatus.Pending);
                status.AddLog("No event id token found...");
                terminateWorker(false);
            }
            return token;
        }
        
        private FormUrlEncodedContent GetLoginContent(string lt, string execution, string eventID)
        {
            FormUrlEncodedContent ret = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("lt", lt),
                new KeyValuePair<string, string>("execution", execution),
                new KeyValuePair<string, string>("_eventId", eventID),
                new KeyValuePair<string, string>("username", status.username),
                new KeyValuePair<string, string>("password", status.password),
                new KeyValuePair<string, string>("Login", "Sign In"),
            });
            return ret;

        }

        private string SubmitLoginData(string lt, string execution, string eventID)
        {
            FormUrlEncodedContent content = GetLoginContent(lt, execution, eventID);

            string pageSource = "";

            try
            {
                pageSource = worker.client.PostAsync("/sso/login?locale=en&service=https://club.pokemon.com/us/pokemon-trainer-club/caslogin", content).Result
                    .Content.ReadAsStringAsync().Result.Replace("\r\n", "").Replace("\t", "").Replace("\"", "").Replace("\n", "");
            }
            catch { }

            if (pageSource == "")
            {
                status.ChangeStatus(CreationStatus.Pending);
                status.AddLog("Failed to submit login data, proxy issue...");
                terminateWorker(false);
            }
            return pageSource;
        }

        private bool CheckAccountState(string pageSource)
        {
            if (pageSource.Contains("Basic Information") || pageSource.Contains("Account Awaiting Activation"))
            {
                return true;
            }
            return false;
        }

        #endregion

        private void terminateWorker(bool success, bool is_proxy_good = false)
        {
            if (success)
            {
                status.ChangeStatus(CreationStatus.Created);
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
                cts.Cancel();
                cts.Token.ThrowIfCancellationRequested();
            }
        }

    }
}
