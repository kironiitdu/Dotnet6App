using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class CustomerHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()  // create a Employer that has a name in the browser
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee22 model)
        {
            ModelState.Clear();
            model.Name = "";   // <----------------set it to null so I expect to see the Name being empty in the reponse
            return View(model);
        }
    }
    public class Employee22
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Role { get; set; }
    }
}
