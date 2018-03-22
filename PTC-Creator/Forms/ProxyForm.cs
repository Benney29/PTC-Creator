using PTC_Creator.Forms.ProxyForms;
using PTC_Creator.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC_Creator.Forms
{
    public partial class ProxyForm : Form
    {
        public ProxyForm()
        {
            InitializeComponent();
        }

        private void ProxyForm_Load(object sender, EventArgs e)
        {
            GlobalSettings.proxyForm = this;
            proxyOlv.SetObjects(GlobalSettings.proxyList);
        }

        internal void UpdateProxy(Proxy p)
        {
            proxyOlv.RefreshObject(p);
        }

        internal void UpdateProxy()
        {
            proxyOlv.SetObjects(GlobalSettings.proxyList);
        }

        internal void UpdateProxy(List<Proxy> p)
        {
            proxyOlv.RefreshObjects(p);
        }
        
        private void proxyOlv_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                gridMenu.Show(proxyOlv, proxyOlv.PointToClient(Cursor.Position));
            }
            else
            {
                cellMenu.Show(proxyOlv, proxyOlv.PointToClient(Cursor.Position));
            }
        }

        private void addSingleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proxy_Add m = new Proxy_Add();
            m.Show();
        }

        private void addMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!openFileDialog.CheckFileExists)
                {
                    MessageBox.Show("File doesn't exist");
                    return;
                }
                Regex proxyAuth = new Regex(@"\d+.\d+.\d+.\d+:\d+:.+:.+");
                Regex proxy = new Regex(@"\d+.\d+.\d+.\d+:\d+");
                int previous_count = GlobalSettings.proxyList.Count; //Use to show how many unique proxies been added to queue
                List<string> proxy_list = File.ReadAllLines(openFileDialog.FileName).ToList();
                ConcurrentBag<Proxy> temp_proxyList = new ConcurrentBag<Proxy>();
                Parallel.ForEach(proxy_list, _ =>
                {
                    Match m = proxyAuth.Match(_);
                    if (m.Success)
                    {
                        string[] values = m.Value.Split(':');
                        if (GlobalSettings.proxyList.FirstOrDefault(i => i.proxy == (values[0] + ":" + values[1])) == null)
                        {
                            temp_proxyList.Add(new Proxy(values[0] + ":" + values[1], values[2], values[3]));
                        }
                    }
                    else
                    {
                        m = proxy.Match(_);
                        if (m.Success && GlobalSettings.proxyList.FirstOrDefault(i => i.proxy == m.Value) == null)
                        {
                            temp_proxyList.Add(new Proxy(m.Value));
                        }
                    }
                });
                GlobalSettings.proxyList.AddRange(temp_proxyList.ToList());
                MessageBox.Show(GlobalSettings.proxyList.Count - previous_count + " unique proxies added to proxy list");
                proxyOlv.SetObjects(GlobalSettings.proxyList);
            }
        }

        private void toggleRotatingProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Proxy> pList = proxyOlv.SelectedObjects.Cast<Proxy>().ToList();
            foreach (Proxy _ in pList)
            {
                _.rotating = !_.rotating;
            }
            proxyOlv.RefreshObjects(pList);
        }

        private void setThreadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proxy_SetThread m = new Proxy_SetThread(proxyOlv.SelectedObjects.Cast<Proxy>().ToList());
            m.Show();
        }

        private void setDelayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proxy_SetDelay m = new Proxy_SetDelay(proxyOlv.SelectedObjects.Cast<Proxy>().ToList());
            m.Show();
        }

        private void resetStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proxyOlv.SelectedObjects.Cast<Proxy>().ToList().ForEach(_ =>
            {
                _.create_count = 0;
                _.fail_count = 0;
                proxyOlv.RefreshObject(_);
            });
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proxyOlv.SelectedObjects.Cast<Proxy>().ToList().ForEach(_ =>
            {
                GlobalSettings.proxyList.Remove(_);
            });
            proxyOlv.SetObjects(GlobalSettings.proxyList);
        }

        private async void testAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>TestProxies(GlobalSettings.proxyList.Where(_ => !_.rotating).ToList()));
            MessageBox.Show("Usable: " + GlobalSettings.proxyList.Count(_ => _.usable) + Environment.NewLine +
                "Not usable: " + GlobalSettings.proxyList.Count(_ => !_.usable));
        }

        private async void testSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Task.Run(() => TestProxies(proxyOlv.SelectedObjects.Cast<Proxy>().Where(_ => !_.rotating).ToList()));
            MessageBox.Show("Usable: " + proxyOlv.SelectedObjects.Cast<Proxy>().Count(_ => _.usable) + Environment.NewLine +
                "Not usable: " + proxyOlv.SelectedObjects.Cast<Proxy>().Count(_ => !_.usable));
        }

        private void TestProxies(List<Proxy> pList)
        {
            List<Thread> threadList = new List<Thread>();
            pList.ForEach(_ =>
            {
                while (threadList.Count(__ => __.IsAlive) > 200) { Thread.Sleep(1000); }
                Thread t = new Thread(() => TestProxies(_));
                t.Start();
                threadList.Add(t);
                Thread.Sleep(200);
            });
        }

        private void TestProxies(Proxy proxyItem)
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                UseProxy = true,
                Proxy = new WebProxy(proxyItem.proxy, false)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(proxyItem.username, proxyItem.password)
                }
            };
            using (HttpClient client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Safari/537.36");
                client.DefaultRequestHeaders.Add("Origin", "https://club.pokemon.com");
                client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                client.DefaultRequestHeaders.Add("Referer", "https://club.pokemon.com/us/pokemon-trainer-club/parents/sign-up");
                client.DefaultRequestHeaders.Add("DNT", "1");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                client.MaxResponseContentBufferSize = 524288;
                client.Timeout = new TimeSpan(0, 0, 10);
                client.BaseAddress = new Uri("https://club.pokemon.com/");
                try
                {
                    string pageSource = client.GetStringAsync("/us/pokemon-trainer-club/sign-up").Result
                    .Replace("\r\n", "").Replace("\t", "").Replace("\"", "").Replace("\n", "");
                    if (!pageSource.Contains("Verify Age"))
                    {
                        proxyItem.usable = false;
                    }
                    proxyOlv.RefreshObject(proxyItem);
                }
                catch
                {
                    proxyItem.usable = false;
                }
                proxyItem.test_log = "Tested: " + DateTime.Now.ToString();
                proxyOlv.RefreshObject(proxyItem);
            }
        }

        private void proxyOlv_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            if (e.Column.Text != "Usable" || !(e.CellValue is bool))
            {
                return;
            }

            switch ((bool)e.CellValue)
            {
                case true:
                    e.SubItem.ForeColor = Color.Green;
                    break;
                case false:
                    e.SubItem.ForeColor = Color.Red;
                    break;
            }
        }

        private void toggleAllUsableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalSettings.proxyList.ForEach(_ =>
            {
                _.usable = !_.usable;
            });
            proxyOlv.RefreshObjects(GlobalSettings.proxyList);
        }

        private void toggleSelectedUsableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proxyOlv.SelectedObjects.Cast<Proxy>().ToList().ForEach(_ => { _.usable = !_.usable; proxyOlv.RefreshObject(_); });
        }
    }
}
