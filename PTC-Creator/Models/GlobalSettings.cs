using System;
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
        public static ObservableCollection<CaptchaAPI> captchaSettings = new ObservableCollection<CaptchaAPI>();
        public static ObservableCollection<Proxy> proxyList = new ObservableCollection<Proxy>();
        public static CreatorSettings creatorSettings = new CreatorSettings();

        public static ObservableCollection<StatusModel> creationStatus = new ObservableCollection<StatusModel>();

        public static List<HttpClient> workers = new List<HttpClient>();

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
        public event PropertyChangedEventHandler PropertyChanged;

        private string _proxy;
        [DisplayName("Proxy")]
        public string proxy {
            get { return _proxy; }
            set { _proxy = value; this.NotifyPropertyChanged("proxy"); }
        }

        private ProxyType _type;
        [DisplayName("ProxyType")]
        public ProxyType type
        {
            get { return _type; }
            set { _type = value; this.NotifyPropertyChanged("type"); }
        }

        private string _username;
        [DisplayName("Username")]
        public string username {
            get { return _username; }
            set { _username = value; this.NotifyPropertyChanged("username"); }
        }

        private string _password;
        [DisplayName("Password")]
        public string password {
            get { return _password; }
            set { _password = value; this.NotifyPropertyChanged("password"); }
        }

        private int _thread_amount;
        [DisplayName("Thread Amount")]
        public int thread_amount {
            get { return _thread_amount; }
            set { _thread_amount = value; this.NotifyPropertyChanged("thread_amount"); }
        }

        private int _delay_sec;
        [DisplayName("Delay(Sec)")]
        public int delay_sec {
            get { return _delay_sec; }
            set { _delay_sec = value; this.NotifyPropertyChanged("delay_sec"); }
        }

        private int _creat_count { get; set; }
        [DisplayName("Creat Count")]
        public int creat_count {
            get { return _creat_count; }
            set { _creat_count = value; this.NotifyPropertyChanged("creat_count"); }
        }

        private int _fail_count;
        [DisplayName("Fail Count")]
        public int fail_count {
            get { return _fail_count; }
            set { _fail_count = value; this.NotifyPropertyChanged("fail_count"); }
        }

        private bool _usable;
        [DisplayName("Usable")]
        public bool usable {
            get { return _usable; }
            set { _usable = value; this.NotifyPropertyChanged("usable"); }
        }

        private DateTime _last_used_time;
        [DisplayName("Last Used")]
        public DateTime last_used_time {
            get { return _last_used_time; }
            set { _last_used_time = value; this.NotifyPropertyChanged("last_used_time"); }
        }

        private bool _inUse;
        [DisplayName("In Use")]
        public bool inUse {
            get { return _inUse; }
            set { _inUse = value; this.NotifyPropertyChanged("inUse"); }
        }

        [Browsable(false)]
        public List<HttpClient> clients { get; set; }

        //This is used to deserialize object
        public Proxy()
        { }

        public Proxy(string _proxy, ProxyType proxy_type = ProxyType.HTTP)
        {
            proxy = _proxy;
            type = proxy_type;
            delay_sec = 900;
            creat_count = 0;
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
            creat_count = 0;
            fail_count = 0;
            usable = true;
            last_used_time = new DateTime(2000, 1, 1);
            inUse = false;
            username = _username;
            password = _password;
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

    }

    public enum ProxyType
    {
        HTTP,
        HTTPS,
        HTTP_HTTPS,
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

        private int _index;
        [DisplayName("Index")]
        public int index {
            get { return _index; }
            set { _index = value;  this.NotifyPropertyChanged("index"); } }

        private string _username;
        [DisplayName("Username")]
        public string username {
            get { return _username; }
            set { _username = value; this.NotifyPropertyChanged("username"); }
        }

        private string _password;
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

        [Browsable(false)]
        public List<string> log = new List<string>();

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
