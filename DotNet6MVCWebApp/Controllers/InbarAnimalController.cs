using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Itenso.TimePeriod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNet6MVCWebApp.Controllers
{
    public class InbarAnimalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public InbarAnimalController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public async Task<IActionResult> Index()
        
        {
            // DateTime currentStartDate = DateTime.Parse("01/01/2022");
            DateTime currentStartDate = DateTime.Parse("12/08/1988");

            var startYear = currentStartDate.Year;
            var startMonth = currentStartDate.Month;
            var startDay = currentStartDate.Day;

            DateTime currentEndDate = DateTime.Parse("08/11/2022");

            var endYear = currentStartDate.Year;
            var endMonth = currentStartDate.Month;
            var endDay = currentStartDate.Day;
            var formatCurrentStartDate = DateTime.Parse(currentStartDate.ToString("yyyy/MM/dd"));

            //var listDate = _context.TableDateGaps.ToList();

            //foreach (var item in listDate)
            //{
            //   // DateTime currentStartDate = DateTime.Parse("01/01/2022");
            //    DateTime currentStartDate = DateTime.Parse(item.StartDate);

            //    var startYear = currentStartDate.Year;
            //    var startMonth = currentStartDate.Month;
            //    var startDay = currentStartDate.Day;

            //    DateTime currentEndDate = DateTime.Parse(item.EndDate);

            //    var endYear = currentStartDate.Year;
            //    var endMonth = currentStartDate.Month;
            //    var endDay = currentStartDate.Day;
            //    var formatCurrentStartDate = DateTime.Parse(currentStartDate.ToString("yyyy/MM/dd"));
            //}



            //DateTime currentEndDate = DateTime.Parse("05/01/2022"); ;

            //  var formatCurrentEndDate = DateTime.Parse(currentStartDate.ToString("yyyy/MM/dd"));

            // DateTime startDate = new DateTime(formatCurrentStartDate);
            DateTime endDate = new DateTime(2022, 01, 05);
            //var gapFound = (endDate! - startDate!).TotalDays;

            GapFinder();
            //  var petShopDataContext = _context.Animals.Include(a => a.Category);
            var petShopDataContext = _context.Animals.ToList();
            return View(petShopDataContext);
        }
        public void GapFinder()
        {
            // base periods
            TimePeriodCollection basePeriods = new TimePeriodCollection();
            basePeriods.Add(new TimeRange(new DateTime(2012, 1, 1), new DateTime(2012, 1, 10)));
            basePeriods.Add(new TimeRange(new DateTime(2012, 1, 11), new DateTime(2012, 1, 25)));
            ITimePeriodCollection combinedBasePeriods = new TimePeriodCombiner<TimeRange>().CombinePeriods(basePeriods);

            // test periods
            TimePeriodCollection testPeriods = new TimePeriodCollection();
            testPeriods.Add(new TimeRange(new DateTime(2012, 1, 2), new DateTime(2012, 1, 7)));
            testPeriods.Add(new TimeRange(new DateTime(2012, 1, 8), new DateTime(2012, 1, 9)));
            testPeriods.Add(new TimeRange(new DateTime(2012, 1, 15), new DateTime(2012, 1, 30)));
            ITimePeriodCollection combinedTestPeriods = new TimePeriodCombiner<TimeRange>().CombinePeriods(testPeriods);

            // gaps
            TimePeriodCollection gaps = new TimePeriodCollection();
            foreach (ITimePeriod basePeriod in combinedBasePeriods)
            {
                gaps.AddAll(new TimeGapCalculator<TimeRange>().GetGaps(combinedTestPeriods, basePeriod));
            }
            foreach (ITimePeriod gap in gaps)
            {
                Console.WriteLine("Gap: " + gap);
            }
        } // GapFinder
        public async Task<IActionResult> CreateAnimal()
        {
            //var categories =  _context.Categories.ToList();
            //ViewBag.Categories = categories.Select(c => new SelectListItem(c.CategoryName, c.CategoryId.ToString())).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAnimal(CreateAnimalViewModel vm)
        {

            return RedirectToAction("Index");
        }
    }
}
