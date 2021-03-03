using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BoardGames.Email
{
    /// <summary>
    /// Class to send emails
    /// </summary>
    public class EmailSender : IEmailSender
    {
        private string emailUser;
        private string emailPassword;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options">Email sender options</param>
        public EmailSender(IOptions<AuthMessageSenderOptions> options)
        {
            emailUser = options.Value.EmailUser;
            emailPassword = options.Value.EmailPassword;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email, subject, htmlMessage);
        }

        /// <summary>
        /// Execute sending an email
        /// </summary>
        /// <param name="email">Receiver's email address</param>
        /// <param name="subject">Subject line</param>
        /// <param name="message">email message body</param>
        /// <returns>A completed Task</returns>
        public Task Execute(string email, string subject, string message)
        {
            MailMessage msg = CreateMessage(email, subject, message);
            SendEmail(msg);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Creates the email message to send through the SMTP client
        /// </summary>
        /// <param name="email">Receiver's email address</param>
        /// <param name="subject">Subject line</param>
        /// <param name="message">email message body</param>
        /// <returns>The resulting mail message</returns>
        public MailMessage CreateMessage(string email, string subject, string message)
        {
            MailMessage msg = new MailMessage()
            {
                From = new MailAddress(emailUser),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };
            msg.To.Add(email);
            return msg;
        }

        private void SendEmail(MailMessage msg)
        {
            SmtpClient client = SetupGmailClient();
            client.Send(msg);
            msg.Dispose();
        }

        private SmtpClient SetupGmailClient()
        {
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(emailUser, emailPassword);
            client.Timeout = 20000;
            return client;
            
        }
    }
}
