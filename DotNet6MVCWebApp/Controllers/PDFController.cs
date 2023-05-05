using ArrayToPdf;
using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Static;
using Itenso.TimePeriod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;

namespace DotNet6MVCWebApp.Controllers
{
    public class PDFController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public PDFController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public IActionResult Index()
        {
            
            using (MemoryStream stream = new MemoryStream())
            {

                string embed = "<object data=\"{0}\" id=\"MyPDFDocs\" type=\"application/pdf\" width=\"1000px\" height=\"600px\">";
                embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
                embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
                embed += "</object>";

                TempData["Embed"] = string.Format(embed, "/Documents/Cambridge-IELTS-15-General.pdf");
                return View();
            }

        }

        //  [HttpPost]
        public ActionResult ViewPDF()
        {



            string physicalPath = "wwwroot/Documents/Cambridge-IELTS-15-General.pdf";
            byte[] pdfBytes = System.IO.File.ReadAllBytes(physicalPath);
            MemoryStream stream = new MemoryStream(pdfBytes);

            string mimeType = "application/pdf";
            return new FileStreamResult(stream, mimeType)
            {
                FileDownloadName = "LargePDF.pdf"
            };

        }



        public ActionResult SessionTestingController(string personToAdd)
        {
            var personObj = new SessionObject()
            {
                DisplayName = personToAdd
            };

            HttpContext.Session.SetComplexObjectSession("MyKey", personObj);

            var objFromSession = HttpContext.Session.GetComplexObjectSession<SessionObject>("MyKey");

            return Ok(objFromSession);
        }

        [HttpPost("{id}/features")]
        public ActionResult<bool> AddFeatureAsync(Guid Id, [FromBody] AddRoleFeatureRequest request)
        {

            var myNewId = new Guid();
            Console.WriteLine(request.Name);
            Console.WriteLine(request.Description);
            Console.WriteLine(request.Id);

            return true;
        }



    }

    public class AddRoleFeatureRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
    public class SessionObject
    {
        public string DisplayName { get; set; }
    }
}
