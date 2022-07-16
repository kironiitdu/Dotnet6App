using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace DotNet6MVCWebApp.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public RestaurantController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }

      
        public ActionResult SomeMethod(bool isTrue)

        {
            if (isTrue)
            {
                //do something
            }
            else
            {
                //do something
            }
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DeleteAction(bool confirm, string other_parameter)
        {
            // if user confirm to delete then this action will fire
            // and you can pass true value. If not, then it is already not confirmed.

            return View();
        }

        public ActionResult ContinueAction(string isContinue)
        {
            // if user confirm to delete then this action will fire
            // and you can pass true value. If not, then it is already not confirmed.

            return RedirectToAction("SomeMethod");
        }

        [IgnoreAntiforgeryToken]
        [HttpPost]
        public ActionResult PostPaymetInfo(UserModel paymentModel)
        {

            var dnameate = paymentModel.FirstName;
            dnameate.ToArray();


            // if user confirm to delete then this action will fire
            // and you can pass true value. If not, then it is already not confirmed.



            string pattern = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.? )";
            string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels",
                         "Abraham Adams", "Ms. Nicole Norris" };
            foreach (string name in names)
                Console.WriteLine(Regex.Replace(name, pattern, String.Empty));

            return RedirectToAction("Index");
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Restaurants()
        {
            //var company = await _context.Companies.Include(c => c.Restaurants).FirstAsync(c => c.Id == 1);
            return View();
        }


        //public async Task<IActionResult> SittingOne(int restaurantId)
        //{
        //    var restaurant = await _context.Restaurants.FirstOrDefaultAsync(s => s.Id == restaurantId);
        //    var parent = new Models.ParentModel
        //    {
        //        sittingVM = CreateNewSittingVM(restaurantId)

        //    };
        //    return View(parent);
        //}
    }
}
