using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC_Creator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.Reload();
            Properties.Settings.Default.Save();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CatchUnhandledException);
        }


        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("An object disposed exception has occured. A log will be written to log.txt" + Environment.NewLine
                + "Please submit it to github issues", "Fatal Error");

            try
            {
                File.WriteAllText("log.txt", e.Exception.ToString());
            }
            catch
            {
                MessageBox.Show(String.Format("Failed to write log file. Screenshot this exception:\n{0}", e.Exception.ToString()));
            }

            Application.Exit();
        }

        private static void CatchUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An object disposed exception has occured. A log will be written to log.txt" + Environment.NewLine
                + "Please submit it to github issues", "Fatal Error");

            try
            {
                File.WriteAllText("log.txt", e.ExceptionObject.ToString());
            }
            catch
            {
                MessageBox.Show(String.Format("Failed to write log file. Screenshot this exception:\n{0}", e.ExceptionObject.ToString()));
            }

            Application.Exit();
        }
    }
}
