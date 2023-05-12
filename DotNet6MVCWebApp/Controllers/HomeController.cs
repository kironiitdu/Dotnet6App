using DotNet6MVCWebApp.Implements;
using DotNet6MVCWebApp.Middleware;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Reflection;

namespace DotNet6MVCWebApp.Controllers
{
    public class SearchModel
    {
        public string cityName { get; set; }
        public DateTime weddingDate { get; set; }
        public int guestCount { get; set; }


        public class Location
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }

        public class DistLocation
        {
            public string venName { get; set; }
            public double Distance { get; set; }
        }
    }


   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Create()
        {
            return View();
        }



        [SessionExpire]
        public ActionResult Index()
        {
            var environmentVariable = Environment.GetEnvironmentVariable("DbConnection");
            ViewData["Title"] = "Test title";
            return View();
        }

        //[AllowAnonymous]
        //public async Task<IActionResult> Index()
        //{



        //    Assembly asm = Assembly.GetAssembly(typeof(BookstorerRepository));
        //    var controlleractionlist = asm.GetTypes()
        //         .Where(type => typeof(Microsoft.AspNetCore.Mvc.Controller).IsAssignableFrom(type))
        //         .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
        //         .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
        //         .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
        //         .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();
        //    ViewBag.AllActionList = controlleractionlist;

        //    return View();
        //}

        [HttpGet]
        public IActionResult ConAction()
        {
            Assembly asm = Assembly.GetAssembly(typeof(HomeController));
            var controlleractionlist = asm.GetTypes()
                 .Where(type => typeof(Microsoft.AspNetCore.Mvc.Controller).IsAssignableFrom(type))
                 .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                 .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                 .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
                 .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();
            return Json(controlleractionlist);
        }



















        public void CallThisMethodEvery5Second(int counter)
        {
            Console.WriteLine("Current counter: {0} Last Fired At: {1}", counter, DateTime.Now);
        }
        public async Task<IActionResult> GetAllControllerAction()
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(5));

            int counter = 0;
            while (await timer.WaitForNextTickAsync())
            {
                counter++;
                //if (counter > 5) break;
                CallThisMethodEvery5Second(counter);
            }
            //Assembly asm = Assembly.GetAssembly(typeof(BookstorerRepository));

            //var controlleractionlist = asm.GetTypes()
            //        .Where(type => typeof(Microsoft.AspNetCore.Mvc.Controller).IsAssignableFrom(type))
            //        .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
            //        .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
            //        .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
            //        .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();
            //ViewBag.AllActionList = controlleractionlist;
            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book, List<string> GenresList)
        {
            //you will get the checkbox list by GenresList parameter
            //convert list string to string with comma
            string Genres = string.Join(",", GenresList);
            //  book.Genres = Genres;
            if (ModelState.IsValid)
            {
                //_context.Add(book);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetCheckBoxValue(List<string> customerCheckboxes)
        {
            //you will get the checkbox list by GenresList parameter
            //convert list string to string with comma
            string checkBox = string.Join(",", customerCheckboxes);

            return View();
        }

        public async Task<IActionResult> Lock(List<string> customerCheckboxes)
        {
            string checkBox = string.Join(",", customerCheckboxes);
            return View();
        }
        public ActionResult CommentIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult _CommentIndex(string Content)
        {
            List<Comment> contentList = new List<Comment>();
            contentList.Add(new Comment() { Content = "Comment 1" });
            contentList.Add(new Comment() { Content = "Comment 2" });
            contentList.Add(new Comment() { Content = "Comment 3" });
            contentList.Add(new Comment() { Content = "Comment 4" });


            return PartialView(contentList);
        }

        public ActionResult CommentIndexWithDb()
        {


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _CommentIndexWithDbOperation([Bind("Content,AnimalId")] Comment comment, int id)
        {
            ModelState.Clear();
            TryValidateModel(comment);

            if (!ModelState.IsValid)
            {

                return RedirectToAction(nameof(CommentIndex));
            }
            List<Comment> commentList = new List<Comment>();
            commentList.Add(new Comment() { CommentId = 1, AnimalId = 1, Content = "Test comment", });
            commentList.Add(new Comment() { CommentId = 2, AnimalId = 2, Content = "Test Comment 2", });
            commentList.Add(new Comment() { CommentId = 3, AnimalId = 3, Content = "Test Comment 3", });
            return PartialView(commentList);
        }
        [HttpPost]
        public ActionResult _SearchResults(string citystate, DateTime? weddingDate, double? guestcount)
        {
            List<SearchModel.DistLocation> venDistList = new List<SearchModel.DistLocation>();
            venDistList.Add(new SearchModel.DistLocation() { venName = "weee1", Distance = 2 });
            venDistList.Add(new SearchModel.DistLocation() { venName = "weee2", Distance = 4 });
            venDistList.Add(new SearchModel.DistLocation() { venName = "weee3", Distance = 6 });

            return PartialView(venDistList);
        }
        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Tax()
        {
            TaxViewModel taxViewModel = new TaxViewModel();

            return View(taxViewModel);
        }

        [HttpPost]
        public IActionResult NewTaxes(TaxViewModel taxData)
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}