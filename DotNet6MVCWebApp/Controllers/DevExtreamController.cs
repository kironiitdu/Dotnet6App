using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class DevExtreamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
