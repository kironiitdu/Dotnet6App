using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2010.Excel;
using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace DotNet6MVCWebApp.Controllers
{
    public class EmployeeCompanyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeCompanyController( ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<EmployeeModel> employees = _context.Employees.ToList();
            List<CompanyModel> companies = _context.Companies.ToList();

            var employeeRecord = from e in employees
                                 join d in companies on e.CompanyId equals d.CompanyId
                                 select new ViewModel
                                 {
                                     employee =e,
                                     companies = d,
                                 };


            return View(employeeRecord);

        }
    }

    public class ViewModel
    {
        public EmployeeModel employee { get; set; }
        public CompanyModel companies { get; set; }
    }

}
