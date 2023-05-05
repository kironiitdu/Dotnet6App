using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNet6MVCWebApp.Controllers
{
    public class NoIdentityController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public NoIdentityController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.EVENTs.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
           
            return View();

        }
        [HttpPost]
        public IActionResult Create(EVENT eventModel)
        {
            if (ModelState.IsValid)
            {
                //Getting Last Inserted Id
                int lastSequence = _context.EVENTs.OrderByDescending(id => id.id).FirstOrDefault() == null ? 0 : _context.EVENTs.OrderByDescending(id => id.id).FirstOrDefault().id;

                //Creating new Id
                var newId = lastSequence + 1;
                //Binding Object
                var _objEvent = new EVENT();
                _objEvent.id = newId;
                _objEvent.name = eventModel.name;
              

                _context.EVENTs.Add(_objEvent);
                _context.SaveChanges();


            }
            return RedirectToAction("Index");
        }

    }
}
