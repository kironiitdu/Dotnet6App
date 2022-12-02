using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class ModalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
