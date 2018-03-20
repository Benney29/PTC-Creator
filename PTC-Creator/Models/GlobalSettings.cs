using PTC_Creator.Forms;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PTC_Creator.Models
{
    public class GlobalSettings
    {
        #region forms
        internal static CreateForm createForm = new CreateForm();
        internal static CaptchaForm captchaFrom = new CaptchaForm();
        internal static ProxyForm proxyForm = new ProxyForm();
        internal static WebProxyForm webProxyForm = new WebProxyForm();
        #endregion

        internal static readonly string[] COOKIE_LIST = {"https://pokemon.com", "https://club.pokemon.com", "https://www.pokemon.com",
            "http://pokemon.com", "http://club.pokemon.com", "http://www.pokemon.com" };

        internal static List<CaptchaAPI> captchaSettings = new List<CaptchaAPI>();
        internal static List<Proxy> proxyList = new List<Proxy>();
        internal static List<WebProxyItem> webProxy = new List<WebProxyItem>();
        internal static CreatorSettings creatorSettings = new CreatorSettings();

        private static Random random = new Random();
        private static PersonNameGenerator nameGenObj = new PersonNameGenerator();

        internal static bool worker_stop = false;
        internal static Object fileLocker = new object();
        internal static List<WorkerModel> workers = new List<WorkerModel>();

        internal static List<StatusModel> creationStatus = new List<StatusModel>();
        internal static ConcurrentBag<StatusModel> creationPendingList = new ConcurrentBag<StatusModel>();

        public static int GetRandom(int length)
        {
            return random.Next(length);
        }

        public static int GetRandom()
        {
            return random.Next();
        }

        public static string GetFirstName()
        {
            return nameGenObj.GenerateRandomFirstName();
        }
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
        public event PropertyChangedEventHandler PropertyChanged;

        private CaptchaProvider _provider;
        [DisplayName("Captcha Provider")]
        public CaptchaProvider provider {
            get { return _provider; }
            set { _provider = value; this.NotifyPropertyChanged("provider"); }
        }

        private string _api;
        [DisplayName("API")]
        public string api {
            get { return _api; }
            set { _api = value; this.NotifyPropertyChanged("api"); }
        }

        private int _success_count;
        [DisplayName("Success Count")]
        public int success_count {
            get { return _success_count; }
            set { _success_count = value; this.NotifyPropertyChanged("success_count"); }
        }

        private int _fail_count;
        [DisplayName("Failure Count")]
        public int fail_count {
            get { return _fail_count; }
            set { _fail_count = value; this.NotifyPropertyChanged("fail_count"); }
        }

        private bool _enabled;
        [DisplayName("Enable")]
        public bool enabled
        {
            get { return _enabled; }
            set { _enabled = value; this.NotifyPropertyChanged("disabled"); }
        }

        private int _order;
        [DisplayName("Order")]
        public int order {
            get { return _order; }
            set { _order = value; this.NotifyPropertyChanged("order"); }
        }


        public CaptchaAPI(CaptchaProvider _provider, string _api, int _order)
        {
            provider = _provider;
            api = _api;
            success_count = 0;
            fail_count = 0;
            enabled = false;
            order = _order;
        }

        //Use for Deserialize
        public CaptchaAPI()
        { }

        public void IncrementSuccess()
        {
            Interlocked.Increment(ref _success_count);
        }

        public void IncrementFail()
        {
            Interlocked.Increment(ref _fail_count);
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
    #endregion

    #region Proxy Settings

    public class Proxy
    {

        public string proxy { get; set; }

        public ProxyType type { get; set; }

        public bool rotating { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public int thread_amount { get; set; }

        public int delay_sec { get; set; }

        public int create_count { get; set; }

        public int fail_count { get; set; }

        public bool usable { get; set; }

        public string test_log { get; set; }

        //This is used to deserialize object
        public Proxy()
        { }

        public Proxy(string _proxy, ProxyType proxy_type = ProxyType.HTTP, bool _rotating = false)
        {
            proxy = _proxy;
            type = proxy_type;
            rotating = _rotating;
            delay_sec = 900;
            create_count = 0;
            fail_count = 0;
            thread_amount = 1;
            usable = true;
            test_log = "";
        }

        public Proxy(string _proxy, string _username, string _password, ProxyType proxy_type = ProxyType.HTTP, bool _rotating = false)
        {
            proxy = _proxy;
            type = proxy_type;
            rotating = _rotating;
            delay_sec = 900;
            create_count = 0;
            fail_count = 0;
            usable = true;
            thread_amount = 1;
            username = _username;
            password = _password;
            test_log = "";
        }

        public void IncrementSuccess()
        {
            create_count += 1;
            GlobalSettings.proxyForm.UpdateProxy(this);
        }

        public void IncrementFail()
        {
            fail_count += 1;
            GlobalSettings.proxyForm.UpdateProxy(this);
        }
    }

    public class WebProxyItem
    {
        public string url { get; set; }

        public ProxyType type { get; set; }

        public int total { get; set; }

        public int amount { get; set; }

        public Nullable<DateTime> last_check_date { get; set; }

        public WebProxyItem(string _url, ProxyType _type)
        {
            url = _url;
            type = _type;
            last_check_date = null;
            total = 0;
            amount = 0;
        }

        public void AddAmount(int _amount)
        {
            amount = _amount;
            total += amount;
            GlobalSettings.webProxyForm.UpdateWebProxy(this);
        }
    }


    public enum ProxyType
    {
        HTTP,
        HTTPS,
        Socks4,
        Socks5
    }

    #endregion

    #region Creator Settings
    public class CreatorSettings
    {
        public string api { get; set; }
        public string domain { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int createAmount { get; set; }
        public int threadAmount { get; set; }
        public bool rocketMapFormat { get; set; }
        public bool saveDB { get; set; }

    }
    #endregion

    #region Creation Status
    public class StatusModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public CreationStatus status { get; set; }
        private List<LogModel> log = new List<LogModel>();
        public string dob { get; set; }
        public string email { get; set; }

        public string _log
        {
            get
            {
                if (log.Count > 0)
                {
                    return log[log.Count - 1].message;
                }
                return "";
            }
        }

        public void AddLog(string message, CreationStatus creationStatus = CreationStatus.None)
        {
            if (creationStatus != CreationStatus.None)
            {
                status = creationStatus;
            }
            log.Add(new LogModel(message));
            GlobalSettings.createForm.UpdateStatus(this);
        }

        public void ChangeStatus(CreationStatus s)
        {
            status = s;
            GlobalSettings.createForm.UpdateStatus(this);
        }


    }

    public class LogModel
    {
        public DateTime time { get; set; }
        public string message { get; set; }

        public LogModel(string _message)
        {
            time = DateTime.Now;
            message = _message;
        }
    }
    
    public enum CreationStatus
    {
        None,
        Waiting,
        Processing,
        Pending,
        Created,
        Failed
    }
    #endregion

    #region Worker Settings
    public class WorkerModel
    {
        public HttpClient client { get; set; }

        public bool inUse { get; set; }

        public DateTime last_used_time { get; set; }

        public Proxy proxyItem { get; set; }

        public int create_amount { get; set; }

        public int failed_amount { get; set; }
        
        private CookieContainer cookieJar { get; set; }

        public WorkerModel(HttpClient _client, Proxy _proxyItem, CookieContainer _cookieJar)
        {
            cookieJar = _cookieJar;
            _client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Safari/537.36");
            _client.DefaultRequestHeaders.Add("Origin", "https://club.pokemon.com");
            _client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            _client.DefaultRequestHeaders.Add("Referer", "https://club.pokemon.com/us/pokemon-trainer-club/parents/sign-up");
            _client.DefaultRequestHeaders.Add("DNT", "1");
            _client.DefaultRequestHeaders.Add("Accept", "*/*");
            _client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
            _client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            _client.MaxResponseContentBufferSize = 524288;
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.BaseAddress = new Uri("https://club.pokemon.com/");

            client = _client;
            inUse = false;
            last_used_time = new DateTime(2000, 1, 1);
            proxyItem = _proxyItem;
        }

        public void Reset()
        {
            last_used_time = DateTime.Now;
            create_amount = 0;
            failed_amount = 0;
        }

        private void RotatingReset()
        {
            client.Dispose();
            cookieJar = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = cookieJar,
                UseProxy = true,
                Proxy = new WebProxy(proxyItem.proxy, false)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(proxyItem.username, proxyItem.password)
                }
            };
            client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Safari/537.36");
            client.DefaultRequestHeaders.Add("Origin", "https://club.pokemon.com");
            client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            client.DefaultRequestHeaders.Add("Referer", "https://club.pokemon.com/us/pokemon-trainer-club/parents/sign-up");
            client.DefaultRequestHeaders.Add("DNT", "1");
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            client.MaxResponseContentBufferSize = 524288;
            client.Timeout = new TimeSpan(0, 0, 30);
            client.BaseAddress = new Uri("https://club.pokemon.com/");
        }

        public void ForceWait()
        {
            Reset();
            proxyItem.IncrementFail();
            if (!proxyItem.rotating)
            {
                ResetCookies();
                last_used_time = DateTime.Now.AddHours(2);
            }
            else
            {
                RotatingReset();
            }
            inUse = false;
        }

        public bool IsUsable()
        {
            if (inUse)
            {
                return false;
            }
            else if (proxyItem.rotating)
            {
                if (create_amount == 5 || failed_amount > 3)
                {
                    Reset();
                    RotatingReset();
                }
                return true;
            }
            else if (create_amount == 5)
            {
                Reset();
                return false;
            }
            else if (failed_amount > 5)
            {
                Reset();
                last_used_time = DateTime.Now.AddHours(2);
                return false;
            }
            else if (create_amount == 0 && DateTime.Now.Subtract(last_used_time).TotalSeconds < proxyItem.delay_sec)
            {
                return false;
            }
            return true;
        }
        

        public void ResetCookies()
        {
            last_used_time = DateTime.Now;
            List<Cookie> ret = new List<Cookie>();
            GlobalSettings.COOKIE_LIST.ToList().ForEach(_ =>
            {
                CookieCollection cookies = cookieJar.GetCookies(new Uri(_));
                foreach (Cookie co in cookies)
                {
                    co.Expires = new DateTime(2018, 1, 1);
                }
            });
        }
    }
    #endregion
}
