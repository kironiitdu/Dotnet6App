
using Dotnet6MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet6MVC.Controllers
{
    public class ModelStateAlwaysTrueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {

            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            return RedirectToAction("Index");
        }
    }
}
