using Dotnet6MVC.IRepository;
using Dotnet6MVC.Models;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dotnet6MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMvcControllerDiscovery _mvcControllerDiscovery;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, IMvcControllerDiscovery mvcControllerDiscovery, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _mvcControllerDiscovery = mvcControllerDiscovery;   
            _hostingEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            

            var getLocalDate = _mvcControllerDiscovery.GetLocalDate();
            ViewBag.date = getLocalDate;
            return View();
        }


        [HttpPost]
        public IActionResult Create()
        {


            var getLocalDate = _mvcControllerDiscovery.GetLocalDate();
            ViewBag.date = getLocalDate;
            return View();
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