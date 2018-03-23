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
            LogOlv.SetObjects(m.GetLog().OrderByDescending(_ => _.time));
        }

        private void ClostButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
