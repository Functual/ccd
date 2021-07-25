using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ccScreenSpy
{
    static class ccScreenSpyMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionSwallower);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ccScreenSpy());
        }

        /// <summary>
        /// Quietly exits
        /// </summary>
        /// <param name="sender">The application domain that handled the System.AppDomain.UnhandledException event</param>
        /// <param name="args">event data</param>
        static void UnhandledExceptionSwallower(object sender, UnhandledExceptionEventArgs args)
        {
            Application.Exit();            
        }
    }
}
