using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using DotNet6MVCWebApp.ViewModel;
using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;

namespace DotNet6MVCWebApp.Controllers
{
    public class SelectListController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public SelectListController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public IActionResult Index()
        {
            EventsViewModel renterEventDropdown = new EventsViewModel()
            {
                EventsCategories = _context.Categories.Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                }),
            };
            return View(renterEventDropdown);

        }
        public IActionResult Show()
        {
            var cars = new List<Cars>()
                 {
                  new Cars {Name = "BMW", Id = 1},
                  new Cars {Name = "KIA", Id= 2},
                  new Cars {Name = "FORD", Id = 3},
                 };

            MyModel myCarDropdownList = new MyModel()
            {
                CarsList = cars.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()

                }),
            };

            return View(myCarDropdownList);
        }
        public IActionResult LoadStock()
        {
            List<SelectListItem> entityTypeList = new List<SelectListItem>();
            entityTypeList.Add(new SelectListItem { Text = "Client-A", Value = "Client-A" });
            entityTypeList.Add(new SelectListItem { Text = "Client-B", Value = "Client-B" });
            entityTypeList.Add(new SelectListItem { Text = "Client-C", Value = "Client-C" });


            ViewBag.ListCategories = entityTypeList;
            return View();
        }

        public IActionResult LoadArea()
        {
            List<SelectListItem> areaList = new List<SelectListItem>();
            areaList.Add(new SelectListItem { Text = "Area-A", Value = "Area-A" });
            areaList.Add(new SelectListItem { Text = "Area-B", Value = "Area-B" });
            areaList.Add(new SelectListItem { Text = "Area-C", Value = "Area-C" });


            ViewBag.ListAreas = areaList;
            return View();
        }

        [HttpPost]
        public IActionResult CheckPassByArea(string areaId)
        {

            var gatePass = new List<GatePass>()
                 {
                  new GatePass {Id = 1,Name = "Gete-A", Area = "Area-A"},
                  new GatePass {Id = 2,Name = "Gete-B", Area = "Area-B"},
                  new GatePass {Id = 3,Name = "Gete-C", Area = "Area-C"},
                 };

            SelectList stocksList = new SelectList(gatePass.Where(ar => ar.Area == areaId), "Id", "Name");
            return Json(stocksList);
        }

        public async Task<IActionResult> Material()
        {


            ViewData["Material"] = new SelectList(await Materials(), "Id", "Name", 21);
            return View();

        }

        public async Task<List<MaterialClass>> Materials()
        {
            var materials = new List<MaterialClass>()
                 {
                  new MaterialClass {Name = "Milk", Id = 20},
                  new MaterialClass {Name = "Whey", Id= 21},
                  new MaterialClass {Name = "Jgv", Id = 22},
                 };
            return materials;
        }
        public IActionResult Create()
        {
            SelectList cropList = new SelectList(myCrops.GetAll(), "Id", "Name");

            ViewData["Crops"] = cropList;
            return View();

        }
        public IActionResult CorpsIndex()
        {
            var list = _context.Corps.ToList();

            var listOfFarmers = new List<FarmerViewModel>();

            foreach (var item in list)
            {
                var model = new FarmerViewModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Age = item.Age;
                model.CorpsName = myCrops.GetAll().FirstOrDefault(selectedCorps => selectedCorps.Id == item.CorpsId).Name;
                listOfFarmers.Add(model);
            }

            return View(listOfFarmers);

        }


        [HttpPost]
        public IActionResult Create(Corps corps)
        {
            if (ModelState.IsValid)
            {
                //Getting Last Inserted Id
                int list = _context.Corps.ToList().Max(id => id.Id);
                //Creating new Id
                var newId = list + 1;
                //Binding Object
                var _objCorps = new Corps();
                _objCorps.Id = newId;
                _objCorps.Name = corps.Name;
                _objCorps.Age = corps.Age;
                _objCorps.CorpsId = corps.CorpsId;

                _context.Corps.Add(_objCorps);
                _context.SaveChanges();


            }
            return RedirectToAction("CorpsIndex");
        }

        [HttpPost]
        public IActionResult GetStockByCat(string CatId)
        {

            var stocks = new List<Stock>()
                 {
                  new Stock {Name = "BMW", StockId = 1},
                  new Stock {Name = "KIA", StockId= 2},
                  new Stock {Name = "FORD", StockId = 3},
                 };

            SelectList stocksList = new SelectList(stocks, "StockId", "Name");
            return Json(stocksList);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Save(EventsViewModel model)
        {
            if (ModelState.IsValid)
            {

                var eventsObj = new Events();
                {
                    eventsObj.Name = model.Name;
                    eventsObj.EventsCategoriesId = model.EventsCategoriesId;

                }
                // _context.Event.Add(eventsObj);
            }

            return RedirectToAction(nameof(Events));
        }

    }
    public class FarmerViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? CorpsName { get; set; }
    }
    public class CreateViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public int CorpsId { get; set; }

    }
    public class myCrops
    {
        public static List<Crops> GetAll()
        {
            return new List<Crops>
            {
                new Crops() { Id = 1, Name = "Apples"},
                new Crops() { Id = 2, Name = "Bananas"},
                new Crops() { Id = 3, Name = "Grapes"},
                new Crops() { Id = 4, Name = "Orange"},
            };
        }
    }
    public class Crops
    {
        public int Id { get; set; }
        public string? Name { get; set; }

    }
    public class MaterialViewModel
    {
        public List<SelectListItem>? MaterialClassList { get; set; }
    }
    public class MaterialClass
    {
        public int Id { get; set; }
        public string? Name { get; set; }

    }
    public class Stock
    {
        public int StockId { get; set; }
        public string Name { get; set; }

    }
    public class GatePass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }

    }
    public class Cars
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Events
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int EventsCategoriesId { get; set; }
        [ForeignKey("EventsCategoriesId")]
        public EventsCategories EventsCategories { get; set; }
    }

    public class EventsCategories
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MyModel
    {

        public IEnumerable<SelectListItem>? CarsList { get; set; }
    }
    public class EventsViewModel
    {

        public string Name { get; set; }

        public int EventsCategoriesId { get; set; }
        public IEnumerable<SelectListItem>? EventsCategories { get; set; }
    }
}
