using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Graph;
using System.Reflection;

namespace DotNet6MVCWebApp.Controllers
{
    public class DatatableController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private IRazorViewEngine _viewEngine;


        public DatatableController(IWebHostEnvironment environment, ApplicationDbContext context, IRazorViewEngine viewEngine)
        {
            _hostingEnvironment = environment;
            _context = context;
            _viewEngine = viewEngine;
        }

        public IActionResult TestCode()
        {

            // var path = Path.Combine(_hostingEnvironment.ContentRootPath, "View/Book", "Index.cshtml");
            var contentRootPath = _hostingEnvironment.ContentRootPath;
            string executingAssemblyDirectoryAbsolutePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string executingAssemblyDirectoryRelativePath = System.IO.Path.GetRelativePath(contentRootPath, executingAssemblyDirectoryAbsolutePath);

            string executingFilePath = $"{executingAssemblyDirectoryAbsolutePath.Replace('\\', '/')}/Views/Book/Index.cshtml";
            string viewPath = "~/Views/Book/Index.cshtml";
            string mainViewRelativePath = $"~/{executingAssemblyDirectoryRelativePath.Replace('\\', '/')}/Views/Book/Index.cshtml";

            var getViewResult = _viewEngine.GetView(executingFilePath: null, viewPath: viewPath, isMainPage: false);



            var sssss = _viewEngine.GetView(executingFilePath: executingFilePath, viewPath: viewPath, isMainPage: true);

            //var executingFilePath = "/Views/Index.cshtml";
            //var viewPath = "/Views/Index.cshtml";
            //var applicationRelativePath = _viewEngine.GetAbsolutePath(executingFilePath, viewPath)!;
            //Console.WriteLine($"applicationRelativePath: {applicationRelativePath}");
            //var viewResult = _viewEngine.GetView(executingFilePath, viewPath, false);

            return View();
        }

        [HttpPost]
        public IActionResult FetchReport()
        {
            var LocationsReport = new List<ClassLocations>();
            int PackageID = (int)Convert.ToInt64(Request.Form["PackageID"]);
            if (PackageID != 0)
            {
                LocationsReport = GetLocationsReport();
            }

            return Json(new { data = LocationsReport });
        }
        public List<ClassLocations> GetLocationsReport()
        {
            var newLocations = new List<ClassLocations>()
                 {
                  new ClassLocations {StoreName = "Store-1", PackageName = "Package-1",Contact = "Contact-1" },
                  new ClassLocations {StoreName = "Store-2", PackageName = "Package-2",Contact = "Contact-2" },
                  new ClassLocations {StoreName = "Store-3", PackageName = "Package-3",Contact = "Contact-3" },

                 };
            return newLocations;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IEnumerable<Role> GetRole()
        {
            var roleList = new List<Role>()
            {
                new Role(){ Id = 1,Name ="Plan A", Description= "Plan Description A", Date=DateTime.Now,Deleted= true},
                new Role(){ Id = 2,Name ="Plan B", Description= "Plan Description B", Date=DateTime.Now,Deleted= false},
                new Role(){ Id = 3,Name ="Plan C", Description= "Plan Description C", Date=DateTime.Now,Deleted= true},
                new Role(){ Id = 4,Name ="Plan D", Description= "Plan Description D", Date=DateTime.Now,Deleted= false},
                new Role(){ Id = 5,Name ="Plan E", Description= "Plan Description E", Date=DateTime.Now,Deleted= true},


            };
            return roleList;
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
    //public class RenderingService : IRenderingService
    //{

    //    private readonly IWebHostEnvironment _hostingEnvironment;
    //    public RenderingService(IWebHostEnvironment hostingEnvironment)
    //    {
    //        _hostingEnvironment = hostingEnvironment;
    //    }

    //    public string RelativeAssemblyDirectory()
    //    {
    //        var contentRootPath = _hostingEnvironment.ContentRootPath;
    //        string executingAssemblyDirectoryAbsolutePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    //        string executingAssemblyDirectoryRelativePath = System.IO.Path.GetRelativePath(contentRootPath, executingAssemblyDirectoryAbsolutePath);
    //        return executingAssemblyDirectoryRelativePath;
    //    }
    //}

    public class ClassLocations
    {
        public string? StoreName { get; set; }
        public string? PackageName { get; set; }
        public string? Contact { get; set; }
    }
    public class Role
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public bool Deleted { get; set; }
    }

}
