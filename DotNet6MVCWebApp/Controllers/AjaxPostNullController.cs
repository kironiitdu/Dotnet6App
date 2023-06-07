using AspNetCore.Unobtrusive.Ajax;
using DocumentFormat.OpenXml.Office2010.Excel;
using DotNet6MVCWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Net;
using System.Security.Policy;

namespace DotNet6MVCWebApp.Controllers
{
    public class AjaxPostNullController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public AjaxPostNullController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexNew()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetCustomer(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { msg = "Error in the request." });
            }
            var customer = _context.Students.Find(id);
            return Json(customer);
        }
        public IActionResult ViewIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetItemsForRelease(RequestModel requestModel)
        {
            return PartialView("_partialReleaseItem", requestModel);
        }

        [HttpPost]
        public IActionResult AjaxReject([FromBody] ListModel testModel)
        {
            var listOfIds = testModel?.ListOfIds; // testModel is null and ListOfIds is null

            return Ok(listOfIds);
        }

        public IActionResult ProcessFoo()
        {
            return View();
        }

        public IActionResult ProcessFooAction()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ProcessFoo([FromBody] Foo foo)
        {
            return Json(foo);
        }
        [HttpGet]
        public IActionResult SummaryReportView()
        {
            return View();
        }

        public IActionResult NewAjaxIssue()
        {
            return View();
        }

        public ActionResult DepAct([FromBody] List<DepTB> selectedDep)
        {
            var checkRequest = HttpContext.Request;

            var isAjax = checkRequest.IsAjaxRequest();
            // Process data as needed
            return new JsonResult(new { success = true });
        }

        [HttpGet]
        public IActionResult SummaryReport(string fleets)
        {
            List<FleetSummViewModel> retrieveObjeect = JsonConvert.DeserializeObject<List<FleetSummViewModel>>(fleets);
            // List<FleetSummViewModel> retrieveObjeect  =  JsonSerializer.Deserialize<List<FleetSummViewModel>>((string)fleets);
            return Ok(retrieveObjeect.Take(3));
        }

        [HttpPost]
        public IActionResult Verificar(string correoPropietario)
        {
            // var verificarCorreo = _PropiedadesData.Verificar(correoPropietario);

            //  return Json(verificarCorreo);

            var customer = _context.Teams.Where(tm => tm.Coach == correoPropietario).FirstOrDefault().TeamName;
            return Json(customer);
        }

        public IActionResult GetResponseFromAjax()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Tire(string Name)
        //{
        //    string p = Name;
        //    return View("Tires");
        //}
        [HttpPost]
        public ActionResult Tire([FromBody] CustomModel requestModel)
        {
            string p = requestModel.Name;
            return View("Tires");
        }
        public ActionResult Tire()
        {
            return View();
        }
    }

    public class DepTB
    {
        public string prop1 { get; set; }
        public string prop2 { get; set; }
    }
    public class CustomModel
    {
        public string Name { get; set; }
    }
    public class FleetSummViewModel
    {

        public string CustomerCode { get; set; }
        public string RegNo { get; set; }
        public string FleetNo { get; set; }
        //public string Depot { get; set; }
        // public string FleetDate { get; set; }
    }
    public class Foo
    {
        public int Id { get; set; }
        public List<Thing> Things { get; set; }

    }

    public class Thing
    {
        public string Name { get; set; }
    }

    public class RequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class ListModel
    {
        public List<int> ListOfIds { get; set; }
    }

}
