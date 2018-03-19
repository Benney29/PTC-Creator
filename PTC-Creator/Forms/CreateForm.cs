using Newtonsoft.Json;
using PTC_Creator.Models;
using System;
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

        internal void StatusGridRedraw()
        {
            this.StatusDataGrid.Refresh();
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {
            ShuffleAPITextBox.Text = GlobalSettings.creatorSettings.api;
            DomainTextBox.Text = GlobalSettings.creatorSettings.domain;
            UsernameTextBox.Text = GlobalSettings.creatorSettings.username;
            PasswordTextBox.Text = GlobalSettings.creatorSettings.password;
            ThreadAmountTextBox.Text = GlobalSettings.creatorSettings.threadAmount.ToString();
            CreateAmountTextBox.Text = GlobalSettings.creatorSettings.createAmount.ToString();
            RocketMapCheckBox.Checked = GlobalSettings.creatorSettings.rocketMapFormat;
            SaveInDBCheckBox.Checked = GlobalSettings.creatorSettings.saveDB;
            StatusDataGrid.DataSource = new BindingSource(GlobalSettings.creationStatus, null);
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
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void RocketMapCheckBox_Click(object sender, EventArgs e)
        {
            RocketMapCheckBox.Checked = !RocketMapCheckBox.Checked;
            GlobalSettings.creatorSettings.rocketMapFormat = RocketMapCheckBox.Checked;
            if (RocketMapCheckBox.Checked)
            {
                SaveInDBCheckBox.Checked = false;
                GlobalSettings.creatorSettings.saveDB = false;
            }
        }

        private void SaveInDBCheckBox_Click(object sender, EventArgs e)
        {
            SaveInDBCheckBox.Checked = !SaveInDBCheckBox.Checked;
            GlobalSettings.creatorSettings.saveDB = SaveInDBCheckBox.Checked;
            if (SaveInDBCheckBox.Checked)
            {
                RocketMapCheckBox.Checked = false;
                GlobalSettings.creatorSettings.rocketMapFormat = false;
            }
        }

        private async void StartButton_ClickAsync(object sender, EventArgs e)
        {
            if (Validate_Config())
            {
                GlobalSettings.creatorSettings.api = ShuffleAPITextBox.Text.Trim();
                GlobalSettings.creatorSettings.domain = DomainTextBox.Text.Trim();
                GlobalSettings.creatorSettings.username = UsernameTextBox.Text.Trim();
                GlobalSettings.creatorSettings.password = PasswordTextBox.Text.Trim();
                GlobalSettings.creatorSettings.threadAmount = int.Parse(ThreadAmountTextBox.Text.Trim());
                GlobalSettings.creatorSettings.createAmount = int.Parse(CreateAmountTextBox.Text.Trim());
                GlobalSettings.creatorSettings.rocketMapFormat = RocketMapCheckBox.Checked;
                GlobalSettings.creatorSettings.saveDB = SaveInDBCheckBox.Checked;

                await Task.Run(() => new Controller().Start());
            }
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            GlobalSettings.creatorSettings.api = ShuffleAPITextBox.Text.Trim();
            GlobalSettings.creatorSettings.domain = DomainTextBox.Text.Trim();
            GlobalSettings.creatorSettings.username = UsernameTextBox.Text.Trim();
            GlobalSettings.creatorSettings.password = PasswordTextBox.Text.Trim();
            try { GlobalSettings.creatorSettings.threadAmount = int.Parse(ThreadAmountTextBox.Text.Trim()); } catch { }
            try { GlobalSettings.creatorSettings.createAmount = int.Parse(CreateAmountTextBox.Text.Trim()); } catch { }
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
            else if (ThreadAmountTextBox.Text.Trim() == "" || !int.TryParse(ThreadAmountTextBox.Text.Trim(), out tester) || tester == 0)
            {
                MessageBox.Show("Please enter thread amount");
                return false;
            }
            else if (CreateAmountTextBox.Text.Trim() == "" || !int.TryParse(CreateAmountTextBox.Text.Trim(), out tester) || tester == 0)
            {
                MessageBox.Show("Please enter creation amount");
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
            if (GlobalSettings.proxyList.Count == 0 && GlobalSettings.webProxy.url == "")
            {
                MessageBox.Show("Please import proxies");
                return false;
            }
            #endregion

            return true;
        }
        
    }
}
