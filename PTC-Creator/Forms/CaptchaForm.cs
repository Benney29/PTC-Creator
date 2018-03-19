using PTC_Creator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace PTC_Creator.Forms
{
    public partial class CaptchaForm : Form
    {
        public CaptchaForm()
        {
            GlobalSettings.captchaSettings = new List<CaptchaAPI>();
            if (GlobalSettings.captchaSettings.Count == 0)
            {
                int index = 1;
                foreach (CaptchaProvider _ in Enum.GetValues(typeof(CaptchaProvider)))
                {
                    GlobalSettings.captchaSettings.Add(new CaptchaAPI(_, "", index));
                    index++;
                }
            }
            else if (GlobalSettings.captchaSettings.Count < Enum.GetValues(typeof(CaptchaProvider)).Length)
            {
                int index = GlobalSettings.captchaSettings.Count + 1;
                foreach (CaptchaProvider _ in Enum.GetValues(typeof(CaptchaProvider)))
                {
                    if (GlobalSettings.captchaSettings.FirstOrDefault(__ => __.provider == _) == null)
                    {
                        GlobalSettings.captchaSettings.Add(new CaptchaAPI(_, "", index));
                        index++;
                    }
                }
            }
            InitializeComponent();
        }

        private void CaptchaForm_Load(object sender, EventArgs e)
        {
            CaptchaDataGrid.DataSource = new BindingSource(GlobalSettings.captchaSettings, null);
            CaptchaDataGrid.Columns["provider"].ReadOnly = true;
            CaptchaDataGrid.Columns["success_count"].ReadOnly = true;
            CaptchaDataGrid.Columns["fail_count"].ReadOnly = true;
            CaptchaDataGrid.Columns["order"].ReadOnly = true;
        }


        private void DataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gridMenu.Show(CaptchaDataGrid, CaptchaDataGrid.PointToClient(Cursor.Position));
            }
        }
        private void DataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (!(CaptchaDataGrid.SelectedRows.Count > 1))
                {
                    CaptchaDataGrid.ClearSelection();
                }
                try
                {
                    CaptchaDataGrid.Rows[e.RowIndex].Selected = true;
                    cellMenu.Show(CaptchaDataGrid, CaptchaDataGrid.PointToClient(Cursor.Position));
                }
                catch { }
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptchaDataGrid.SelectAll();
            CaptchaDataGrid.Refresh();
        }
        
        private void resetStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in CaptchaDataGrid.SelectedRows)
            {
                CaptchaAPI c = row.DataBoundItem as CaptchaAPI;
                c.fail_count = 0;
                c.success_count = 0;
            }
            CaptchaDataGrid.Refresh();
        }

        private void moveToFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CaptchaDataGrid.SelectedRows.Count > 1)
            {
                MessageBox.Show("You can only select one row.");
                return;
            }

            CaptchaAPI c = CaptchaDataGrid.SelectedRows[0].DataBoundItem as CaptchaAPI;
            foreach (CaptchaAPI _ in GlobalSettings.captchaSettings)
            {
                if (_ == c)
                {
                    continue;
                }
                else if (_.order < c.order)
                {
                    _.order += 1;
                }
            }
            c.order = 1;
            CaptchaDataGrid.Refresh();
        }

        private void moveUPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptchaAPI c = CaptchaDataGrid.SelectedRows[0].DataBoundItem as CaptchaAPI;
            if (c.order == 1)
            {
                MessageBox.Show("1 is the highest priority.");
                return;
            }
            GlobalSettings.captchaSettings.FirstOrDefault(_ => (c.order - _.order) == 1).order += 1;
            c.order -= 1;
            CaptchaDataGrid.Refresh();
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptchaAPI c = CaptchaDataGrid.SelectedRows[0].DataBoundItem as CaptchaAPI;
            if (c.order == Enum.GetValues(typeof(CaptchaProvider)).Length)
            {
                MessageBox.Show(Enum.GetValues(typeof(CaptchaProvider)).Length + " is the lowest priority.");
                return;
            }
            GlobalSettings.captchaSettings.FirstOrDefault(_ => (_.order - c.order) == 1).order -= 1;
            c.order += 1;
            CaptchaDataGrid.Refresh();
        }

        private void moveToLastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CaptchaDataGrid.SelectedRows.Count > 1)
            {
                MessageBox.Show("You can only select one row.");
                return;
            }

            CaptchaAPI c = CaptchaDataGrid.SelectedRows[0].DataBoundItem as CaptchaAPI;
            foreach (CaptchaAPI _ in GlobalSettings.captchaSettings)
            {
                if (_ == c)
                {
                    continue;
                }
                else if (_.order > c.order)
                {
                    _.order -= 1;
                }
            }
            c.order = Enum.GetValues(typeof(CaptchaProvider)).Length;
            CaptchaDataGrid.Refresh();
        }
    }
}
