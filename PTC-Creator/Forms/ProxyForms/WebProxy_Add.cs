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
    public partial class WebProxy_Add : Form
    {
        public WebProxy_Add()
        {
            InitializeComponent();
        }

        private void WebProxy_Add_Load(object sender, EventArgs e)
        {
            ProxyTypeComboBox.DataSource = Enum.GetNames(typeof(ProxyType));
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Uri test;
            if (ProxyTypeComboBox.Text != "HTTP")
            {
                MessageBox.Show("Only HTTP supported currently");
                return;
            }
            else if (!Uri.TryCreate(UrlTextBox.Text.Trim(), UriKind.Absolute, out test))
            {
                MessageBox.Show("Please enter a valid proxy url");
                return;
            }
            if (!GlobalSettings.webProxy.Any(_ => _.url == UrlTextBox.Text.Trim()))
            {
                GlobalSettings.webProxy.Add(new WebProxyItem(UrlTextBox.Text.Trim(), (ProxyType)Enum.Parse(typeof(ProxyType), ProxyTypeComboBox.Text)));
                GlobalSettings.webProxyForm.UpdateWebProxy();
                this.Close();
            }
            else
            {
                MessageBox.Show("Proxy Url Exists");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
