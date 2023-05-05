using DotNet6MVCWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace DotNet6MVCWebApp.Controllers
{
    public class ImageNotBindController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public ImageNotBindController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _hostEnvironment = environment;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ImageFile")] TestAssetViewModel model)
        {
            var wwwRootPath = _hostEnvironment.WebRootPath;
            return Ok();

        }
    }

    public class TestAssetViewModel
    {

        public string? FileName { get; set; }

        public string? FileUri { get; set; }

        public IFormFile ImageFile { get; set; }

    }

}
