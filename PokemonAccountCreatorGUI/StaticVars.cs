using PokemonAccountCreatorGUI.Classes;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;

namespace PokemonAccountCreatorGUI
{
    class StaticVars
    {
        public static string ShuffleAPI;
        public static string AntiAPI;
        public static string ImageTyperzAPI;
        public static string TwoCaptchaAPI;

        public static string proxyAPI = "";
        public static string fileProxy = "";
        public static string password = "";
        public static string usernamePrefix = "";
        public static string domain;
        public static string stopReason = "";
        public static string LogText = "Starting..." + Environment.NewLine;
        public static string VerifiedLogText = "";
        public static string UnverifiedLogText = "";
        
        public static bool stop = false;
        public static bool rocketMapOutPut = false;
        public static bool addToDB = false;

        public static int threadA;
        public static int Amount = 0;

        public static consoleTitle title;
        public static Random random = new Random();
        public static PersonNameGenerator nameGenObj = new PersonNameGenerator();
        public static List<HttpClientItem> httpClientPool = new List<HttpClientItem>();
        public static Queue<HttpClientItem> UsableClientPool = new Queue<HttpClientItem>();
        public static List<string> existProxy = new List<string>();

        public static List<string> CookieList = new List<string>();


        public static void init()
        {
            CookieList.Add("https://pokemon.com");
            CookieList.Add("https://club.pokemon.com");
            CookieList.Add("https://www.pokemon.com");
            CookieList.Add("http://pokemon.com");
            CookieList.Add("http://club.pokemon.com");
            CookieList.Add("http://www.pokemon.com");
        }
        
        
    }

    class consoleTitle
    {
        public int success { get; set; }
        public int fail { get; set; }

        public consoleTitle()
        {
            success = 0;
            fail = 0;
        }
        
    }
    
    class UserInputModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Dob { get; set; }
    }

    class captchaProxyModel
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public captchaProxyModel(string s)
        {

            IP = s.Split(':')[0]; Port = int.Parse(s.Split(':')[1]);
        }
    }

    public class CaptchaReturn
    {
        public string captcha_response { get; set; }
        public bool status { get; set; }
        public string server_index { get; set; }
        public string captcha_id { get; set; }
        public int tryCount { get; set; }

        public CaptchaReturn(string captcharesponse, bool Status, string serverindex, string captchaid)
        {
            captcha_response = captcharesponse;
            status = Status;
            server_index = serverindex;
            captcha_id = captchaid;
            tryCount = 0;
        }
    }
}
