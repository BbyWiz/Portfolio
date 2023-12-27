using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using Portfolio.Shared;


namespace Portfolio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmailController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IEmailSender _emailSender;
        public EmailController(IConfiguration configuration, IEmailSender emailSender)
        {
            _configuration = configuration;
            this._emailSender = emailSender;
        }


        [HttpPost("Send")] //send is a unique route
        public async Task<IActionResult> SendEmailAsync([FromBody] EmailObject emailModel)
        {
            try
            {
                using (var smtpClient = new SmtpClient("smtp.outlook.com", 587))
                {
                    var emailAddress = _configuration["Email:Address"];
                    var emailPassword = _configuration["Email:Password"];
                    var mailMessage = new MailMessage
                    {

                        From = new MailAddress(emailAddress),
                        Subject = emailModel.Subject,
                        Body = emailModel.Body,
                        IsBodyHtml = true,

                    };

                    mailMessage.To.Add(emailModel.To);

                    smtpClient.Credentials = new System.Net.NetworkCredential(emailAddress, emailPassword);
                    smtpClient.EnableSsl = true;

                    await smtpClient.SendMailAsync(mailMessage);
                }

                return Ok("Email sent successfully");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} | {ex.Source}");
                return StatusCode(500, "An error occurred while sending the email.");
            }
        }
       
            

        
    }
}