using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CreativeCode;

namespace SerialTray
{
    static class SerialTrayEntry
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            ccUpdateChecker oASyncChecker = new ccUpdateChecker("http://www.creativecodedesign.com/software/ccCheckForUpdates.php?app=SerialTray");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SerialTrayForm());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            MessageBox.Show(string.Format("An exception has occured in the application {0}-{1}!. Cannot continue.", ex.Message, ex.StackTrace), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }
}
