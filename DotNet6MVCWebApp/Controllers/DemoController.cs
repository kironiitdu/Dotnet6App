using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet6MVCWebApp.Controllers
{
    public class DemoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DemoController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
          
            return View();
        }
       
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection dynamicData)
        {
                      
            var dynamicFormDataDictionary = new Dictionary<string, object>();

            foreach (var item in dynamicData)
            {

                dynamicFormDataDictionary.Add(item.Key, item.Value);
                dynamicFormDataDictionary.Remove("__RequestVerificationToken");
            }
           
            return View("Create", dynamicFormDataDictionary);
        }
        [HttpPost]
        public IActionResult Index(IFormFile files)
        {
            //if (files != null)
            //{
            //    if (files.Length > 0)
            //    {
            //        //Getting FileName
            //        var fileName = Path.GetFileName(files.FileName);
            //        //Getting file Extension
            //        var fileExtension = Path.GetExtension(fileName);
            //        // concatenating  FileName + FileExtension
            //        //var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
            //        var newFileName = String.Concat((Guid.NewGuid()), fileExtension);

            //        var objfiles = new Files()
            //        {
            //            DocumentId = 0,
            //            Name = newFileName,
            //            FileType = fileExtension,
            //        };

            //        using (var target = new MemoryStream())
            //        {
            //            files.CopyTo(target);
            //            //objfiles.DataFiles = target.ToArray();
            //        }

            //        _context.Files.Add(objfiles);
            //        _context.SaveChanges();
            //    }
            //}

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DownloadImage(string filename, int id)
        {
            if (filename == null)
                return Content("filename is not availble");
           // var file = await _context.Files.Where(x => x.DocumentId == id).FirstOrDefaultAsync();
            var path = Path.Combine(Directory.GetCurrentDirectory(), filename);
            var memory = new MemoryStream();
            {
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
        public IActionResult Search()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Search(string searchString)
        {
            //var FileController = from m in _context.Files
            //                     select m;

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    FileController = FileController.Where(s => s.Name!.Contains(searchString));
            //}

            //return View(await FileController.ToListAsync());
            return View();
        }
    }
}
