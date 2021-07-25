using System;
using System.Net;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Collections.Generic;

namespace cc.Utility
{
    public class ccEmailer
    {
        /// <summary>
        /// Timur Kovalev (http://www.creativecodedesign.com): A class that allows email messages to be sent via SMTP
        /// </summary>
        string _serverAddress = null;
        string _serverUser = null;
        string _serverPassword = null;
        int _serverPort = 25;
        /// <summary>
        /// Instantiates the SMTP emailer class
        /// </summary>
        /// <param name="server">SMTP server that should be used</param>
        /// <param name="user">the username for the server</param>
        /// <param name="password">the password for the server</param>
        public ccEmailer(string server, string user, string password, int port = 25)
        {
            _serverAddress = server;
            _serverUser = user;
            _serverPassword = password;
            _serverPort = port;
        }
        /// <summary>
        /// Initializes the instance using application configuration
        /// </summary>
        public ccEmailer() : this(ccEmailerSettings.Default.smpt_server, ccEmailerSettings.Default.smtp_user, ccEmailerSettings.Default.smtp_password, ccEmailerSettings.Default.smtp_port) { }
        /// <summary>
        /// Sends a message with an attached file
        /// </summary>
        /// <param name="toAddress">the address to which the message should be sent</param>
        /// <param name="fromAddress">the address that should be used as the 'from' address</param>
        /// <param name="message">the body of the email</param>
        /// <param name="subject">the subject for the email</param>
        /// <param name="attachmentPath">full path to the file that should be attached to the email</param>
        public void EmailFile(string toAddress, string fromAddress, string message, string subject, string attachmentPath)
        {
            List<string> attachments = new List<string>();
            attachments.Add(attachmentPath);
            EmailFiles(toAddress, fromAddress, message, subject, attachments);
        }
        /// <summary>
        /// Emails multiple files to the destination
        /// </summary>
        /// <param name="toAddress">the address to which the message should be sent</param>
        /// <param name="fromAddress">the address that should be used as the 'from' address</param>
        /// <param name="message">the body of the email</param>
        /// <param name="subject">the subject for the email</param>
        /// <param name="attachmentPaths">list of full paths to the files that should be attached to the email</param>
        public void EmailFiles(string toAddress, string fromAddress, string message, string subject, List<string> attachmentPaths)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                NetworkCredential customCredentials = new NetworkCredential(_serverUser, _serverPassword);
                MailMessage mailMessage = new MailMessage();
                smtpClient.Host = _serverAddress;
                smtpClient.Port = _serverPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = customCredentials;
                smtpClient.EnableSsl = ccEmailerSettings.Default.use_ssl;
                mailMessage.From = new MailAddress(fromAddress);
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(toAddress);
                mailMessage.Body = message;
                try
                {
                  if (null != attachmentPaths)
                  {
                    foreach (string attachementPath in attachmentPaths)
                    {
                      Attachment currentFileAttachment = new Attachment(attachementPath);
                      mailMessage.Attachments.Add(currentFileAttachment);
                    }
                  }
                  smtpClient.Send(mailMessage);
                }
                finally
                {
                    foreach (Attachment currentAttachment in mailMessage.Attachments)
                        currentAttachment.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception has occured while trying to send an email - {0}:{1}", ex.Message, ex.StackTrace);
                Console.WriteLine("Server {0}\n User: {1}\n", _serverAddress, _serverUser);
            }
        }
    }
}
