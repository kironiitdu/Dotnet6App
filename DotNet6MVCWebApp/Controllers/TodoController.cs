using DocumentFormat.OpenXml.Spreadsheet;
using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http;
using System.Net;
using System.Numerics;
using System.Net.Http.Headers;

using Status = DotNet6MVCWebApp.Models.Status;
using Todo = DotNet6MVCWebApp.Models.Todo;
using Users = DotNet6MVCWebApp.Models.Users;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.Metrics;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Authorization;

namespace DotNet6MVCWebApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public TodoController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public static List<Todo> ListOfTodos = new List<Todo>()
        {
            new Todo()
            {
                ItemId=101,
                Description="Plan the module",
                StartDate=DateTime.Now,
                EndDate=DateTime.Now.AddDays(4),
                TestDate=DateTime.Now.AddDays(4)

            },
            new Todo()
            {
                ItemId=102,
                Description="Dry run the plan",
                StartDate=DateTime.Now.AddDays(3),
                EndDate=DateTime.Now.AddDays(5),
                TestDate=DateTime.Now.AddDays(5)

            }
        };
        public IActionResult Index()
        {

            return View(ListOfTodos);
        }


        //public IActionResult Index()
        //{

        //    return View(ListOfTodos);
        //}

        //[HttpPost]
        //[Route("account/istatement")]
        //public async Task<ActionResult> TestCon(Test cif)
        //{
        //    return Ok("hello gamma");
        //}
        public class Test
        {
            public string cif { get; set; }
        }

        public async Task<IActionResult> SubmitPost()
        {
            try
            {

                var test = new Test();
                test.cif = "New CIF";

                var data_ = JsonConvert.SerializeObject(test);
                HttpClient _httpClient = new HttpClient();
                var buffer_ = System.Text.Encoding.UTF8.GetBytes(data_);
                var byteContent_ = new ByteArrayContent(buffer_);
                byteContent_.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                string _urls = "http://localhost:5094/account/istatement";
                var responses_ = await _httpClient.PostAsync(_urls, byteContent_);

                if (responses_.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("[GetPrimeryAccount] Response: Success");
                    string body = await responses_.Content.ReadAsStringAsync();
                    return Ok(body);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Ok();
        }
        public IActionResult GetAll()
        {

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.BaseAddress = new Uri("https://localhost:44361/");

            var restClient = new RestClient(httpClient);
            var request = new RestRequest("UserLog/GetData", Method.Get) { RequestFormat = DataFormat.Json };
            var response = restClient.Execute<List<MultipleDBQueryExecutionModel>>(request);


            if (response.Data.Count == 0)
            {
                var emptyObject = new MultipleDBQueryExecutionModel();
                return Ok(emptyObject);
            }




            return Ok(response.Data);
        }

        [HttpPost]
        public ActionResult Edit(Todo t1)
        {
            if (ModelState.IsValid)
            {
                Todo t = ListOfTodos.Find(m => m.ItemId == t1.ItemId);
                t.ItemId = t1.ItemId;
                t.Description = t1.Description;
                t.StartDate = t1.StartDate;
                t.EndDate = t1.EndDate;

                return View("Index", ListOfTodos);
            }
            return View();

        }

        public ActionResult Edit(int id)
        {
            Todo t = ListOfTodos.Find(m => m.ItemId == id);
            return View(t);
        }

        public ActionResult IndexUserList()
        {
            //var userLanguages = HttpContext.Request.Headers.AcceptLanguage;
            //var selectLan = userLanguages.ToString();


            //var languages = selectLan.Split(',')
            //    .Select(StringWithQualityHeaderValue.Parse)
            //    .OrderByDescending(s => s.Quality.GetValueOrDefault(1));
            //var userLan = languages.Select(val => val.Value).ToList();

            //foreach (var item in userLan)
            //{
            //    DateTime currentDate = DateTime.Now;

            //    if (item.Contains("en-US") || item.Contains("it-IT"))
            //    {
            //        if (item == "en-US")
            //        {
            //            var enUS_Format = currentDate.ToString("MM-dd-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
            //            HttpContext.Session.SetString("DateFormat", enUS_Format);
            //            break;
            //        }
            //        if (item == "it-IT")
            //        {
            //            var italy_Format = currentDate.ToString("dd-MM-yyyy", CultureInfo.CreateSpecificCulture("it-IT"));
            //            HttpContext.Session.SetString("DateFormat", italy_Format);
            //            break;
            //        }


            //    }


                //switch (item)
                //{
                //    case "en-US":
                //        var enUS_Format = currentDate.ToString("dddd dd MMMM", CultureInfo.CreateSpecificCulture("en-US"));
                //        HttpContext.Items.Add("lang", enUS_Format);
                //        var getKey1 = HttpContext.Items["lang"]?.ToString();
                //        var getKey = HttpContext.Session.GetString("lang");
                //        break;
                //    case "it-IT":
                //        var italy_Format = currentDate.ToString("dddd dd MMMM", CultureInfo.CreateSpecificCulture("it-IT"));
                //        break;

                //    default:
                //        var usEn = currentDate.ToString("dddd dd MMMM", CultureInfo.CreateSpecificCulture("en-US"));
                //        break;
                //}
            //}


            return View();
        }
        [HttpGet]
        public ActionResult GetUserList()
        {
          
            var userList = _context.Students.ToList();
            return Ok(userList);
        }
        public ActionResult PaginationInDDL()
        {

            return View();
        }

        public ActionResult SetColorOnContainerColumn()
        {

            return View();
        }
        public IActionResult StatusView()
        {
           
           


            var status = new List<Status>()
            {
                new Status(){ StatusName = "Select Status",StatusId =0},
                new Status(){ StatusName = "Pending",StatusId =1},
                new Status(){ StatusName = "Accepted",StatusId =2},
                new Status(){ StatusName = "Denied",StatusId =3},


            };

            var model = new Heating();
            model.Statuses = status;

            var statusCaseLinq = new List<Status>()
            {
                new Status(){ StatusName = "Pending",StatusId =0},
            };

            var caseToLinq =
            (
                from n in statusCaseLinq
                where n != null
                select new
                {
                    CaseId = n,
                    CaseSatus =
                    (
                        n.StatusId == 0 ? "Pending" :
                        n.StatusId == 1 ? "Accepted" :
                        n.StatusId == 2 ? "Denied" : "Unknown"
                    )
                }
            );

            var getCaseStstusFromId = caseToLinq.FirstOrDefault().CaseSatus;

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Users());
            else
            {
                try
                {
                    var org = await _context.Developers.FindAsync(id);
                    if (org == null)
                    {
                        return NotFound();
                    }
                    return Ok(org); ;
                }
                catch (Exception ex)
                {

                    throw;
                }


            }
        }
        //[HttpPost]
        //public async Task<IActionResult> Create(SaveCommand command)
        //{
        //    TempData["error"] = "Temp Data From Controller";
        //    return View();
        //}
      
        public IActionResult TempDataView()
        {

            var operation = "Edit";

            TempData["error"] = operation;
            return View();
        }
        public IActionResult AddOrEditView()
        {
            return View();
        }
        // http://localhost:5094/Todo/AddOrEdit
        public class MultipleDBQueryExecutionModel
        {

            public Int64 UserId { get; set; }
            public string UserType { get; set; }
            public DateTime CreatedDate { get; set; }
        }
    }
}
