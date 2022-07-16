using ArrayToPdf;
using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using DotNet6MVCWebApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNet6MVCWebApp.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public ApplicationController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public class CheckBoxRequired : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                //get the entered value
                var application = (ApplicationFormViewModel)validationContext.ObjectInstance;
                //Check whether the IsAccepted is selected or not.
                if (application.AppAgreeToTerms == false)
                {
                    //if not checked the checkbox, return the error message.
                    return new ValidationResult(ErrorMessage == null ? "You must agree to the terms and condtions!" : ErrorMessage);
                }
                return ValidationResult.Success;
            }
        }
        public IActionResult Create()
        {
            ApplicationFormViewModel renterdropdownvm = new ApplicationFormViewModel()
            {
                States = _context.Categories.Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                }),
            };
            return View(renterdropdownvm);
        }

        public class CreateProductDto
        {
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public decimal price { get; set; }
            public DateTime created { get; set; }
            public int ProductCatID { get; set; }
            public string ImageUrl { get; set; }

        }
        public ActionResult DisplayPDFFromExistingFile()
        {
            string physicalPath = "wwwroot/KironGitHub.pdf";
            byte[] pdfBytes = System.IO.File.ReadAllBytes(physicalPath);
            MemoryStream ms = new MemoryStream(pdfBytes);
            return new FileStreamResult(ms, "application/pdf");

        }
        public ActionResult DisplayPdfOnBrowserFromDatabaseList()
        {
            //https://github.com/mustaddon/ArrayToPdf
            //https://www.nuget.org/packages/ArrayToPdf 
            var data = _context.Members.ToList();
            var pdf = data.ToPdf();
            MemoryStream ms = new MemoryStream(pdf);
            return new FileStreamResult(ms, "application/pdf");

        }
        public ActionResult DownloadPDFOnBrowser()
        {

            var data = _context.Members.ToList();
            var byteArray = data.ToPdf();

            MemoryStream stream = new MemoryStream(byteArray);

            string mimeType = "application/pdf";
            return new FileStreamResult(stream, mimeType)
            {
                FileDownloadName = "DatabaseListToPdf.pdf"
            };


        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto pro, IFormFile Image)
        {
            try
            {
                //Checking if the user uploaded the image correctly
                if (Image == null || Image.Length == 0)
                {
                    return Content("File not selected");
                }
                //Set the image location under WWWRoot folder. For example if you have the folder name image then you should set "image" in "FolderNameOfYourWWWRoot"
                var path = Path.Combine(_environment.WebRootPath, "FolderNameOfYourWWWRoot", Image.FileName);
                //Saving the image in that folder 
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                    stream.Close();
                }

                //Setting Image name in your product DTO
                //If you want to save image name then do like this But if you want to save image location then write assign the path 
                //pro.ImageUrl = Image.FileName;

                //var productEntity = _mapper.Map<Product>(pro);
                //var newProduct = _SqlService.AddProduct(productEntity);

                //var productForReturn = _mapper.Map<ProductDto>(newProduct);

                //return CreatedAtRoute("GetProduct", new { id = productForReturn.ProId },
                //    productForReturn);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationFormViewModel applicationVM)
        {
            if (ModelState.IsValid)
            {
                var applicationObj = new Application();
                {
                    applicationObj.AppFirstName = applicationVM.AppFirstName;
                    applicationObj.AppLastName = applicationVM.AppLastName;
                    applicationObj.StateId = applicationVM.StateId;
                    applicationObj.AppDateOfBirth = applicationVM.AppDateOfBirth;
                    applicationObj.AppTotalPersonsOccupy = applicationVM.AppTotalPersonsOccupy;
                    applicationObj.AppAgreeToTerms = applicationVM.AppAgreeToTerms;
                }

                //_db.Applications.Add(applicationObj);
                //await _db.SaveChangesAsync();

                var newlyCreatedId = applicationObj.ApplicationId;
                return RedirectToAction(nameof(Confirmation), new { id = newlyCreatedId });
            }

            // re-populate the dropdown field here before returning the view
            ApplicationFormViewModel applicationvmrepopulate = new ApplicationFormViewModel()
            {
                States = _context.Categories.Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                }),
            };

            return View(applicationvmrepopulate);
        }

        public async Task<IActionResult> Confirmation(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var appconfirm = await _context.Applications.SingleOrDefaultAsync(m => m.ApplicationId == id);

            //if (appconfirm == null)
            //{
            //    return NotFound();
            //}

            //return View(appconfirm);
            return View();
        }
    }
}
