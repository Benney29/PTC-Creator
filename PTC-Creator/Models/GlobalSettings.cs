using PTC_Creator.Forms;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PTC_Creator.Models
{
    public class GlobalSettings
    {
        #region forms
        internal static CreateForm createForm = new CreateForm();
        internal static CaptchaForm captchaFrom = new CaptchaForm();
        internal static ProxyForm proxyForm = new ProxyForm();
        #endregion

        internal static ObservableCollection<CaptchaAPI> captchaSettings = new ObservableCollection<CaptchaAPI>();
        internal static ObservableCollection<Proxy> proxyList = new ObservableCollection<Proxy>();
        internal static WebProxyItem webProxy = new WebProxyItem();
        internal static CreatorSettings creatorSettings = new CreatorSettings();
        
        internal static Random random = new Random();
        internal static PersonNameGenerator nameGenObj = new PersonNameGenerator();


        internal static ConcurrentBag<StatusModel> creationBag = new ConcurrentBag<StatusModel>();
        internal static List<HttpClient> workers = new List<HttpClient>();


        internal static List<StatusModel> creationStatus = new List<StatusModel>();


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

        public string username { get; set; }

        public string password { get; set; }

        public int thread_amount { get; set; }

        public int delay_sec { get; set; }

        public int create_count { get; set; }

        public int fail_count { get; set; }

        public bool usable { get; set; }

        public DateTime last_used_time { get; set; }

        public bool inUse { get; set; }

        //This is used to deserialize object
        public Proxy()
        { }

        public Proxy(string _proxy, ProxyType proxy_type = ProxyType.HTTP)
        {
            proxy = _proxy;
            type = proxy_type;
            delay_sec = 900;
            create_count = 0;
            fail_count = 0;
            usable = true;
            last_used_time = new DateTime(2000, 1, 1);
            inUse = false;
        }

        public Proxy(string _proxy, string _username, string _password, ProxyType proxy_type = ProxyType.HTTP)
        {
            proxy = _proxy;
            type = proxy_type;
            delay_sec = 900;
            create_count = 0;
            fail_count = 0;
            usable = true;
            last_used_time = new DateTime(2000, 1, 1);
            inUse = false;
            username = _username;
            password = _password;
        }

    }

    public class WebProxyItem
    {
        public string url { get; set; }
        public ProxyType type { get; set; }
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
        public event PropertyChangedEventHandler PropertyChanged;
        
        private string _username = "";
        [DisplayName("Username")]
        public string username {
            get { return _username; }
            set { _username = value; this.NotifyPropertyChanged("username"); }
        }

        private string _password = "";
        [DisplayName("Password")]
        public string password {
            get { return _password; }
            set { _password = value; this.NotifyPropertyChanged("passwored"); }
        }

        private CreationStatus _status;
        [DisplayName("Status")]
        public CreationStatus status
        {
            get { return _status; }
            set { _status = value; this.NotifyPropertyChanged("status"); }
        }

        public string _log
        {
            get { try { return log[0]; } catch { return ""; } }
        }

        [Browsable(false)]
        public List<string> log = new List<string>();

        [Browsable(false)]
        public string dob { get; set; }

        [Browsable(false)]
        public string email { get; set; }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        
    }
    
    public enum CreationStatus
    {
        Waiting,
        Processing,
        Created,
        Failed
    }
    #endregion
}
