using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet6MVCWebApp.Controllers
{
    public class PaginationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public PaginationController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        public async Task<ActionResult> GetFileInformation()
        {
            //var fileName = "TestImage.jpg";
            //var path = Path.Combine(_environment.WebRootPath, "ImageName/Cover", fileName);

            //var lastModified = System.IO.File.GetLastWriteTime(path);


            var fileNameLocal = "TestImage.jpg";
            System.IO.FileInfo fi = null;
            fi = new FileInfo(fileNameLocal);
            var createdTime = fi.CreationTime.Date.ToString("yyyy-MM-dd");
            var lastAccessTime = fi.CreationTime;
            var lastWriteTime = fi.LastWriteTime;

            string fileCreatedDatey = System.IO.File.GetCreationTime(fileNameLocal).Date.ToString("yyyy-MM-dd");

            FileInfo fileInfo = new FileInfo(@"D:\OneDrive-Microsoft\Desktop\screenCapture.gif");

            DateTime lastModified = fileInfo.LastWriteTime;

            return Ok();
        }
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            var datas = await _context.Animals
                .Skip((page - 1) * take)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();

            int dataCount = await _context.Animals.CountAsync();
            int initCount = (int)Math.Ceiling((decimal)dataCount / take);

            Paginate<Animal> result = new Paginate<Animal>(datas, page, initCount);

            return View(result);
        }
    }
}
