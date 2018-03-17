using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PTC_Creator.Models
{
    public class GlobalSettings
    {
        public static List<CaptchaAPI> captchaSettings = new List<CaptchaAPI>();
        public static List<Proxy> proxyList = new List<Proxy>();
    }

    #region Captcha Settings
    public enum CaptchaProvider
    {
        AntiCaptcha,
        ImageTyperz,
        TwoCaptcha
    }

    public class CaptchaAPI
    {

        [DisplayName("Captcha Provider")]
        public CaptchaProvider provider { get; set; }

        [DisplayName("API")]
        public string api { get; set; }

        [DisplayName("Success Count")]
        public int success_count { get; set; }

        [DisplayName("Failure Count")]
        public int fail_count { get; set; }

        public CaptchaAPI(CaptchaProvider _provider, string _api)
        {
            provider = _provider;
            api = _api;
            success_count = 0;
            fail_count = 0;
        }
    }
    #endregion

    #region Proxy Settings
    public class Proxy
    {
        [DisplayName("Proxy")]
        public string proxy { get; set; }

        [DisplayName("Username")]
        public string username { get; set; }

        [DisplayName("Password")]
        public string password { get; set; }

        [DisplayName("Thread Amount")]
        public int thread_amount { get; set; }

        [DisplayName("Delay(Sec)")]
        public int delay_sec { get; set; }

        [DisplayName("Created Count")]
        public int created_count { get; set; }

        [DisplayName("Failed Count")]
        public int fail_count { get; set; }

        [DisplayName("Usable")]
        public bool usable { get; set; }

        [DisplayName("Last Used")]
        public DateTime last_used_time { get; set; }

        [DisplayName("In Use")]
        public bool inUse { get; set; }

        [Browsable(false)]
        public List<HttpClient> clients { get; set; }

        public Proxy(string _proxy)
        {
            proxy = _proxy;
            delay_sec = 900;
            created_count = 0;
            fail_count = 0;
            usable = true;
            last_used_time = new DateTime(2000, 1, 1);
            inUse = false;
        }

        public Proxy(string _proxy, string _username, string _password)
        {
            proxy = _proxy;
            delay_sec = 900;
            created_count = 0;
            fail_count = 0;
            usable = true;
            last_used_time = new DateTime(2000, 1, 1);
            inUse = false;
            username = _username;
            password = _password;
        }
    }
    #endregion

    #region Shuffle Settings
    public class ShuffleSettings
    {
        public string api { get; set; }
        public bool saveDB { get; set; }

    }
    #endregion
}
