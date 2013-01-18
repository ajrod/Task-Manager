// -----------------------------------------------------------------------
// Author: Alexander Rodrigues
// -----------------------------------------------------------------------

using System;
using System.Net.Mail;

namespace Task_Manager
{
    /// <summary>
    /// A utility class for sending emails.
    /// </summary>
    public class Email
    {
        private SmtpClient SmtpServer;
        /// <summary>
        /// The email of the task manager.
        /// </summary>
        private const string taskManagerEmail = "task.manager.notify@gmail.com";
        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class.
        /// </summary>
        public Email()
        {
            SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            //i really don't care if some one steals these credentials
            SmtpServer.Credentials = new System.Net.NetworkCredential(taskManagerEmail, "taskmanager");
            SmtpServer.EnableSsl = true;
        }

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="Body">The body of the email.</param>
        /// <param name="emailRecipient">The email recipient.</param>
        /// <param name="emailSuccessful">if set to <c>true</c> [email was successful].</param>
        public void Send(String subject, String Body, String emailRecipient, ref bool emailSuccessful)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(taskManagerEmail);
                mail.To.Add(emailRecipient);
                mail.Subject = subject;
                mail.Body = Body;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                emailSuccessful = false;
            }
        }
    }
}