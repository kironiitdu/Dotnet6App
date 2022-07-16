using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.Minutes = TempData["Minutes"];
            return View();
           
        }


        [HttpPost]
        public async Task<IActionResult> AddSecond(SecondModel second)
        {
            TimeSpan t = TimeSpan.FromSeconds(second.Seconds);
            string answer = string.Format("{0:D2}m:{1:D2}s", t.Minutes, t.Seconds);
            TempData["Minutes"] = answer;
            return RedirectToAction("Index");
        }
    }
}
