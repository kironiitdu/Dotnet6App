using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Middleware;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _appDbContext;


        public StudentController(ApplicationDbContext studentDbContext)
        {
            _appDbContext = studentDbContext;
        }

        // GET: api/<EmployeeController>
       
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            // var studens = studentDbContext.Student;
            return _appDbContext.Students.ToList();

        }
       
        [HttpGet("Getbyid")]
        public ActionResult<Employeedatum> Getbyid(int EmployeeId)
        {
            if (EmployeeId <= 0)
            {
                return NotFound("not found");
            }

            Employeedatum? employeedata = _appDbContext.Employeedata.SingleOrDefault(s => s.Id == EmployeeId);

            if (employeedata == null)
            {
                return NotFound("notfound");
            }

            return Ok(employeedata);
        }
        [Route("BulkInsert")]
        [HttpGet]
        public async Task<IActionResult> BulkInsert()
        {
            try
            {
                var allIds = new List<int>();
                var studentList = new List<Student>()
                    {
                        new Student() { Name="Kiron", Email = "email@someemail.com",Mobile ="123", Fname ="FName-1" },
                        new Student() { Name="Matthew", Email = "matthew@someemail.com",Mobile ="234", Fname ="FName-2" },
                        new Student() { Name="Guru Stron", Email = "Guru@someemail.com",Mobile ="635", Fname ="FName-3" },
                        new Student() { Name="Farid", Email = "farid@someemail.com",Mobile ="6321", Fname ="FName-4" },

                    };
                _appDbContext.Students.AddRange(studentList);
                await _appDbContext.SaveChangesAsync();
                // int[] ids = studentList.Select(x => x.ID).ToArray();
                allIds = studentList.Select(x => x.ID).ToList();
                return Ok(allIds);
            }
            catch (Exception ex)
            {

                return BadRequest(new { StatusMessage = "Your Messaage", StatusCode = 400 });
            }


           
        }

        public async Task<bool> ShippingFinishDeleteItem(String body)
        {

            return true;
        }

    }
}
