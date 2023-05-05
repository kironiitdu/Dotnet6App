using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Controllers
{
    public class EmailControllerController : Controller
    {
       
        public async Task<IActionResult> SendInfoEmail()
        {
            EmailModel? model = new EmailModel { Subject = " Test Subject", Sender = new EmailPersonModel { Email = "sender@outlook.com", Name = "sender" }, Message = "Test Message", Recipients = new List<EmailPersonModel> { new EmailPersonModel { Email = "Recipient1@outlook.com", Name = "Recipient1" }, new EmailPersonModel { Email = "Recipient2@outlook.com", Name = "Recipient2" } } };

            TempData["EmailModel"] = model;
            return RedirectToAction("Index");
        }
        public IActionResult Index(EmailModel model)
        {
            var EmailDataString = TempData["EmailModel"].ToString();
            
            EmailModel emailModel = JsonConvert.DeserializeObject<EmailModel>(EmailDataString);
            return View(emailModel);
            
        }
    }
    public class EmailModel
    {
        [Required]
        public EmailPersonModel Sender { get; set; } = new EmailPersonModel();
        [Required]
        public List<EmailPersonModel> Recipients { get; set; } = new List<EmailPersonModel>();
        [Required]
        public string Subject { get; set; } = string.Empty;
        [Required]
        public string Message { get; set; } = string.Empty;
    }

    public class EmailPersonModel
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

}
