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
    public partial class Proxy_Add : Form
    {
        private Regex proxyAuth = new Regex(@"\d+.\d+.\d+.\d+:\d+:.+:.+");
        private Regex proxy = new Regex(@"\d+.\d+.\d+.\d+:\d+");

        private ProxyForm pf;
        public Proxy_Add(ProxyForm _pf)
        {
            pf = _pf;
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Match proxyAuth_match = proxyAuth.Match(ProxyTextBox.Text.Trim());
            if (proxyAuth_match.Success)
            {
                string[] values = proxyAuth_match.Value.Split(':');
                if (GlobalSettings.proxyList.FirstOrDefault(_ => _.proxy == (values[0] + ":" + values[1])) != null)
                {
                    MessageBox.Show("Proxy Exists");
                    return;
                }
                GlobalSettings.proxyList.Add(new Proxy(values[0] + ":" + values[1], values[2], values[3]));
            }
            else
            {
                Match proxy_match = proxy.Match(ProxyTextBox.Text.Trim());
                if (proxy_match.Success)
                {
                    if (GlobalSettings.proxyList.FirstOrDefault(_ => _.proxy == proxy_match.Value) != null)
                    {
                        MessageBox.Show("Proxy Exists");
                        return;
                    }
                    GlobalSettings.proxyList.Add(new Proxy(proxy_match.Value));
                }
                else
                {
                    MessageBox.Show("Failed. Pattern not recognizable.");
                    return;
                }
            }
            MessageBox.Show("New Proxy Added");
            pf.ProxyDataGrid.DataSource = new BindingSource(GlobalSettings.proxyList, null);
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Window Move Section

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void WindowPanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = Location;
        }

        private void WindowPanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void WindowPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        #endregion
    }
}
