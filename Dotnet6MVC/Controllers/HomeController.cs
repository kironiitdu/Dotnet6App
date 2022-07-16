using Dotnet6App.Models;
using Dotnet6MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dotnet6MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexAnother()
        {
            return View();
        }
        public IActionResult DoSomething(int state)
        {
            var viewModel = new SomeViewModel();

            if (state % 2 == 0)
                viewModel.State = state * 2;
            else
                viewModel.State = state;

            return View("MyView", viewModel);
}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}