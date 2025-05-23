using Services.Interfaces;
using System.Net.Mail;
using System.Net;

namespace Services.Implementations
{
    public class EmailSender: IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fromEmail = "baosonnguyenduc@gmail.com";
            var password = "syjirmuzjfbqrgtj";

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, password),
                EnableSsl = true,
            };

            var message = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true,
            };

            message.To.Add(email);

            return smtpClient.SendMailAsync(message);
        }
    }
}
