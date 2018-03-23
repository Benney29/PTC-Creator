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
    public partial class LogForm : Form
    {
        StatusModel m;

        public LogForm(StatusModel _m)
        {
            InitializeComponent();
            m = _m;
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

        private void LogForm_Load(object sender, EventArgs e)
        {
            TitleLabel.Text = m.username + " Creation Log";
            List<LogModel> model = m.GetLog().ToList();
            model.Reverse();
            LogOlv.SetObjects(model);

        }

        private void ClostButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogOlv_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            LogModel m = (LogModel)e.Model;

            if (m != null && e.Column == message)
            {
                switch (m.type)
                {
                    case LogType.Info:
                        e.SubItem.ForeColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                        break;
                    case LogType.Warning:
                        e.SubItem.ForeColor = Color.Yellow;
                        break;
                    case LogType.Critical:
                        e.SubItem.ForeColor = Color.Red;
                        break;
                    case LogType.Success:
                        e.SubItem.ForeColor = Color.Green;
                        break;
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            List<LogModel> model = m.GetLog().ToList();
            model.Reverse();
            LogOlv.SetObjects(model);
        }
    }
}
