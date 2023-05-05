using DotNet6MVCWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class InvalidObjectProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public InvalidObjectProductController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
    }
}
