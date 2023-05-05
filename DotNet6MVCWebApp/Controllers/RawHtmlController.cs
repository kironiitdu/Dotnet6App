using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class RawHtmlController : Controller
    {
        public IActionResult Index()
        {
           
            ViewBag.message = "<h3> Something went terribly wrong, please try again or contact us at <a href='mailto:info@abc.we'>info@abc.we</a> </h3>";
            return View();
        }
    }
}
