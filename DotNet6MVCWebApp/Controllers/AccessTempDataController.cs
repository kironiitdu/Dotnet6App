using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class AccessTempDataController : Controller
    {
        public IActionResult Index()
        {
            TempData["FromComTaskLibType"] = "Anything from controller".ToString();
            ViewBag.Value = "Anything from controller";
          
            return View();
        }
        public ActionResult LoginFromCOM(string libType)
        {
            TempData["FromComTaskLibType"] = libType;
           return View();
        }
    }
}
