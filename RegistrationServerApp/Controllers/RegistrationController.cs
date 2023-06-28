using Microsoft.AspNetCore.Mvc;
using RegistrationServerApp.Data;
using RegistrationServerApp.Models;

namespace RegistrationServerApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly DataBaseContext dataBaseContext;

        public RegistrationController(DataBaseContext databaseContext)
        {
            this.dataBaseContext = databaseContext;
        }

        public IActionResult Index()
        {
           var listUsers =  dataBaseContext.Users.ToList();
            return View(listUsers);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Registration(User user)
        {
            dataBaseContext.Users.Add(user);
            dataBaseContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}
