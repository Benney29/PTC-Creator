using Newtonsoft.Json;
using PTC_Creator.Models;
using PTC_Creator.Models.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PTC_Creator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            if (!(await UpdateAgent.IsLatest()))
            {
                DialogResult result = MessageBox.Show("New version found. Do you want to update?", "Found Update", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await UpdateAgent.Execute();
                }
            }

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            TitleLabel.Text += $" [Version - {version}]";
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

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

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

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            if (GlobalSettings.creationStatus.Count > 0)
            {
                try
                {
                    List<StatusModel> status = GlobalSettings.creationStatus.ToList();
                    int success = status.Count(_ => _.status == CreationStatus.Created);
                    int fail = status.Count(_ => _.status == CreationStatus.Failed);
                    int pending = status.Count(_ => _.status == CreationStatus.Pending);
                    decimal rate = success + fail == 0 ? 0 : (decimal)success / (success + fail);
                    SuccessLabel.Text = "Success: " + success;
                    FailLabel.Text = "Fail: " + fail;
                    PendingLabel.Text = "Pending: " + pending;
                    RateLabel.Text = String.Format("Success Rate: {0:P2}", rate);
                }
                catch { }
            }
        }

    }
}
