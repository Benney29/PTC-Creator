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
                this.UpdateProxy();
            }
        }

        private void toggleRotatingProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Proxy> pList = proxyOlv.SelectedObjects.Cast<Proxy>().ToList();
            foreach (Proxy _ in pList)
            {
                _.rotating = !_.rotating;
            }
            this.UpdateProxy(pList);
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

    }
}
