using PTC_Creator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC_Creator.Forms.ProxyForms
{
    public partial class Proxy_SetThread : Form
    {
        private List<Proxy> _proxies;
        public Proxy_SetThread(List<Proxy> proxies)
        {
            _proxies = proxies;
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThreadNumTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (ThreadAmountTextBox.Text != "")
            {
                _proxies.ForEach(_ => _.thread_amount = int.Parse(ThreadAmountTextBox.Text));
                GlobalSettings.proxyForm.proxyOlv.UpdateObjects(_proxies);
                MessageBox.Show(_proxies.Count + " proxies has updated");
                this.Close();
            }
        }
    }
}
