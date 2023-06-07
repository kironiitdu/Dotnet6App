using DotNet6MVCWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class AutocompleteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public AutocompleteController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetData(string searchKey)
        {
            var query = (from country in _context.Countries
                         where country.CountryName!.ToLower().Contains(searchKey.ToLower())
                         select country).ToList();

            return Json(query);
        }
    }
}
