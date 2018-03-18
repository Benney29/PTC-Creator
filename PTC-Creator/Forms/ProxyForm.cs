using PTC_Creator.Forms.ProxyForms;
using PTC_Creator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
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
            ProxyDataGrid.DataSource = new BindingSource(GlobalSettings.proxyList, null);
            ProxyTypeComboBox.DataSource = Enum.GetNames(typeof(ProxyType));
            WebProxyUrlTextBox.Text = GlobalSettings.webProxy.url;
            ProxyTypeComboBox.Text = GlobalSettings.webProxy.type.ToString();
        }

        private void DataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ProxyGridMenu.Show(ProxyDataGrid, ProxyDataGrid.PointToClient(Cursor.Position));
            }
        }
        private void DataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (!(ProxyDataGrid.SelectedRows.Count > 1))
                {
                    ProxyDataGrid.ClearSelection();
                }
                try
                {
                    ProxyDataGrid.Rows[e.RowIndex].Selected = true;
                    ProxyCellMenu.Show(ProxyDataGrid, ProxyDataGrid.PointToClient(Cursor.Position));
                }
                catch { }
            }
        }

        private void addSingleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proxy_Add m = new Proxy_Add(this);
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
                ProxyDataGrid.Refresh();
            }
        }

        private void selectAllToolStripeMenuItem_Click(object sender, EventArgs e)
        {
            ProxyDataGrid.SelectAll();
            ProxyDataGrid.Refresh();
        }

        private void setThreadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proxy_SetThread m = new Proxy_SetThread(this);
            m.Show();
        }
        private void setDelayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proxy_SetDelay m = new Proxy_SetDelay(this);
            m.Show();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in ProxyDataGrid.SelectedRows)
            {
                Proxy p = row.DataBoundItem as Proxy;
                p.fail_count = 0;
                p.creat_count = 0;
            }
            ProxyDataGrid.Refresh();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in ProxyDataGrid.SelectedRows)
            {
                Proxy p = row.DataBoundItem as Proxy;
                GlobalSettings.proxyList.Remove(p);
            }
            ProxyDataGrid.DataSource = new BindingSource(GlobalSettings.proxyList, null);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Uri test;
            if (ProxyTypeComboBox.Text != "HTTP")
            {
                MessageBox.Show("Only HTTP supported currently");
                return;
            }
            else if (!Uri.TryCreate(WebProxyUrlTextBox.Text.Trim(), UriKind.Absolute, out test))
            {
                MessageBox.Show("Please enter a valid proxy url");
                return;
            }
            GlobalSettings.webProxy.url = WebProxyUrlTextBox.Text.Trim();
            GlobalSettings.webProxy.type = (ProxyType)Enum.Parse(typeof(ProxyType), ProxyTypeComboBox.Text);

            using (HttpClient client = new HttpClient())
            {
                string content = "";
                try
                {
                    content = client.GetStringAsync(WebProxyUrlTextBox.Text.Trim()).Result;
                }
                catch { MessageBox.Show("Connection timeout"); return; }

                Regex proxyAuth = new Regex(@"\d+.\d+.\d+.\d+:\d+:.+:.+");
                Regex proxy = new Regex(@"\d+.\d+.\d+.\d+:\d+");
                int previous_count = GlobalSettings.proxyList.Count; //Use to show how many unique proxies been added to queue
                MatchCollection m_collection = proxy.Matches(content);

                if (m_collection.Count > 0)
                {
                    foreach (Match m in m_collection)
                    {
                        if (m.Success && GlobalSettings.proxyList.FirstOrDefault(i => i.proxy == m.Value) == null)
                        {
                            GlobalSettings.proxyList.Add(new Proxy(m.Value));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No proxy found in url");
                    return;
                }
                MessageBox.Show(GlobalSettings.proxyList.Count - previous_count + " unique proxies added to proxy list");
                GlobalSettings.proxyForm.ProxyDataGrid.DataSource = GlobalSettings.proxyList;
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
            else if (!Uri.TryCreate(WebProxyUrlTextBox.Text.Trim(), UriKind.Absolute, out test))
            {
                MessageBox.Show("Please enter a valid proxy url");
                return;
            }
            using (HttpClient client = new HttpClient())
            {
                string content = "";
                try
                {
                    content = client.GetStringAsync(WebProxyUrlTextBox.Text.Trim()).Result;
                }
                catch { MessageBox.Show("Connection timeout"); return; }

                Regex proxyAuth = new Regex(@"\d+.\d+.\d+.\d+:\d+:.+:.+");
                Regex proxy = new Regex(@"\d+.\d+.\d+.\d+:\d+");
                int previous_count = GlobalSettings.proxyList.Count; //Use to show how many unique proxies been added to queue
                MatchCollection m_collection = proxy.Matches(content);

                MessageBox.Show(m_collection.Count.ToString() + " proxies found in url");
            }
        }
    }
}
