using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mjml.AspNetCore;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace Dotnet6App.Controllers
{
    [Route("api/MjmlEmailService")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        public readonly IMjmlServices _mjmlServices;
        public EmailController(IMjmlServices _mjml) => (_mjmlServices) = (_mjml);

    

        [HttpGet]
        public async Task<IActionResult> Send()
        {
            await MjmlEmailService();
            return Ok("Email has been sent");
        }
        public async Task MjmlEmailService()
        {
            var prehtml = "<mjml><mj-body><mj-container><mj-section><mj-column><mj-text>Hello From MJML Service By Kiron!</mj-text></mj-column></mj-section></mj-container></mj-body></mjml>";
            var result = await _mjmlServices.Render(prehtml);
            SmtpEmailProcessor(result.Html);
        }
        public void SmtpEmailProcessor(string emailBody)
        {
            try
            {
                SmtpClient objsmtp = new SmtpClient("smtp.gmail.com", 587);
                objsmtp.UseDefaultCredentials = false;
                objsmtp.Credentials = new NetworkCredential("Emaill", "Pass");
                objsmtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                objsmtp.EnableSsl = true;
                MailMessage msg = new MailMessage("dotnetkiron@gmail.com", "kironiitdu@outlook.com", "Subject: MJML Test For Harish", emailBody);
                msg.IsBodyHtml = true;
                objsmtp.Timeout = 50000;
                objsmtp.Send(msg);
            }
            catch (Exception ex) { }
        }
    }
}
