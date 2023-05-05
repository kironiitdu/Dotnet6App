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
        public void CallThisMethodEvery5Second(int counter)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    //var client = new RestClient("http://your-api-url/api/drives");
                    //var request = new RestRequest(Method.Post);
                    //request.AddJsonBody(new
                    //{
                    //    SystemName = Environment.MachineName,
                    //    UserName = Environment.UserName,
                    //    DriveName = drive.Name,
                    //    DriveSpace = drive.TotalFreeSpace,
                    //    TotalDriveSpace = drive.TotalSize
                    //});
                    //IRestResponse response = client.Execute(request);
                }
            }
        }
    }
   
}
