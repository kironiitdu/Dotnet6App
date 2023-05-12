using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.Entity.Infrastructure;

namespace DotNet6MVCWebApp.Controllers
{
    public class DatatableInAnotherWayController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor? _httpContextAccessor;

        public DatatableInAnotherWayController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            string CurrentUserName = httpContextAccessor.HttpContext?.User.Identity?.Name;
        }

      

       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult IndexDataTableIssue()
        {
            string user = HttpContext.User.Identity?.Name;  
            return View();
        }
        [HttpPost]
        public IEnumerable<tblUserAuditTrails> UserAuditTrail()
        {

            List<tblUserAuditTrails> ListOfUserAudit = new List<tblUserAuditTrails>()
            {
                new tblUserAuditTrails(){ fld_ID = 1, fld_CreatedBy = "A", fld_UserActivity = "Activity-1", fld_CreatedDT = DateTime.Now},
                new tblUserAuditTrails(){ fld_ID = 2, fld_CreatedBy = "B", fld_UserActivity = "Activity-2", fld_CreatedDT = DateTime.Now},
                new tblUserAuditTrails(){ fld_ID = 3, fld_CreatedBy = "C", fld_UserActivity = "Activity-3", fld_CreatedDT = DateTime.Now},
                new tblUserAuditTrails(){ fld_ID = 4, fld_CreatedBy = "D", fld_UserActivity = "Activity-3", fld_CreatedDT = DateTime.Now},


            };
            return ListOfUserAudit;

        }
        public ActionResult GetList()
        {
            var empList = new List<Employee>()
            {
                new Employee(){ EmployeeId = 1, Name = "A", Age = 19, Position = "Engineer-I"},
                new Employee(){ EmployeeId = 2, Name = "B", Age = 20, Position = "Engineer-II"},
                new Employee(){ EmployeeId = 3, Name = "C", Age = 21, Position = "Engineer-I"},
                new Employee(){ EmployeeId = 4, Name = "D", Age = 22, Position = "Engineer-III"},
               

            };
           
          return Json(empList);
         
        }
    }

    public class tblUserAuditTrails
    {
        public int fld_ID { get; set; }
        public string fld_CreatedBy { get; set; }
        public string fld_UserActivity { get; set; }
        public DateTime fld_CreatedDT { get; set; }
    }
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
    }

}
