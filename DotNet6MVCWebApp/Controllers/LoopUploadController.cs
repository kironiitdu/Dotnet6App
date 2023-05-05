using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Graph;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace DotNet6MVCWebApp.Controllers
{
    public class LoopUploadController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly LinkGenerator _linkGenerator;
       

        public LoopUploadController(IWebHostEnvironment environment, ApplicationDbContext context, LinkGenerator linkGenerator)
        {
            _environment = environment;
            _context = context;
            _linkGenerator = linkGenerator;
            
        }

        public IActionResult UploadButNoRefresh()
        {
            

            UrlActionContext urlActionContext = new UrlActionContext();
            urlActionContext.Controller = "Animal";
            urlActionContext.Action = "MemberList";
            var url = _linkGenerator.GetUriByAction(HttpContext, action: urlActionContext.Action, controller: urlActionContext.Controller, null, HttpContext.Request.Scheme);

            if (url !=null)
            {
                return Redirect(url);
            }
            return View();
        }
        public IActionResult Index()
        {
            var taxList = new List<TaxParvande>()
                    {
                        new TaxParvande(){ state = true, prosessName = "Add", prosessId = 1 },
                        new TaxParvande(){ state =false, prosessName = "Edit", prosessId = 2 },
                        new TaxParvande(){ state = true, prosessName = "Delete", prosessId = 3},

                    };
            return View(taxList);
        }
        public IActionResult UploadImageFile(IEnumerable<IFormFile> filearray, String path)
        {

            //   String fileName = _uploadFiles.UploadFilesFunc(filearray, path);
            string? fileName = filearray.FirstOrDefault()?.FileName;

            return Json(new { status = "success", imagename = fileName });

        }

        public async Task<IActionResult> AutoFileUpload(IEnumerable<IFormFile> filearray, String path)
        {



            if (filearray.FirstOrDefault().FileName == null)
            {
                return Content("File not selected");
            }


            var filePath = Path.Combine(_environment.WebRootPath, "Documents", filearray.FirstOrDefault()?.FileName);
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await filearray.FirstOrDefault().CopyToAsync(stream);
                stream.Close();
            }

            return Json(new { status = "success", imagename = filearray.FirstOrDefault()?.FileName });

        }
        [HttpPost]
        public async Task<IActionResult> SabtEditTaxParvanedAsync([FromForm] IEnumerable<TaxParvande> taxParvandes)
        {
            if (taxParvandes == null)
            {
                return Content("File not selected");
            }
            foreach (var item in taxParvandes)
            {

                var checkDuplicateFile = System.IO.Path.Combine(_environment.WebRootPath, "Documents", item.prosessMastand.FileName);

                if (item.prosessMastand == null)
                {
                    continue;
                }


                var path = Path.Combine(_environment.WebRootPath, "Documents", item.prosessMastand.FileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await item.prosessMastand.CopyToAsync(stream);
                    stream.Close();
                }


                var taxDomainModel = new TaxDomainModel
                {
                    prosessName = item.prosessName,
                    state = item.state,
                    filePath = path,
                };
                _context.Add(taxDomainModel);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction("Index");
        }
        public IActionResult UploadFileUsingJQueryAJAX()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFileUsingJQueryAJAX(EmployeeUpload emp)
        {
            return View();
        }

    }
    public class EmployeeUpload
    {
        public int EmpId { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public IFormFile postedFile { get; set; }
    }
    public class TaxDomainModel
    {
        [Key]
        public int prosessId { get; set; }
        public bool state { get; set; }
        public string? prosessName { get; set; }
        public string? filePath { get; set; }
    }


}
