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
            BindingList<Proxy> bindingList = new BindingList<Proxy>(GlobalSettings.proxyList);
            DataGrid.DataSource = new BindingSource(bindingList, null);

        }

        private void DataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gridMenu.Show(DataGrid, new Point(e.X, e.Y));
            }
        }
        private void DataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cellMenu.Show(DataGrid, new Point(e.X, e.Y));
            }
        }

        private async void addSingleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proxy_Add m = new Proxy_Add(this);
            m.Show();
        }

        private void addMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectAllToolStripeMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void setThreadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void setDelayToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
