using Newtonsoft.Json;
using PTC_Creator.Models;
using PTC_Creator.Models.Creation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC_Creator.Forms
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }

        
        internal void UpdateStatus()
        {
            createOlv.SetObjects(GlobalSettings.creationStatus);
        }

        internal void UpdateStatus(StatusModel m)
        {
            Task.Run(() => createOlv.RefreshObject(m));
        }

        internal void UpdateStatus(List<StatusModel> m)
        {
            createOlv.RefreshObjects(m);
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {
            GlobalSettings.createForm = this;
            ShuffleAPITextBox.Text = GlobalSettings.creatorSettings.api;
            DomainTextBox.Text = GlobalSettings.creatorSettings.domain;
            UsernameTextBox.Text = GlobalSettings.creatorSettings.username;
            PasswordTextBox.Text = GlobalSettings.creatorSettings.password;
            CreateAmountTextBox.Text = GlobalSettings.creatorSettings.createAmount.ToString();
            ThreadAmountTextBox.Text = GlobalSettings.creatorSettings.threadAmount.ToString();
            ThreadCreationSpeedTextBox.Text = GlobalSettings.creatorSettings.threadCreationSpeed.ToString();
            RocketMapCheckBox.Checked = GlobalSettings.creatorSettings.rocketMapFormat;
            SaveInDBCheckBox.Checked = GlobalSettings.creatorSettings.saveDB;
            StatusDataGrid.DataSource = new BindingSource(GlobalSettings.creationStatus, null);
            createOlv.VirtualMode = true;
        }

        private void UsernameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (UsernameTextBox.Text.Trim().Length > 8)
            {
                e.Handled = true;
            }
        }

        private void NumOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void RocketMapCheckBox_Click(object sender, EventArgs e)
        {
            GlobalSettings.creatorSettings.rocketMapFormat = RocketMapCheckBox.Checked;
            if (RocketMapCheckBox.Checked)
            {
                SaveInDBCheckBox.Checked = false;
                GlobalSettings.creatorSettings.saveDB = false;
            }
        }

        private void SaveInDBCheckBox_Click(object sender, EventArgs e)
        {
            GlobalSettings.creatorSettings.saveDB = SaveInDBCheckBox.Checked;
            if (SaveInDBCheckBox.Checked)
            {
                RocketMapCheckBox.Checked = false;
                GlobalSettings.creatorSettings.rocketMapFormat = false;
            }
        }

        private void StartButton_ClickAsync(object sender, EventArgs e)
        {
            if (Validate_Config())
            {
                GlobalSettings.creatorSettings.api = ShuffleAPITextBox.Text.Trim();
                GlobalSettings.creatorSettings.domain = DomainTextBox.Text.Trim();
                GlobalSettings.creatorSettings.username = UsernameTextBox.Text.Trim();
                GlobalSettings.creatorSettings.password = PasswordTextBox.Text.Trim();
                GlobalSettings.creatorSettings.createAmount = int.Parse(CreateAmountTextBox.Text.Trim());
                GlobalSettings.creatorSettings.threadAmount = int.Parse(ThreadAmountTextBox.Text.Trim());
                GlobalSettings.creatorSettings.threadCreationSpeed = int.Parse(ThreadAmountTextBox.Text.Trim());
                GlobalSettings.creatorSettings.rocketMapFormat = RocketMapCheckBox.Checked;
                GlobalSettings.creatorSettings.saveDB = SaveInDBCheckBox.Checked;
                StopButton.Visible = true;
                StartButton.Visible = false;
                Task.Run(() => new Controller().Start());
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            GlobalSettings.worker_stop = true;
            StartButton.Visible = true;
            StopButton.Visible = false;
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            GlobalSettings.creatorSettings.api = ShuffleAPITextBox.Text.Trim();
            GlobalSettings.creatorSettings.domain = DomainTextBox.Text.Trim();
            GlobalSettings.creatorSettings.username = UsernameTextBox.Text.Trim();
            GlobalSettings.creatorSettings.password = PasswordTextBox.Text.Trim();
            try { GlobalSettings.creatorSettings.createAmount = int.Parse(CreateAmountTextBox.Text.Trim()); } catch { }
            try { GlobalSettings.creatorSettings.threadAmount = int.Parse(ThreadAmountTextBox.Text.Trim()); } catch { }
            try { GlobalSettings.creatorSettings.threadCreationSpeed = int.Parse(ThreadCreationSpeedTextBox.Text.Trim()); } catch { }
            GlobalSettings.creatorSettings.rocketMapFormat = RocketMapCheckBox.Checked;
            GlobalSettings.creatorSettings.saveDB = SaveInDBCheckBox.Checked;
            Properties.Settings.Default.CreatorSettings = JsonConvert.SerializeObject(GlobalSettings.creatorSettings);
            Properties.Settings.Default.CaptchaSettings = JsonConvert.SerializeObject(GlobalSettings.captchaSettings);
            Properties.Settings.Default.ProxyList = JsonConvert.SerializeObject(GlobalSettings.proxyList);
            Properties.Settings.Default.WebProxyList = JsonConvert.SerializeObject(GlobalSettings.webProxy);
            Properties.Settings.Default.Save();
        }

        private bool Validate_Config()
        {
            #region Creation Settings
            int tester = 0;
            if (DomainTextBox.Text.Trim() == "" || !DomainTextBox.Text.Contains('.'))
            {
                MessageBox.Show("Please enter a domain");
                return false;
            }
            else if (PasswordTextBox.Text.Trim() != "")
            {
                if (!PasswordTextBox.Text.Any(char.IsUpper) || !PasswordTextBox.Text.Any(char.IsLower)
                    || !PasswordTextBox.Text.Any(char.IsDigit) || !PasswordTextBox.Text.Any(ch => !char.IsLetterOrDigit(ch)))
                {
                    MessageBox.Show("Password invalid. Please enter at least" + Environment.NewLine +
                        "1 uppercase letter, lowercase letter, number, and special character");
                    return false;
                }
            }
            else if (CreateAmountTextBox.Text.Trim() == "" || !int.TryParse(CreateAmountTextBox.Text.Trim(), out tester) || tester == 0)
            {
                MessageBox.Show("Please enter creation amount");
                return false;
            }
            else if (ThreadAmountTextBox.Text.Trim() == "" || !int.TryParse(ThreadAmountTextBox.Text.Trim(), out tester) || tester == 0)
            {
                MessageBox.Show("Please enter thread amount");
                return false;
            }
            else if (!int.TryParse(ThreadCreationSpeedTextBox.Text.Trim(), out tester))
            {
                MessageBox.Show("Please enter thread creation speed");
                return false;
            }
            #endregion

            #region Captcha Settings
            foreach (CaptchaAPI _ in GlobalSettings.captchaSettings)
            {
                _.api = _.api.Trim();
            }

            if (!GlobalSettings.captchaSettings.Any(_ => _.enabled))
            {
                MessageBox.Show("Please enable at least one captcha service");
                return false;
            }
            else if (GlobalSettings.captchaSettings.Where(_ => _.enabled).Any(_ => _.api == ""))
            {
                MessageBox.Show("Please enter target service API key");
                return false;
            }
            #endregion

            #region ProxySettings
            if (GlobalSettings.proxyList.Count == 0 && GlobalSettings.webProxy.Count == 0)
            {
                MessageBox.Show("Please import proxies");
                return false;
            }
            #endregion

            return true;
        }

        private void createOlv_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            if (e.Column.Text != "Status" || !(e.CellValue is CreationStatus))
            {
                return;
            }

            switch ((CreationStatus)e.CellValue)
            {
                case CreationStatus.Processing:
                case CreationStatus.Pending:
                    e.SubItem.ForeColor = Color.White;
                    break;
                case CreationStatus.Created:
                    e.SubItem.ForeColor = Color.Green;
                    break;
                case CreationStatus.Failed:
                    e.SubItem.ForeColor = Color.Red;
                    break;
            }
        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogForm m = new LogForm((StatusModel)createOlv.SelectedObject);
            m.Show();
        }

        private void updateStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStatus(createOlv.SelectedObjects.Cast<StatusModel>().ToList());
        }

        private void createOlv_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                createOlvContextMenu.Show(createOlv, createOlv.PointToClient(Cursor.Position));
            }
        }
    }
}
