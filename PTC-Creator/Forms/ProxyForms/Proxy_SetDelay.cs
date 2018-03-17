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
    public partial class Proxy_SetDelay : Form
    {
        ProxyForm pf;
        public Proxy_SetDelay(ProxyForm _pf)
        {
            pf = _pf;
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (DelayTextBox.Text != "")
            {
                foreach (DataGridViewRow row in pf.ProxyDataGrid.SelectedRows)
                {
                    Proxy p = row.DataBoundItem as Proxy;
                    p.delay_sec = int.Parse(DelayTextBox.Text);
                }
                MessageBox.Show(pf.ProxyDataGrid.SelectedRows.Count + " proxies has updated");
                pf.ProxyDataGrid.Refresh();
                this.Close();
            }
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
    }
}
