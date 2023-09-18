using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Controllers
{
    public class ModelStateValidationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RequesterIndex(TestValidationModel user)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }


    public class TestValidationModel
    {
        [Required(ErrorMessage = "Name field is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }


    
}
