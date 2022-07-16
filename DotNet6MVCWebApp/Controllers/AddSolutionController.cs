using Dotnet6App.Data;
using DotNet6MVCWebApp.Models;
using DotNet6MVCWebApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DotNet6MVCWebApp.Controllers
{
    public class AddSolutionController : Controller
    {

        private readonly IService _addservice;
        public AddSolutionController(IService addservice)
        {
            _addservice = addservice;
        }
        //[Authorize]
        public  IActionResult Index()
        {
            ViewBag.Minutes = TempData["Minutes"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSolutionFrom(HataCozum solution)
        {
            AccessTokenClass token = await GetToken();
            var callGrpah = await CallGetWithHeaderMicrosoft(token.access_token);
            var callGrpah2 = await CallGetWithHeader(token.access_token);

            TimeSpan t = TimeSpan.FromSeconds(solution.Seconds);
            string answer = string.Format("{0:D2}m:{1:D2}s", t.Minutes, t.Seconds);
            TempData["Minutes"] = answer;
            var result = await _addservice.AddSolution(solution);
            return RedirectToAction("Index");
        }
        public class AccessTokenClass
        {
            public string token_type { get; set; }
            public string expires_in { get; set; }
            public string resource { get; set; }
            public string access_token { get; set; }
        }
        public async Task<AccessTokenClass> GetToken()
        {
            string tokenUrl = $"https://login.microsoftonline.com/ericmlab.onmicrosoft.com/oauth2/token";
            var tokenRequest = new HttpRequestMessage(HttpMethod.Post, tokenUrl);

            //I am Using client_credentials as It is mostly recommended
            tokenRequest.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials",
                ["client_id"] = "b603c7be-a866-4aea-ad87-e6921e61f925",
                ["client_secret"] = "Vxf1SluKbgu4PF0Nf3wE5oGl/2XDSeZ8wL/Yp8ns4sc=",
                ["resource"] = "https://graph.microsoft.com/"
            });

            dynamic json;
            AccessTokenClass results = new AccessTokenClass();
            HttpClient client = new HttpClient();

            var tokenResponse = await client.SendAsync(tokenRequest);

            json = await tokenResponse.Content.ReadAsStringAsync();
            results = JsonConvert.DeserializeObject<AccessTokenClass>(json);
            return results;
        }
        public async Task<IActionResult> CallGetWithHeader(string token)
        {
            try
            {
                HttpClient client = new HttpClient();
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, ""))
                {
                    requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    var token11 = requestMessage.Content;
                    var endpoint = "https://graph.microsoft.com/v1.0/users";
                    var result = client.GetAsync(endpoint).Result;
                    var json = result.Content.ReadAsStringAsync().Result;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
           
         
        }

        public async Task<IActionResult> CallGetWithHeaderMicrosoft(string token)
        {
            HttpClient _client = new HttpClient();
            var endpoint = "https://graph.microsoft.com/v1.0/users";
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint)))
            {
                //Passing Token For this Request
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await _client.SendAsync(requestMessage);
                //Get User into from  API
                dynamic resonse = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
            }
          
            return null;
        }
       
        public class DeviceInfo
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Status { get; set; }
            public string DeviceName { get; set; }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BatchUserUpload(IFormFile batchUsers)
        {

            if (ModelState.IsValid)
            {
                if (batchUsers?.Length > 0)
                {
                    var stream = batchUsers.OpenReadStream();
                    List<DeviceInfo> deviceInfos = new List<DeviceInfo>();
                    try
                    {
                        using (var package = new ExcelPackage(stream))
                        {
                            var worksheet = package.Workbook.Worksheets.First();//package.Workbook.Worksheets[0];
                            var rowCount = worksheet.Dimension.Rows;

                            for (var row = 2; row <= rowCount; row++)
                            {
                                try
                                {

                                    var Id = worksheet.Cells[row, 1].Value?.ToString();
                                    var name = worksheet.Cells[row, 1].Value?.ToString();
                                    var Status = worksheet.Cells[row, 2].Value?.ToString();
                                    var DeviceName = worksheet.Cells[row, 3].Value?.ToString();

                                    var device = new DeviceInfo()
                                    {
                                        Id = Id,
                                        Name = name,
                                        Status = Status,
                                        DeviceName = DeviceName
                                    };

                                    deviceInfos.Add(device);

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Something went wrong");
                                }
                            }
                        }

                       

                    }
                    catch (Exception e)
                    {
                        return View();
                    }
                }
            }

            return View();
        }

    }
}
