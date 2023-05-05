using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Infrastructure;

namespace DotNet6MVCWebApp.Controllers
{
    public class DatatableInAnotherWayController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
    }

}
