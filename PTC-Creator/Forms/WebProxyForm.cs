using PTC_Creator.Forms.ProxyForms;
using PTC_Creator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC_Creator.Forms
{
    public partial class WebProxyForm : Form
    {
        internal void UpdateWebProxy()
        {
            WebProxyOlv.SetObjects(GlobalSettings.webProxy);
        }

        internal void UpdateWebProxy(WebProxyItem p)
        {
            WebProxyOlv.UpdateObject(p);
        }

        internal void UpdateWebProxy(List<WebProxyItem> p)
        {
            WebProxyOlv.UpdateObjects(p);
        }


        public WebProxyForm()
        {
            InitializeComponent();
        }

        private void WebProxyForm_Load(object sender, EventArgs e)
        {
            UpdateWebProxy();
        }

        internal List<Proxy> GetProxies(string content, bool addToList)
        {
            List<Proxy> ret = new List<Proxy>();
            Regex proxy = new Regex(@"\d+.\d+.\d+.\d+:\d+");
            MatchCollection m_collection = proxy.Matches(content);

            if (m_collection.Count > 0)
            {
                foreach (Match m in m_collection)
                {
                    if (m.Success && GlobalSettings.proxyList.FirstOrDefault(i => i.proxy == m.Value) == null)
                    {
                        Proxy p = new Proxy(m.Value);
                        ret.Add(p);
                        if (addToList)
                        {
                            GlobalSettings.proxyList.Add(p);
                        }
                    }
                }
            }
            GlobalSettings.proxyForm.UpdateProxy();
            return ret;
        }

        private void WebProxyOlv_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                gridMenu.Show(WebProxyOlv, WebProxyOlv.PointToClient(Cursor.Position));
            }
            else
            {
                cellMenu.Show(WebProxyOlv, WebProxyOlv.PointToClient(Cursor.Position));
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WebProxy_Add m = new WebProxy_Add();
            m.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebProxyOlv.SelectedObjects.Cast<WebProxyItem>().ToList().ForEach(_ =>
            {
                GlobalSettings.webProxy.Remove(_);
            });
        }
    }
}
