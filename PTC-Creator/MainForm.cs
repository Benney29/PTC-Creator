﻿using Newtonsoft.Json;
using PTC_Creator.Forms;
using PTC_Creator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            GlobalSettings.captchaSettings =
                JsonConvert.DeserializeObject<List<CaptchaAPI>>(Properties.Settings.Default.CaptchaSettings) == null ?
                new List<CaptchaAPI>() : JsonConvert.DeserializeObject<List<CaptchaAPI>>(Properties.Settings.Default.CaptchaSettings);
            GlobalSettings.proxyList =
                JsonConvert.DeserializeObject<List<Proxy>>(Properties.Settings.Default.ProxyList) == null ?
                new List<Proxy>() : JsonConvert.DeserializeObject<List<Proxy>>(Properties.Settings.Default.ProxyList);
            GlobalSettings.creatorSettings =
                JsonConvert.DeserializeObject<CreatorSettings>(Properties.Settings.Default.CreatorSettings) == null ?
                new CreatorSettings() : JsonConvert.DeserializeObject<CreatorSettings>(Properties.Settings.Default.CreatorSettings);
            GlobalSettings.webProxy =
                JsonConvert.DeserializeObject<WebProxyItem>(Properties.Settings.Default.WebProxyList) == null ?
                new WebProxyItem() : JsonConvert.DeserializeObject<WebProxyItem>(Properties.Settings.Default.WebProxyList);

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            GlobalSettings.createForm.TopLevel = GlobalSettings.captchaFrom.TopLevel = GlobalSettings.proxyForm.TopLevel = false;
            GlobalSettings.createForm.AutoScroll = GlobalSettings.captchaFrom.AutoScroll = GlobalSettings.proxyForm.AutoScroll = true;
            GlobalSettings.createForm.Dock = GlobalSettings.captchaFrom.Dock = GlobalSettings.proxyForm.Dock = DockStyle.Fill;

            ContentPanel.Controls.Clear();
            ContentPanel.Controls.Add(GlobalSettings.createForm);
            GlobalSettings.createForm.Show();


        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            ContentPanel.Controls.Clear();
            ContentPanel.Controls.Add(GlobalSettings.createForm);
            GlobalSettings.createForm.Show();
        }

        private void ProxyButton_Click(object sender, EventArgs e)
        {
            ContentPanel.Controls.Clear();
            ContentPanel.Controls.Add(GlobalSettings.proxyForm);
            GlobalSettings.proxyForm.Show();
        }

        private void CaptchaButton_Click(object sender, EventArgs e)
        {
            ContentPanel.Controls.Clear();
            ContentPanel.Controls.Add(GlobalSettings.captchaFrom);
            GlobalSettings.captchaFrom.Show();
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.CaptchaSettings= JsonConvert.SerializeObject(GlobalSettings.captchaSettings);
            Properties.Settings.Default.ProxyList = JsonConvert.SerializeObject(GlobalSettings.proxyList);
            Properties.Settings.Default.CreatorSettings = JsonConvert.SerializeObject(GlobalSettings.creatorSettings);
            Properties.Settings.Default.WebProxyList = JsonConvert.SerializeObject(GlobalSettings.webProxy);
            Properties.Settings.Default.Save();
        }

    }
}
