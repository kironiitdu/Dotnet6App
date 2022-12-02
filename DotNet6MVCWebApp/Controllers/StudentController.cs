using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public StudentController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }
        public ActionResult students()
        {

            return View();
        }

        public IActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student obj)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    if (obj.ID == 0)
                    {
                        _context.Students.Add(obj);
                        await _context.SaveChangesAsync();
                    }

                    return RedirectToAction("StudentList");

                }
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                return RedirectToAction("StudentList");
            }
        }
        public IActionResult StudentList()
        {
            try
            {
                var stdList = _context.Students;


                return View(stdList);
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        //public List<Eventrole> AddandGetStudents(Students obj)
        //{

        //    List<Eventrole> studentslist = new List<Eventrole>();
        //    connection();
        //    SqlCommand com = new SqlCommand("prc_add", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@name", obj.Name);
        //    com.Parameters.AddWithValue("@email", obj.Email);

        //    SqlDataAdapter sqlDA = new SqlDataAdapter();
        //    DataTable dteventroles = new DataTable();

        //    con.Open();
        //    com.ExecuteNonQuery();
        //    sqlDA.Fill(dteventroles);
        //    con.Close();

        //    foreach (DataRow dr in dteventroles.Rows)
        //    {
        //        studentslist.Add(new Students
        //        {
        //            Name = dr["name"].ToString(),
        //            Email = dr["email"].ToString()
        //        });

        //    }
        //    return studentslist;
        //}
    }
}
