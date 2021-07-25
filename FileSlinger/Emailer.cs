using System;
using System.Net;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Collections.Generic;

namespace cc
{
    /// <summary>
    /// Timur Kovalev (http://www.creativecodedesign.com): A class that allows email messages to be sent via SMTP
    /// </summary>
    public class Emailer
    {
        string m_strServer = null;
        string m_strUser = null;
        string m_strPassword = null;
        /// <summary>
        /// Instantiates the SMTP emailer class
        /// </summary>
        /// <param name="strServer">SMTP server that should be used</param>
        /// <param name="strUser">the username for the server</param>
        /// <param name="strPassword">the password for the server</param>
        public Emailer(string strServer, string strUser, string strPassword)
        {
            m_strServer = strServer;
            m_strUser = strUser;
            m_strPassword = strPassword;
        }       
        /// <summary>
        /// Sends a message with an attached file
        /// </summary>
        /// <param name="strToAddress">the address to which the message should be sent</param>
        /// <param name="strFromAddress">the address that should be used as the 'from' address</param>
        /// <param name="strMessage">the body of the email</param>
        /// <param name="strSubject">the subject for the email</param>
        /// <param name="strFileName">full path to the file that should be attached to the email</param>
        public void EmailFile(string strToAddress, string strFromAddress, string strMessage, string strSubject, string strFileName)
        {
            try
            {                
                SmtpClient smtpClient = new SmtpClient();
                NetworkCredential customCredentials = new NetworkCredential(m_strUser, m_strPassword);
                MailMessage message = new MailMessage();
                smtpClient.Host = m_strServer;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = customCredentials;
                message.From = new MailAddress(strFromAddress);
                message.Subject = strSubject;
                message.IsBodyHtml = true;
                message.To.Add(strToAddress);
                message.Body = strMessage;                
                using(Attachment oAttachedFile = new Attachment(strFileName))
                {
                    message.Attachments.Add(oAttachedFile);
                    smtpClient.Send(message);      
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception has occured while trying to send an email - {0}:{1}", ex.Message, ex.StackTrace);
                Console.WriteLine("Server {0}\n User: {1}\n", m_strServer, m_strUser);
            }
        }
    }
}
