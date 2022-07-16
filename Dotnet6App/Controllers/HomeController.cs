using Microsoft.AspNetCore.Mvc;

namespace Dotnet6App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
