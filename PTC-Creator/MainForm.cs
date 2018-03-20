using Newtonsoft.Json;
using PTC_Creator.Forms;
using PTC_Creator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC_Creator
{
    public partial class MainForm : Form
    {
        bool stopUpdate = false;
        public MainForm()
        {
            InitializeComponent();
            new Thread(UpdateStatusBarThread).Start();
        }

        internal void UpdateStatusBar()
        {
            int success = GlobalSettings.creationStatus.Count(_ => _.status == CreationStatus.Created);
            int fail = GlobalSettings.creationStatus.Count(_ => _.status == CreationStatus.Failed);
            int pending = GlobalSettings.creationStatus.Count(_ => _.status == CreationStatus.Pending);
            SuccessLabel.BeginInvoke(new Action(() =>
            {
                    SuccessLabel.Text = "Success: " + success;
            }));
            FailLabel.BeginInvoke(new Action(() =>
            {
                    FailLabel.Text = "Fail: " + fail;
            }));
            PendingLabel.BeginInvoke(new Action(() =>
            {
                    PendingLabel.Text = "Pending: " + pending;
            }));
            RateLabel.BeginInvoke(new Action(() =>
            {
                if (success + fail != 0)
                {
                    RateLabel.Text = String.Format("Success Rate: {0:P2}", (decimal)success / (success + fail));
                }
            }));
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            TitleLabel.Text += $" [Version - {Assembly.GetExecutingAssembly().GetName().Version}]";
            #region Load saved settings
            try
            {
                GlobalSettings.proxyList =
                    JsonConvert.DeserializeObject<List<Proxy>>(Properties.Settings.Default.ProxyList) == null ?
                    new List<Proxy>() : JsonConvert.DeserializeObject<List<Proxy>>(Properties.Settings.Default.ProxyList);
            }
            catch { MessageBox.Show("ProxyList load failed."); GlobalSettings.proxyList = new List<Proxy>(); }

            try
            {
                GlobalSettings.creatorSettings =
                    JsonConvert.DeserializeObject<CreatorSettings>(Properties.Settings.Default.CreatorSettings) == null ?
                    new CreatorSettings() : JsonConvert.DeserializeObject<CreatorSettings>(Properties.Settings.Default.CreatorSettings);
            }
            catch { MessageBox.Show("Creator settings load failed."); GlobalSettings.creatorSettings = new CreatorSettings(); }

            try
            {
                GlobalSettings.webProxy =
                    JsonConvert.DeserializeObject<List<WebProxyItem>>(Properties.Settings.Default.WebProxyList) == null ?
                    new List<WebProxyItem>() : JsonConvert.DeserializeObject<List<WebProxyItem>>(Properties.Settings.Default.WebProxyList);
            }
            catch { MessageBox.Show("WebProxyList load failed."); GlobalSettings.webProxy = new List<WebProxyItem>(); }


            try
            {
                GlobalSettings.captchaSettings =
                    JsonConvert.DeserializeObject<List<CaptchaAPI>>(Properties.Settings.Default.CaptchaSettings) == null ?
                    new List<CaptchaAPI>() : JsonConvert.DeserializeObject<List<CaptchaAPI>>(Properties.Settings.Default.CaptchaSettings);
            }
            catch { MessageBox.Show("Captcha settings load failed."); GlobalSettings.captchaSettings = new List<CaptchaAPI>(); }

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
            #endregion

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            GlobalSettings.webProxyForm.TopLevel = 
                GlobalSettings.createForm.TopLevel = 
                GlobalSettings.captchaFrom.TopLevel = 
                GlobalSettings.proxyForm.TopLevel = false;

            GlobalSettings.webProxyForm.AutoScroll = 
                GlobalSettings.createForm.AutoScroll = 
                GlobalSettings.captchaFrom.AutoScroll = 
                GlobalSettings.proxyForm.AutoScroll = true;

            GlobalSettings.webProxyForm.Dock = 
                GlobalSettings.createForm.Dock = 
                GlobalSettings.captchaFrom.Dock = 
                GlobalSettings.proxyForm.Dock = DockStyle.Fill;

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

        private void WebProxyButton_Click(object sender, EventArgs e)
        {
            ContentPanel.Controls.Clear();
            ContentPanel.Controls.Add(GlobalSettings.webProxyForm);
            GlobalSettings.webProxyForm.Show();
        }

        private void CaptchaButton_Click(object sender, EventArgs e)
        {
            ContentPanel.Controls.Clear();
            ContentPanel.Controls.Add(GlobalSettings.captchaFrom);
            GlobalSettings.captchaFrom.Show();
        }

        private void UpdateStatusBarThread()
        {
            while (!stopUpdate)
            {
                UpdateStatusBar();
                Thread.Sleep(5000);
            }
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
            stopUpdate = true;
            Properties.Settings.Default.CaptchaSettings= JsonConvert.SerializeObject(GlobalSettings.captchaSettings);
            Properties.Settings.Default.ProxyList = JsonConvert.SerializeObject(GlobalSettings.proxyList);
            Properties.Settings.Default.CreatorSettings = JsonConvert.SerializeObject(GlobalSettings.creatorSettings);
            Properties.Settings.Default.WebProxyList = JsonConvert.SerializeObject(GlobalSettings.webProxy);
            Properties.Settings.Default.Save();
        }
    }
}
