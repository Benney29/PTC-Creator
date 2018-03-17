﻿using PTC_Creator.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC_Creator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            CreateForm m = new CreateForm();
            m.TopLevel = false;
            m.AutoScroll = true;
            ContentPanel.Controls.Clear();
            ContentPanel.Controls.Add(m);
            m.Dock = DockStyle.Fill;
            m.Show();
        }

        private void ProxyButton_Click(object sender, EventArgs e)
        {
            ProxyForm m = new ProxyForm();
            m.TopLevel = false;
            m.AutoScroll = true;
            ContentPanel.Controls.Clear();
            ContentPanel.Controls.Add(m);
            m.Dock = DockStyle.Fill;
            m.Show();
        }

        private void CaptchaButton_Click(object sender, EventArgs e)
        {
            CaptchaForm m = new CaptchaForm();
            m.TopLevel = false;
            m.AutoScroll = true;
            ContentPanel.Controls.Clear();
            ContentPanel.Controls.Add(m);
            m.Dock = DockStyle.Fill;
            m.Show();
        }

        #region Window Control Button
        private void ClostButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        #endregion

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
