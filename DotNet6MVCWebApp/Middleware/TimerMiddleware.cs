using Azure.Core;
using DocumentFormat.OpenXml.InkML;
using DotNet6MVCWebApp.Data;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using RestSharp;
using System;

namespace DotNet6MVCWebApp.Middleware
{
    public class TimerMiddleware
    {
        private readonly RequestDelegate _next;
        public TimerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {


            var timer = new PeriodicTimer(TimeSpan.FromSeconds(5));

            int counter = 0;
            while (await timer.WaitForNextTickAsync())
            {
                counter++;
               // if (counter > 5) break;
                CallThisMethodEvery5Second(counter);
            }
            // Move forward into the pipeline
            await _next(httpContext);
        }
        public async void  CallThisMethodEvery5Second(int counter)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            clientHandler.UseDefaultCredentials = true;
            HttpClient client2 = new HttpClient(clientHandler);
            client2.DefaultRequestHeaders.Clear();

            //Bind Request Model


            //Create Multipart Request
            var formContent = new MultipartFormDataContent();
            string json = "{\"contactName\": \"dddddd\", \"positionId\": 1, \"positionName\": null, \"itemId\": 1, \"mobile\": \"4545454545544\", \"email\": \"hhh@test.com\", \"businessName\": \"ddddddd\", \"note\": \"Noite\", \"businessTypeId\": 1, \"address\": \"Address\", \"countryId\": 1, \"city\": \"City\", \"score\": 60, \"methodId\": 1, \"qualificationStatusId\": 1, \"preferredTimeFrom\": \"01 AM\", \"preferredTimeTo\": \"01 AM\", \"createdAt\": \"2023-05-26T13:13:46.453\", \"browserName\": \"Google Chrome\", \"ipAddress\": \"155.222.255.40\", \"latitude\": \"\", \"longitude\": \"\", \"device\": \"Linux computer\" }";
            formContent.Add(new StringContent(json));

            var response = await client2.PostAsync("http://lead.basesoftbd.com/api/MarketingLeads", formContent);
           // var response = await client2.GetAsync("http://lead.basesoftbd.com/api/MarketingLeads");
            if (response.IsSuccessStatusCode)
            {
                var responseFromAzureIIS = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Calling count: {counter}");
            }
            //DriveInfo[] drives = DriveInfo.GetDrives();
            //foreach (DriveInfo drive in drives)
            //{
            //    if (drive.IsReady)
            //    {
            //        //var client = new RestClient("http://your-api-url/api/drives");
            //        //var request = new RestRequest(Method.Post);
            //        //request.AddJsonBody(new
            //        //{
            //        //    SystemName = Environment.MachineName,
            //        //    UserName = Environment.UserName,
            //        //    DriveName = drive.Name,
            //        //    DriveSpace = drive.TotalFreeSpace,
            //        //    TotalDriveSpace = drive.TotalSize
            //        //});
            //        //IRestResponse response = client.Execute(request);
            //    }
            //}
        }
    }
   
}
