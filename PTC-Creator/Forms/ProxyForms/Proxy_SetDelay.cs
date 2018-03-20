using PTC_Creator.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PTC_Creator.Forms.ProxyForms
{
    public partial class Proxy_SetDelay : Form
    {
        List<Proxy> _proxies = new List<Proxy>();
        public Proxy_SetDelay(List<Proxy> proxies)
        {
            _proxies = proxies;
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DelayTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (DelayTextBox.Text != "")
            {
                _proxies.ForEach(_ => _.delay_sec = int.Parse(DelayTextBox.Text));
                MessageBox.Show(_proxies.Count + " proxies has updated");
                GlobalSettings.proxyForm.proxyOlv.UpdateObjects(_proxies);
                this.Close();
            }
        }
    }
}
