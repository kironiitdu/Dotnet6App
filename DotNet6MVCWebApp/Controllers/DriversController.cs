using DocumentFormat.OpenXml.InkML;
using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DotNet6MVCWebApp.Controllers
{
    public class DriversController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DriversController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Drivers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drivers.ToListAsync());
        }

        // GET: Drivers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,scooberId,driverName,driverScore,employedTime,GrossWeight,Premium,amtApproaches,amtEvaluated,lastEvaluated")] Driver driver)
        {
            try
            {
                if (ModelState.IsValid)

                {
                    _context.Add(driver);
                    await _context.SaveChangesAsync();
                    int lastensertedId = driver.Id;
                    ViewBag.lastensertedId = lastensertedId;
                    ModelState.Clear();
                    return View("Index");
                }
            }


            catch (Exception ex)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(driver);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWithRangesAndGetIDs([Bind("Id,scooberId,driverName,driverScore,employedTime,GrossWeight,amtApproaches,amtEvaluated,lastEvaluated")] Driver driver)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   

                    _context.Add(driver);
                    await _context.SaveChangesAsync();
                    int lastensertedId = driver.Id;
                    ViewBag.lastensertedId = lastensertedId;
                    ModelState.Clear();
                    return View("Index");
                }
            }


            catch (Exception ex)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(driver);
        }

    }
}
