using System.Net.Mail;
using System.Net;
using Portfolio.Shared;
namespace Portfolio.Server
{
    public class EmailSender : IEmailSender
    {
        private IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = _configuration["Email:Address"];
            var pw = _configuration["Email:Password"];

            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };

            return client.SendMailAsync(
                new MailMessage(from: mail,
                to: email,
                subject,
                message
                ));
            
        }
    }
}