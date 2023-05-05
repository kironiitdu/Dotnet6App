using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class ReadOnlyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    public class TestViewModel
    {

        public string? QuantidadeProduto { get; set; }

        public string? Pro { get; set; }

       

    }
}
