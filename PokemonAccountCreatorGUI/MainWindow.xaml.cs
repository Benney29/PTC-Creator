using PokemonAccountCreatorGUI.Classes;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace PokemonAccountCreatorGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static MainWindow main;

        Thread MainCreationThread;

        public MainWindow()
        {
            InitializeComponent();

            // Loading saved application setting
            main = this;
            ShuffleAPI.Text = app.Default.ShuffleAPI;
            AntiCaptchaAPI.Text = app.Default.AntiCaptchaAPI;
            domainTextBox.Text = app.Default.Domain;
            usernamePrefixTextBox.Text = app.Default.UsernamePrefix;
            passwordTextBox.Text = app.Default.Password;
            passwordCheckBox.IsChecked = app.Default.ConstantPassword;
            FileProxyExtraction.Text = app.Default.proxyFilePath;
            addToDB.IsChecked = app.Default.addToDB;

            if (File.Exists(app.Default.ProxyAPI))
            {
                FileProxyExtraction.Text = app.Default.ProxyAPI;
                ProxyExtractionAPI.Text = "";
            }
            else
            {
                ProxyExtractionAPI.Text = app.Default.ProxyAPI;
            }
            CreateAmount.Text = app.Default.CreateAmount.ToString();
            StaticVars.init();
        }

        /**
         * Update UI component from other threads.
         * **/
        // Label text
        internal string SuccessLabelText
        {
            get { return SuccessLabel.Content.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { SuccessLabel.Content = value; })); }
        }
        internal string FailLabelText
        {
            get { return FailLabel.Content.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { FailLabel.Content = value; })); }
        }
        internal string TotalLabelText
        {
            get { return TotalLabel.Content.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { TotalLabel.Content = value; })); }
        }
        internal string RateLabelText
        {
            get { return RateLabel.Content.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { RateLabel.Content = value; })); }
        }

        //Log window text
        internal string LogText
        {
            get { return LogBox.Text.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { LogBox.Text = value; LogBox.Focus(); LogBox.CaretIndex = value.Length; LogScroll.ScrollToBottom(); })); }
        }
        internal string VerifiedLogText
        {
            get { return VerifiedLogBox.Text.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { VerifiedLogBox.Text = value; VerifiedLogBox.Focus(); VerifiedLogBox.CaretIndex = value.Length; VerifiedLogBoxScroll.ScrollToBottom(); })); }
        }
        internal string UnverifiedLogText
        {
            get { return UnverifiedLogBox.Text.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { UnverifiedLogBox.Text = value; UnverifiedLogBox.Focus(); UnverifiedLogBox.CaretIndex = value.Length; UnverifiedLogBoxScroll.ScrollToBottom(); })); }
        }
        internal string PasswordChangeLogBoxText
        {
            get { return PasswordChangeLogBox.Text.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { PasswordChangeLogBox.Text = value; PasswordChangeLogBox.Focus(); PasswordChangeLogBox.CaretIndex = value.Length; PasswordChangeLogScroll.ScrollToBottom(); })); }
        }

        //Button text
        internal string VerifyButtonText
        {
            get { return VerificationFileSelectButton.Content.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { VerificationFileSelectButton.Content = value; })); }
        }
        internal string StartPasswordChangeButtonText
        {
            get { return StartPasswordChangeButton.Content.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { StartPasswordChangeButton.Content = value; })); }
        }
        internal string StartButtonText
        {
            get { return StartButton.Content.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { StartButton.Content = value; })); }
        }

        //GroupBox
        internal string VerifyGroupBoxText
        {
            get { return VerifiedGroupBox.Header.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { VerifiedGroupBox.Header = value; })); }
        }

        internal string UnverifyGroupBoxText
        {
            get { return UnverifiedGroupBox.Header.ToString(); }
            set { Dispatcher.Invoke(new Action(() => { UnverifiedGroupBox.Header = value; })); }
        }

        //Contact me
        private void Discord_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://discord.gg/qGVsEvV");
        }

        private void PurchaseAPI_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://selly.gg/p/2ff1df4b");
        }

        private void PurchaseAntiAPI_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://getcaptchasolution.com/18ymx4yh2b");
        }

        private void PurchaseTwoCaptchaAPI_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://2captcha.com/?from=2159674");
        }

        //Once start button clicked.
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (StartButton.Content.ToString() == "Start")
            {

                StaticVars.stop = false;
                if (checkInfo())
                {
                    LogText = "Starting..." + Environment.NewLine;
                    StaticVars.threadA = int.Parse(threadAmount.Text.Trim());
                    StaticVars.AntiAPI = AntiCaptchaAPI.Text.Trim();
                    StaticVars.ShuffleAPI = ShuffleAPI.Text.Trim();
                    StaticVars.domain = domainTextBox.Text.Trim();
                    StaticVars.proxyAPI = ProxyExtractionAPI.Text.Trim();
                    StaticVars.fileProxy = FileProxyExtraction.Text.Trim();
                    StaticVars.Amount = int.Parse(CreateAmount.Text.ToString());
                    StaticVars.rocketMapOutPut = (bool)rocketMap.IsChecked;
                    StaticVars.addToDB = (bool)addToDB.IsChecked;
                    if (usernamePrefixTextBox.Text != "")
                    {
                        StaticVars.usernamePrefix = usernamePrefixTextBox.Text.Trim();
                    }
                    if ((bool)passwordCheckBox.IsChecked)
                    {
                        StaticVars.password = passwordTextBox.Text.Trim();
                    }
                    MainCreationThread = new Thread(new Controller().main);
                    MainCreationThread.SetApartmentState(ApartmentState.STA);
                    MainCreationThread.Name = "Main Controller Thread";
                    MainCreationThread.Start();
                    StartButton.Content = "Stop";
                }
            }
            else
            {
                StartButton.Content = "Hold on...";
                StaticVars.stop = true;
            }
        }

        //Validation process check all neccessary info are entered.
        private bool checkInfo()
        {
            try
            {
                int checkThreadAmount;
                if (AntiCaptchaAPI.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter captcha service API key...");
                    return false;
                }
                else if (domainTextBox.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter your account domain..." + Environment.NewLine + "If you don't have one, please contact ShuffleTanker to buy one...");
                    return false;
                }
                else if ((bool)passwordCheckBox.IsChecked && (passwordTextBox.Text.Trim() == "" || !passwordCheck()))
                {
                    MessageBox.Show("Please enter your desired password... Or you can uncheck \"Constant Password\"...");
                    return false;
                }
                else if (!int.TryParse(threadAmount.Text.Trim(), out checkThreadAmount) || checkThreadAmount < 1)
                {
                    MessageBox.Show("Please enter thread amount. Minimum is 1...");
                    return false;
                }
                else if (ProxyExtractionAPI.Text.Trim() == "" && FileProxyExtraction.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter your proxy extraction API." + Environment.NewLine +
                        "Please Check ReadMe.txt");
                    return false;
                }
                else if (CreateAmount.Text.Trim() == "" || CreateAmount.Text.Trim() == "0" || !int.TryParse(CreateAmount.Text.Trim().ToString(), out StaticVars.Amount))
                {
                    MessageBox.Show("Create Amount Error");
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
            
        }

        //Niantic has some specific password requirements. This one is used to check whether things are good to go.
        private bool passwordCheck()
        {
            return passwordTextBox.Text.Any(char.IsUpper) && passwordTextBox.Text.Any(char.IsLower) && passwordTextBox.Text.Any(char.IsDigit) && passwordTextBox.Text.Any(ch => !char.IsLetterOrDigit(ch));
        }

        //Save application settings on exit.
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                foreach (Thread t in Controller.threadList)
                {
                    if (t.IsAlive)
                    {
                        t.Abort();
                    }
                }
            }
            catch { }
            app.Default.ShuffleAPI = ShuffleAPI.Text.Trim();
            app.Default.AntiCaptchaAPI = AntiCaptchaAPI.Text.Trim();
            app.Default.Domain = domainTextBox.Text.Trim();
            app.Default.UsernamePrefix = usernamePrefixTextBox.Text.Trim();
            app.Default.Password = passwordTextBox.Text.Trim();
            app.Default.ConstantPassword = (bool)passwordCheckBox.IsChecked;
            app.Default.ProxyAPI = ProxyExtractionAPI.Text.Trim().ToString();
            app.Default.CreateAmount = int.Parse(CreateAmount.Text.Trim().ToString());
            app.Default.proxyFilePath = FileProxyExtraction.Text.Trim();
            app.Default.addToDB = (bool)addToDB.IsChecked;
            app.Default.Save();
            Environment.Exit(0);
        }

        //Load file content and pass data to verification.cs
        private void VerificationFileSelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (VerificationFileSelectButton.Content.ToString() == "Select File")
            {
                StaticVars.stop = false;
                var fileDialog = new System.Windows.Forms.OpenFileDialog();
                fileDialog.Filter = "TXT files|*.txt";
                var result = fileDialog.ShowDialog();
                switch (result)
                {
                    case System.Windows.Forms.DialogResult.OK:
                        string file = fileDialog.FileName;
                        VerificationFileSelectButton.Content = "Hold on... Checking";
                        Verification v = new Verification(file);
                        Thread t = new Thread(v.doWork);
                        t.SetApartmentState(ApartmentState.STA);
                        t.Name = "Verification Thread";
                        t.Start();
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                    default:
                        MessageBox.Show("Error");
                        break;
                }
            }
            else if (VerificationFileSelectButton.Content.ToString() == "Hold on... Checking")
            {
                StaticVars.stop = true;
                VerificationFileSelectButton.Content = "Hold on... Stopping";
            }
        }

        private void PasswordChangeSelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            fileDialog.Filter = "TXT files|*.txt";
            var result = fileDialog.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    string file = fileDialog.FileName;
                    PasswordChangeFilePath.Content = file;
                    PasswordChangeFilePath.Visibility = Visibility.Visible;
                    StartPasswordChangeButton.IsEnabled = true;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    MessageBox.Show("Error");
                    break;
            }
        }

        private void StartPasswordChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (StartPasswordChangeButton.Content.ToString() == "Stop")
            {
                StaticVars.stop = true;
                StartPasswordChangeButton.Content = "Hold on... Stopping";
            }
            else
            {
                StaticVars.stop = false;
                if (!File.Exists(PasswordChangeFilePath.Content.ToString()))
                {
                    MessageBox.Show("Cannot found file: " + PasswordChangeFilePath.Content.ToString());
                    return;
                }
                PasswordChange p = new PasswordChange(PasswordChangeFilePath.Content.ToString(), (bool)PasswordChangePasswordCheckBox.IsChecked, PasswordChangePasswordTextBox.Text.ToString());
                Thread t = new Thread(p.doWork);
                t.Name = "Password Change Main Thread";
                t.Start();
                StartPasswordChangeButton.Content = "Stop";
            }
        }
        
        private void threadAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            lock (StaticVars.threadA.ToString())
            {
                int.TryParse(threadAmount.Text.Trim(), out StaticVars.threadA);
            }
        }

        private void UpdateAmount_Click(object sender, RoutedEventArgs e)
        {
            StaticVars.Amount = int.Parse(CreateAmount.Text);
        }

    }

}
