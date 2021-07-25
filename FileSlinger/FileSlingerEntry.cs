using System;
using System.Threading;

namespace cc
{
    class FileSlingerEntry
    {
        static Emailer m_oEmailer = new Emailer(FileSlinger.Emailer.Default.smtp_server, FileSlinger.Emailer.Default.smtp_user, FileSlinger.Emailer.Default.smtp_password);
        /// <summary>
        /// Application entry point
        /// </summary>
        /// <param name="args">expecting one argument representing the directory that should be watched</param>
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Please supply the directory that should be watched...");
                return;
            }
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(FileSlingerException);             // add exception handler
            DirectoryWatcher.NewFileCallback oFileCallback = new DirectoryWatcher.NewFileCallback(ProcessNewFile);              // create the "new file" callback
            DirectoryWatcher oWatcher = new DirectoryWatcher(args[0], oFileCallback);
            Console.WriteLine("Press 'Any' key to exit...");                                                                    // pause to exit
            Console.ReadKey();
            oWatcher.Dispose();
        }
        /// <summary>
        /// Will be called by DirectoryWatcher when new file is detected in the watch directory
        /// The function emails the file to using the SMTP and user settings specified in the config file
        /// </summary>
        /// <param name="strFilePath">full path to a file that was found</param>
        static void ProcessNewFile(string strFilePath)
        {
            //Console.WriteLine("Will email a file at {0}", strFilePath);
            string strMessage = "Hi, FYI new file was found in the watched directory and it is attached...";
            string strSubject = "[FileSlinger] New File Alert";
            m_oEmailer.EmailFile(FileSlinger.Emailer.Default.email_to_address, FileSlinger.Emailer.Default.email_from_address, strMessage, strSubject, strFilePath);
        }
        /// <summary>
        /// Handles (reports) any un-caught exceptions in the application
        /// </summary>
        /// <param name="sender">The application domain that handled the System.AppDomain.UnhandledException event</param>
        /// <param name="args">event data</param>
        static void FileSlingerException(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("An exception has occured in the application: {0}:{1} ", e.Message, e.StackTrace);
        }
    }
}
