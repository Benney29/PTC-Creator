using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAccountCreatorGUI.Classes
{
    class ImagetyperzAPI
    {
        // consts
        private static string RECAPTCHA_SUBMIT_ENDPOINT_TOKEN = "http://captchatypers.com/captchaapi/UploadRecaptchaToken.ashx";
        private static string RECAPTCHA_RETRIEVE_ENDPOINT_TOKEN = "http://captchatypers.com/captchaapi/GetRecaptchaTextToken.ashx";
        private static string BALANCE_ENDPOINT_TOKEN = "http://captchatypers.com/Forms/RequestBalanceToken.ashx";
        private static string USER_AGENT = "HiBoss";      // user agent used in requests

        private string _access_token;
        private string _affiliateid = "773505";
        private int _timeout = 120;

        private Recaptcha _recaptcha = null;

        private string _error = "";

        public ImagetyperzAPI(string access_token)
        {
            this._access_token = access_token;
        }

        public string submit_recaptcha(string page_url, string sitekey)
        {
            // check given vars
            if (string.IsNullOrWhiteSpace(page_url))
            {
                throw new Exception("page_url variable is null or empty");
            }
            if (string.IsNullOrWhiteSpace(sitekey))
            {
                throw new Exception("sitekey variable is null or empty");
            }
            
            // create dict (params)
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("action", "UPLOADCAPTCHA");
            d.Add("pageurl", page_url);
            d.Add("googlekey", sitekey);
            d.Add("token", this._access_token);
            d.Add("affiliateid", this._affiliateid);

            var post_data = Utils.list_to_params(d);        // transform dict to params
            string response = Utils.POST(RECAPTCHA_SUBMIT_ENDPOINT_TOKEN, post_data, USER_AGENT, this._timeout);       // make request
            if (response.Contains("ERROR:"))
            {
                var response_err = response.Split(new string[] { "ERROR:" }, StringSplitOptions.None)[1].Trim();
                this._error = response_err;
                throw new Exception(response_err);
            }

            // set as recaptcha [id] response and return
            var r = new Recaptcha(response);
            this._recaptcha = r;
            return this._recaptcha.captcha_id();        // return captcha id
        }

        /// <summary>
        /// Retrieve recaptcha response using captcha ID
        /// </summary>
        /// <param name="captcha_id"></param>
        /// <returns></returns>
        public string retrieve_captcha(string captcha_id)
        {
            // check if ID is OK
            if (string.IsNullOrWhiteSpace(captcha_id))
            {
                throw new Exception("captcha ID is null or empty");
            }
            
            // init params object
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("action", "GETTEXT");
            d.Add("captchaid", captcha_id);
            d.Add("token", this._access_token);

            var post_data = Utils.list_to_params(d);        // transform dict to params
            string response = Utils.POST(RECAPTCHA_RETRIEVE_ENDPOINT_TOKEN, post_data, USER_AGENT, this._timeout);       // make request
            if (response.Contains("ERROR:"))
            {
                var response_err = response.Split(new string[] { "ERROR:" }, StringSplitOptions.None)[1].Trim();
                // in this case, if we get NOT_DECODED, we don't need it saved to obj
                // because it's used by bool in_progress(int captcha_id) as well
                if (!response_err.Contains("NOT_DECODED"))
                {
                    this._error = response_err;
                }
                throw new Exception(response_err);
            }

            // set as recaptcha response and return
            this._recaptcha = new Recaptcha(captcha_id);
            this._recaptcha.set_response(response);
            return this._recaptcha.response();        // return captcha text
        }

        /// <summary>
        /// Tells if the recaptcha is still in progress (still being decoded)
        /// </summary>
        /// <param name="captcha_id"></param>
        /// <returns></returns>
        public bool in_progress(string captcha_id)
        {
            try
            {
                this.retrieve_captcha(captcha_id);          // try to retrieve captcha
                return false;       // no error, we're good
            }
            catch (Exception ex)
            {
                // if "known" error, still in progress
                if (ex.Message.Contains("NOT_DECODED"))
                {
                    return true;
                }
                // otherwise throw exception (if different error)
                throw ex;
            }
        }
    }

    class Utils
    {
        /// <summary>
        /// List to string
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string list_to_params(Dictionary<string, string> p)
        {
            string s = "";
            foreach (var e in p)
            {
                s += string.Format("{0}={1}&", e.Key, e.Value);
            }
            s = s.Trim('&');
            return s;
        }
        /// <summary>
        /// POST request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="post_data"></param>
        /// <param name="user_agent"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static string POST(string url, string post_data, string user_agent, int timeout)
        {
            // validate url
            if (!url.StartsWith("http"))
            {
                url = "http://" + url;
            }

            var request = (HttpWebRequest)WebRequest.Create(url);

            var data = Encoding.ASCII.GetBytes(post_data);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            // set user agent and timeout
            request.UserAgent = user_agent;
            request.Timeout = timeout;
            request.ReadWriteTimeout = timeout;

            request.Accept = "*/*";
            //request.ServicePoint.Expect100Continue = false;
            //request.AllowAutoRedirect = false;
            //request.Proxy = new WebProxy("192.168.1.24", 8080);


            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            HttpWebResponse response = null;
            response = (HttpWebResponse)request.GetResponse();
            string s = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return s;
        }
    }
    class Recaptcha
    {
        private string _captcha_id = "";
        private string _response = "";

        public Recaptcha(string captcha_id)
        {
            this._captcha_id = captcha_id;
        }
        /// <summary>
        /// Save captcha response to obj
        /// </summary>
        /// <param name="response"></param>
        public void set_response(string response)
        {
            this._response = response;
        }
        /// <summary>
        /// Getter for ID
        /// </summary>
        /// <returns></returns>
        public string captcha_id()
        {
            return this._captcha_id;
        }
        /// <summary>
        /// Getter for response
        /// </summary>
        /// <returns></returns>
        public string response()
        {
            return this._response;
        }
    }
}
