using System.Net.Mail;
using System.Net;
using SMTPFileTransfer.Models;
using Microsoft.Extensions.Options;

namespace SMTPFileTransfer.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfiguration;

        public EmailService(IOptions<EmailConfiguration> emailConfiguration)
        {
            _emailConfiguration = emailConfiguration.Value;
        }

        public async Task SendEmailAsync(FormData formData, string[] filePaths)
        {
            using (var message = new MailMessage())
            {
                message.From = new MailAddress(_emailConfiguration.From);
                message.To.Add(formData.Email);
                message.Subject = "Нові дані від користувача";
                message.Body = $"Ім'я: {formData.Name}\nEmail: {formData.Email}\nТелефон: {formData.PhoneNumber}\nАдреса: {formData.Address}\nПослуга: {formData.Service}\nДата: {formData.ChooseDate}\nДетальна інформація: {formData.DetailedInformation}";

                foreach (var filePath in filePaths)
                {
                    var attachment = new Attachment(filePath);
                    message.Attachments.Add(attachment);
                }

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Host = _emailConfiguration.SmtpServer;
                    smtpClient.Port = _emailConfiguration.SmtpPort;
                    smtpClient.EnableSsl = true;

                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(_emailConfiguration.UserName, _emailConfiguration.Password);

                    await smtpClient.SendMailAsync(message);
                }
            }
        }
    }

}
