using DotNet_3_1_Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNet_3_1_Core.Controllers
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
