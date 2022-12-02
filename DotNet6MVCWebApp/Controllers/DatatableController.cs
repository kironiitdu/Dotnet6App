using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DotNet6MVCWebApp.Controllers
{
    public class DatatableController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public DatatableController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetProg()
        {
            var listProg = _context.Animals.ToList();
            return Json(listProg);
        }

        [HttpPost]
        public ActionResult Login(Users users)
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            asm.GetTypes()
                .Where(type => typeof(Controller).IsAssignableFrom(type)) //filter controllers
                .SelectMany(type => type.GetMethods())
                .Where(method => method.IsPublic && !method.IsDefined(typeof(NonActionAttribute)));


           

            if (ModelState.IsValid)
            {
                var obj = _context.Users
                       .Where(u => u.UserName.Equals(users.UserName.Trim()) && u.Password.Equals(users.Password.Trim()))
                       .FirstOrDefault();
                Console.WriteLine(obj);
                if (obj != null)
                {
                    return Ok(obj.UserName.ToString());
                }
            }
            return View(users);
        }
    }
}
