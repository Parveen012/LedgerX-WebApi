using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;

namespace Application.Services
{
    public class EmailService:IEmailService
    {
        private readonly IConfiguration  _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       public async Task SendEmail(string recipientEmail, string subject , string htmlbody)
        {
            try
            {
                var senderEmail = _configuration["EmailSettings:UserName"];
                string? senderPassword = _configuration["EmailSettings:Password"];
                var smtp = _configuration["EmailSettings:SmtpServer"];
                var port = int.Parse(_configuration["EmailSettings:Port"]);
                var displayName = _configuration["EmailSettings:DisplayName"];

                SmtpClient smtpClient = new SmtpClient(smtp)
                {
                    Port = port,
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true,
                };
                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress(recipientEmail);
                    message.To.Add(recipientEmail);
                    message.Subject = subject;
                    message.Body = htmlbody;
                    message.IsBodyHtml = true;
                    await smtpClient.SendMailAsync(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
