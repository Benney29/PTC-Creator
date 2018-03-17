using System;
using System.Net;
using System.Net.Http;

namespace PTC_Creator.Models
{
    public static class HttpClientControl
    {
        public static HttpClient Init(Proxy proxy)
        {
            CookieContainer cookieJar = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseCookies = true,
                UseProxy = true,
                CookieContainer = cookieJar
            };
            if (proxy.username != "" && proxy.password != "")
            {
                handler.Proxy = new WebProxy(proxy.proxy);
            }
            else
            {
                handler.Proxy = new WebProxy(proxy.proxy, false)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(proxy.username, proxy.password)
                };
            }

            HttpClient client = new HttpClient(handler);
            client.SetHeaders();
            return client;
        }

        private static void SetHeaders(this HttpClient client)
        {
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
    }
}
