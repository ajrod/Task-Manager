//Copyright (C) 2013 <copyright holders>
//
//Permission is hereby granted, free of charge, to any person obtaining a copy of this 
//software and associated documentation files (the "Software"), to deal in the Software without 
//restriction, including without limitation the rights to use, copy, modify, merge, publish, 
//distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom 
//the Software is furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all copies or 
//substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
//INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
//PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR 
//ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
//ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE 
//SOFTWARE.

//Author: Alex Rodrigues

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