using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class TodoController : Controller
    {
        public static List<Todo> ListOfTodos = new List<Todo>()
        {
            new Todo()
            {
                ItemId=101,
                Description="Plan the module",
                StartDate=DateTime.Now,
                EndDate=DateTime.Now.AddDays(4),
                TestDate=DateTime.Now.AddDays(4)
                
            },
            new Todo()
            {
                ItemId=102,
                Description="Dry run the plan",
                StartDate=DateTime.Now.AddDays(3),
                EndDate=DateTime.Now.AddDays(5),
                TestDate=DateTime.Now.AddDays(5)
               
            }
        };
        public IActionResult Index()
        {
           
            return View(ListOfTodos);
        }

        [HttpPost]
        public ActionResult Edit(Todo t1)
        {
            if (ModelState.IsValid)
            {
                Todo t = ListOfTodos.Find(m => m.ItemId == t1.ItemId);
                t.ItemId = t1.ItemId;
                t.Description = t1.Description;
                t.StartDate = t1.StartDate;
                t.EndDate = t1.EndDate;
               
                return View("Index", ListOfTodos);
            }
            return View();

        }

        public ActionResult Edit(int id)
        {
            Todo t = ListOfTodos.Find(m => m.ItemId == id);
            return View(t);
        }
    }
}
