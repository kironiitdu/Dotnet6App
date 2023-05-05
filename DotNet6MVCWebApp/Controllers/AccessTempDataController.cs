using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace DotNet6MVCWebApp.Controllers
{
    public class AccessTempDataController : Controller
    {

        public ActionResult HandleButtonOn(string ButtonOn)
        {

            return RedirectToAction("IndexView");
        }

        public IActionResult IndexView()
        {
            return View();
        }
        public IActionResult Index()
        {
            TempData["FromC#TOJavascript"] = "Anything from C# To Javascript".ToString();
            return View();
        }
        public ActionResult LoginFromCOM(string libType)
        {
            TempData["FromComTaskLibType"] = libType;
            return View();
        }
        public IActionResult IndexFrom()
        {



            return View();
        }

        public ActionResult SpesGraduate(int yr1)
        {
            //int poid = GlobalHelper.UserPO(Session["UserPO"].ToString());
            //int implYear = (int)Session["ImplementYear"];
            int selyr1 = yr1;

            return View();
        }


        public ActionResult TimeGreetingsActionManual()
        {

            TimeOnly testTimeOnly = TimeOnly.ParseExact("00:00:00", "HH:mm:ss", CultureInfo.InvariantCulture);
            TimeOnly testMorning = TimeOnly.ParseExact("06:00:00", "HH:mm:ss", CultureInfo.InvariantCulture);

            var checkNight = testTimeOnly.Hour;
            var checkMorning = testMorning.Hour;
            switch (checkMorning)
            {
                case int time when (time >= 6 && time <= 12):
                    Console.WriteLine($"Hello {testTimeOnly} , good morning");
                    break;
                case int time when (time >= 12 && time <= 17):
                    Console.WriteLine($"Hello , good afternoon");
                    break;
                case int time when (time >= 0):
                    Console.WriteLine($"Hello , Its night right now");
                    break;
                default:
                    Console.WriteLine($"Unknown part of the day!");
                    break;

            }

            return View();

        }

        public ActionResult GetDynamicTimeGreetings()
        {
            DateTime dateTime = DateTime.Now;
            DateTime utcTime = dateTime.ToUniversalTime();
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");

            DateTime yourLocalTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, cstZone);
            var hour = yourLocalTime.Hour;

            switch (hour)
            {
                case int time when (time >= 0 && time <= 5):
                    Console.WriteLine($"Hello ,Its  mid night now");
                    break;
                case int time when (time >= 6 && time <= 12):
                    Console.WriteLine($"Hello , Its morning now");
                    break;
                case int time when (time >= 12 && time <= 17):
                    Console.WriteLine($"Hello , Its after noon");
                    break;
                case int time when (time >= 17 && time <= 19):
                    Console.WriteLine($"Hello , Its evening");
                    break;
                case int time when (time >= 19 && time <= 23):
                    Console.WriteLine($"Hello , Its Night");
                    break;
                default:
                    Console.WriteLine($"Hello and welcome!");
                    break;
            }

            return View();
        }

    }
}
