using Dotnet6MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet6MVC.Controllers
{
    public class TaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult NewTaxes(TaxViewModel taxData)
        {
            return View();
        }
    }
}
