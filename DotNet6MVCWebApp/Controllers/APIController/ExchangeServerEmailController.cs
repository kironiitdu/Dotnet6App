using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Microsoft.Exchange.WebServices.Data;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeServerEmailController : ControllerBase
    {
      
        [HttpPost]
        public ActionResult<SchoolModel> SendExchangeEmail()
        {
            SendMail();
            ExchangeService _exchangeService = new ExchangeService(ExchangeVersion.Exchange2010_SP1);
            _exchangeService.Credentials = new NetworkCredential("uddin", "&StrongPass&1988@22jul", "Wicresoft");
            _exchangeService.AutodiscoverUrl("uddin@wicresoft.com");
            _exchangeService.TraceEnabled = true;
            EmailMessage message = new EmailMessage(_exchangeService);
            message.ToRecipients.Add("kironiitdu@outlook.com");
            // message.CcRecipients.Add(ccRecipients);
            message.Subject = "Test Subject"; // "Subject: Attendance Report (3.1-3.15)";
            message.Body = new MessageBody(BodyType.HTML, "<h1>Hello From Exchange Server</h1>");
            message.Send();
            return Ok();
        }
        public static void SendMail()
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                NetworkCredential basicCredential = new NetworkCredential("uddin", "&StrongPass&1988@22jul", "wicresoft.com");
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress("uddin@wicresoft.com");

                // setup up the host, increase the timeout to 5 minutes
                smtpClient.Host = "wicresoft.com";
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = basicCredential;
               // smtpClient.Timeout = (60 * 5 * 1000);

                message.From = fromAddress;
                message.Subject = "Test Exchange Server Subject";
                message.IsBodyHtml = true;
                message.Body = "<h1>Hello From Exchange Server</h1>";
                message.To.Add("v-mdud@microsoft.com");


                smtpClient.Send(message);
            }
            catch (Exception ex)
            {

                throw;
            }

           
        }
    }
}
