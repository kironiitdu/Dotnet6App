using AspNetCore.Unobtrusive.Ajax;
using DotNet6MVCWebApp.Controllers.APIController;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;

namespace DotNet6MVCWebApp.Controllers
{
    public class AccessTempDataController : Controller
    {

        public ActionResult HandleButtonOn(string ButtonOn)
        {

            return RedirectToAction("IndexView");
        }
      
        
        public async Task<string> UpdateAddress(UpdateAddressModel model)
        {
            string text = "";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var PayLoad = JsonConvert.SerializeObject(model);
                    HttpContent content = new StringContent(PayLoad, Encoding.UTF8, "application/json");

                    var Response = await client.PostAsync("http://localhost:5094/api/user/EditAddress/", content);

                    Response.EnsureSuccessStatusCode();

                    var response = await Response.Content.ReadAsStringAsync();

                    return response;
                }
            }
            catch (Exception ex)
            {
                text = ex.Message;
            }
            return text;
        }
        public async Task<IActionResult> IndexView()
        {
            UpdateAddressModel requestMdoel = new UpdateAddressModel();
            requestMdoel.Email = "mytestemail@outlook.com";

            var callMethod = await UpdateAddress(requestMdoel);

            
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Index()
        {
            var envVer = Environment.Version;
            string currentVersion = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;

            var checkRequest = HttpContext.Request;

         var isAjax =   checkRequest.IsAjaxRequest();

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
