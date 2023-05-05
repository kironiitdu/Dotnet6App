using DocumentFormat.OpenXml.Office2010.Excel;
using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Controllers
{
    public class SomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public SomeController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        public ActionResult Index()
        {
            var ingredientList = new List<Ingredient>()
            {
                new Ingredient(){ IngredientId = 401,IngredientName  ="Ingredient-PineApple Pulp"},
                new Ingredient(){ IngredientId = 402,IngredientName  ="Ingredient-Butter"},


            };
            var ingredientList2 = new List<Ingredient>()
            {
                new Ingredient(){ IngredientId = 403,IngredientName  ="Ingredient-Orang Pulp"},
                new Ingredient(){ IngredientId = 404,IngredientName  ="Ingredient-Orang Juice"},
                new Ingredient(){ IngredientId = 405,IngredientName  ="Ingredient-Suger"},


            };
            var cookiesList = new List<Cookie>()
            {
                new Cookie(){ Id =301,Name = "PineApple-Yellow", Ingridients =ingredientList},
                new Cookie(){ Id =302,Name = "Apple-While", Ingridients =ingredientList2}


            };

            var cokie = _context.Cookies.ToList();
            var intgre = _context.Ingredients.ToList();

            var employeeRecord = (from cok in cokie
                                  join ing in intgre on cok.Id equals ing.CookieId
                                  select new Cookie
                                  {
                                      Id = cok.Id,
                                      Name = cok.Name,
                                      Ingridients = (intgre.Where(cid => cid.CookieId == cok.Id).ToList()),
                                  }).DistinctBy(id => id.Id).ToList();



            return View(employeeRecord);

        }


        //[HttpGet]
        //public IActionResult ManageUser(string Status, string? StatusMessage)
        //{
        //    TempData["Message"] = "";
        //    if (StatusMessage != null)
        //    {
        //        TempData["Message"] = StatusMessage;
        //    }

        //    //load model
        //    return View();
        //}
        //  [HttpPost]
        public IActionResult ManageUser(string executeAction, int userId)
        {
            string status = "";
            string statusMessage = string.Empty;

            if (executeAction == "Delete")
            {
                //delete the user
            }

            return RedirectToAction("ManageUser", "ManageUsers", status, statusMessage);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.assignee = GetEmployees();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAssignmentViewModel addAssignmentRequest)
        {
            var assignment = new Assignment()
            {
                taskID = Guid.NewGuid(),
                title = addAssignmentRequest.title,
                description = addAssignmentRequest.description,
                EmployeeId = addAssignmentRequest.assignee,
                dueDate = addAssignmentRequest.dueDate,
            };

            await _context.Assignments.AddAsync(assignment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        private List<SelectListItem> GetEmployees()
        {
            var lstEmployees = new List<SelectListItem>();
            var employees = _context.Employees.ToList();
            

            lstEmployees = employees.Select(e => new SelectListItem()
            {
                Value = e.EmployeeId.ToString(),
                Text = e.First_Name
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "---Select Employee---"
            };

            lstEmployees.Insert(0, defItem);

            return lstEmployees;
        }
        private List<SelectListItem> GetStudentCourse()
        {
            var lstCourse = new List<SelectListItem>();
            var courseList = new List<StudentCourse>()
            {
                new StudentCourse(){ CourseId =301,CourseName = "C#.NET"},
                new StudentCourse(){ CourseId =302,CourseName = "SQL"}
            };

            lstCourse = courseList.Select(e => new SelectListItem()
            {
                Value = e.CourseName,
                Text = e.CourseName
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "---Select Course---"
            };

            lstCourse.Insert(0, defItem);

            return lstCourse;
        }
        public IActionResult LoadStudentAndCourse()
        {
            ViewBag.StudentCourses = GetStudentCourse();
            return View();
        }

        public IActionResult LoadStudentAndCourseWithList()
        {
            var courseList = new List<StudentCourse>()
            {
                new StudentCourse(){ CourseId =301,CourseName = "C#.NET"},
                new StudentCourse(){ CourseId =302,CourseName = "SQL"}
            };

            var studentClass =new StudentClass();
            studentClass.StudentCourses = courseList;
            return View(studentClass);
        }

        public IActionResult Save(IFormCollection formdata)
        {
            var dynamicFormDataDictionary = new Dictionary<string, object>();

            foreach (var item in formdata)
            {

                dynamicFormDataDictionary.Add(item.Key, item.Value);
               
            }


            return Ok();
        }

    }



    public class AddAssignmentViewModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public int assignee { get; set; }
        public DateTime dueDate { get; set; }
    }
    public partial class StudentClass
    {
        public int StdId { get; set; }
        public string? StdName { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
    public class StudentCourseViewModel
    {
        public string? StdName { get; set; }
        public string CourseName { get; set; }
    }
    public partial class StudentCourse
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        
    }


}
