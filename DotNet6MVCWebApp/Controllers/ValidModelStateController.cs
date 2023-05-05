using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace DotNet6MVCWebApp.Controllers
{
    public class ValidModelStateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Page2(GenericModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }

    public class GenericModel
    {

       
        public string Id { get; set; }
        [Required(ErrorMessage = "A valid Name is required.")]
        public string Name { get; set; }
    }
}
