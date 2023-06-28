using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class BoolToStringController : Controller
    {
        public IActionResult Index()
        {

            var listEmployee = new List<EmployeeInfo>()
            {
                new EmployeeInfo() { Empid=1,Empname="Dev", Empsalary=95000, Empgender = true },
                new EmployeeInfo() { Empid=2,Empname="Maria", Empsalary=75000, Empgender = false },
                new EmployeeInfo() { Empid=3,Empname="Tim", Empsalary=55000, Empgender = true }

            };
            return View(listEmployee);
        }
    }

    public class EmployeeInfo
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public Nullable<int> Empsalary { get; set; }
        public bool Empgender { get; set; }
    }

}
