using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class YonnyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public YonnyController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public IActionResult Index()
        {

            var fruitsList_1 = new List<Fruit>()
            {
                new Fruit(){ Id =101,Color = "Banana-Yellow", Taste = "Sweet"},
                new Fruit(){Id = 102,Color = "Berry-Black", Taste = "Sour"},
                new Fruit(){ Id =103,Color = "Mango-Yellow", Taste = "Sweet"},

            };
            var fruitsList_2 = new List<Fruit>()
            {
                new Fruit(){ Id =201,Color = "PineApple-Yellow", Taste = "Sweet-Sour"},
                new Fruit(){Id = 202,Color = "Apple-While", Taste = "Sweet"},
                new Fruit(){ Id =203,Color = "Orange-Yellow", Taste = "Sour"},

            };

            var fruitsList_3 = new List<Fruit>()
            {
                new Fruit(){ Id =301,Color = "PineApple-Yellow", Taste = "Sweet-Sour"},
                new Fruit(){Id = 302,Color = "Apple-While", Taste = "Sweet"},
                new Fruit(){ Id =303,Color = "Orange-Yellow", Taste = "Sour"},

            };
            var basketsList = new List<Basket>()
            {
                new Basket(){ Id = 401,Sharp  ="Sharp-A",Material  ="Material-X", Fruits = fruitsList_1},
                new Basket(){ Id = 402,Sharp  ="Sharp-B",Material  ="Material-Y", Fruits = fruitsList_2},
                new Basket(){ Id = 403,Sharp  ="Sharp-C",Material  ="Material-Z", Fruits = fruitsList_3 }

            };


            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Basket model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Content("Invalid Submission!");
        //    }
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
     [Bind("Id,Material,Sharp,Fruits")] DotNet6MVCWebApp.Models.Basket basket)
        {
            if (ModelState.IsValid)
            {
                //Save Basket
                _context.Add(basket);
                await _context.SaveChangesAsync();

                //Add Fruits List
                foreach (var item in basket.Fruits)
                {
                    _context.Add(item);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Create));
            }
            return View(basket);
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}
