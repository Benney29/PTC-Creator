using PTC_Creator.Forms.ProxyForms;
using PTC_Creator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC_Creator.Forms
{
    public partial class ProxyForm : Form
    {
        public ProxyForm()
        {
            InitializeComponent();
            GlobalSettings.proxyForm = this;
        }
        private void ProxyForm_Load(object sender, EventArgs e)
        {
            WebProxyPanel.Height = ProxyUrlTextBox.Height;
            ProxyTypePanel.Width = int.Parse((0.1 * InfoPanel.Width).ToString());
            proxyOlv.SetObjects(GlobalSettings.proxyList);
            ProxyTypeComboBox.DataSource = Enum.GetNames(typeof(ProxyType));
            ProxyUrlTextBox.Text = GlobalSettings.webProxy.url;
            ProxyTypeComboBox.Text = GlobalSettings.webProxy.type.ToString();
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
            if (!openFileDialog.CheckFileExists)
            {
                MessageBox.Show("File doesn't exist");
                return;
            }
            Regex proxyAuth = new Regex(@"\d+.\d+.\d+.\d+:\d+:.+:.+");
            Regex proxy = new Regex(@"\d+.\d+.\d+.\d+:\d+");
            int previous_count = GlobalSettings.proxyList.Count; //Use to show how many unique proxies been added to queue
            List<string> proxy_list = File.ReadAllLines(openFileDialog.FileName).ToList();
            proxy_list.ForEach(_ =>
            {
                Match m = proxyAuth.Match(_);
                if (m.Success)
                {
                    string[] values = m.Value.Split(':');
                    if (GlobalSettings.proxyList.FirstOrDefault(i => i.proxy == (values[0] + ":" + values[1])) == null)
                    {
                        GlobalSettings.proxyList.Add(new Proxy(values[0] + ":" + values[1], values[2], values[3]));
                    }
                }
                else
                {
                    m = proxy.Match(_);
                    if (m.Success && GlobalSettings.proxyList.FirstOrDefault(i => i.proxy == m.Value) == null)
                    {
                        GlobalSettings.proxyList.Add(new Proxy(m.Value));
                    }
                }
            });
            MessageBox.Show(GlobalSettings.proxyList.Count - previous_count + " unique proxies added to proxy list");
            this.UpdateProxy();
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
                UpdateProxy(_);
            });
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proxyOlv.SelectedObjects.Cast<Proxy>().ToList().ForEach(_ =>
            {
                GlobalSettings.proxyList.Remove(_);
            });
            UpdateProxy();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Uri test;
            if (ProxyTypeComboBox.Text != "HTTP")
            {
                MessageBox.Show("Only HTTP supported currently");
                return;
            }
            else if (!Uri.TryCreate(ProxyUrlTextBox.Text.Trim(), UriKind.Absolute, out test))
            {
                MessageBox.Show("Please enter a valid proxy url");
                return;
            }
            GlobalSettings.webProxy.url = ProxyUrlTextBox.Text.Trim();
            GlobalSettings.webProxy.type = (ProxyType)Enum.Parse(typeof(ProxyType), ProxyTypeComboBox.Text);

            using (HttpClient client = new HttpClient())
            {
                string content = "";
                try
                {
                    content = client.GetStringAsync(ProxyUrlTextBox.Text.Trim()).Result;
                }
                catch { MessageBox.Show("Connection timeout"); return; }

                int response = GetProxies(content, true);

                if (response == 0)
                {
                    MessageBox.Show("No proxy found in url");
                    return;
                }
                MessageBox.Show(response + " unique proxies added to proxy list");
                UpdateProxy();
            }
        }


        private void TestButton_Click(object sender, EventArgs e)
        {
            Uri test;
            if (ProxyTypeComboBox.Text != "HTTP")
            {
                MessageBox.Show("Only HTTP supported currently");
                return;
            }
            else if (!Uri.TryCreate(ProxyUrlTextBox.Text.Trim(), UriKind.Absolute, out test))
            {
                MessageBox.Show("Please enter a valid proxy url");
                return;
            }
            using (HttpClient client = new HttpClient())
            {
                string content = "";
                try
                {
                    content = client.GetStringAsync(ProxyUrlTextBox.Text.Trim()).Result;
                }
                catch { MessageBox.Show("Connection timeout"); return; }
                int response = GetProxies(content, false);

                if (response == 0)
                {
                    MessageBox.Show("No proxy found in url");
                    return;
                }
                MessageBox.Show(response + " unique proxies added to proxy list");
            }
        }


        internal int GetProxies(string content, bool addToList)
        {
            int ret = 0;
            Regex proxy = new Regex(@"\d+.\d+.\d+.\d+:\d+");
            MatchCollection m_collection = proxy.Matches(content);

            if (m_collection.Count > 0)
            {
                foreach (Match m in m_collection)
                {
                    if (m.Success && GlobalSettings.proxyList.FirstOrDefault(i => i.proxy == m.Value) == null)
                    {
                        ret += 1;
                        if (addToList)
                        {
                            GlobalSettings.proxyList.Add(new Proxy(m.Value));
                        }
                    }
                }
            }
            return ret;
        }
    }
}
