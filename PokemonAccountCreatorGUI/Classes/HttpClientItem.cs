using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAccountCreatorGUI.Classes
{
    class HttpClientItem
    {
        public string proxy;
        public int delaySec;
        public bool inUse;
        public HttpClient client;
        public CookieContainer CookieJar;
        public int failCount;
        public DateTime lastUseTime;

        public HttpClientItem(string p, int delayS)
        {
            inUse = false;
            proxy = p;
            delaySec = delayS;
            CookieJar = new CookieContainer();
            lastUseTime = new DateTime(1999, 1, 1);
            failCount = 0;
            HttpClientHandler handler = new HttpClientHandler() { UseCookies = true, UseProxy = true, CookieContainer = CookieJar, Proxy = new WebProxy(proxy) };
            client = new HttpClient(handler) { BaseAddress = new Uri("https://club.pokemon.com/") };

            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36");
            client.DefaultRequestHeaders.Add("Origin", "https://club.pokemon.com");
            client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            client.DefaultRequestHeaders.Add("Referer", "https://club.pokemon.com/us/pokemon-trainer-club/parents/sign-up");
            client.DefaultRequestHeaders.Add("DNT", "1");
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            client.MaxResponseContentBufferSize = 524288;
            client.Timeout = new TimeSpan(0, 0, 30);
        }
        
        public async Task<string> GetAsync(string uri)
        {
            string ret = "";
            using (HttpResponseMessage response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead))
            using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
            using (StreamReader streamReader = new StreamReader(streamToReadFrom, Encoding.UTF8))
            {
                ret = streamReader.ReadToEnd().Replace("\r\n", "").Replace("\t", "").Replace("\"", "").Replace("\n", "");
            }
            return ret;
        }

        public async Task<string> PostAsync(string uri, FormUrlEncodedContent content)
        {
            string ret = "";
            using (HttpResponseMessage response = await client.PostAsync(uri, content))
            using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
            using (StreamReader streamReader = new StreamReader(streamToReadFrom, Encoding.UTF8))
            {
                ret = streamReader.ReadToEnd().Replace("\r\n", "").Replace("\t", "").Replace("\"", "").Replace("\n", "");
            }
            return ret;
        }

        public void ClearCookie()
        {
            if (CookieJar.Count > 0)
            {
                foreach (string s in StaticVars.CookieList)
                {
                    var cookies = CookieJar.GetCookies(new Uri(s));
                    foreach (Cookie co in cookies)
                    {
                        co.Expires = new DateTime(2018, 1, 1);
                    }
                }
            }
        }
    }
}
