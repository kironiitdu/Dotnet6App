﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace DotNet6MVCWebApp.Middleware
{
    public class SampleExceptionFilter: IExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;

        public SampleExceptionFilter(IHostEnvironment hostEnvironment) =>
            _hostEnvironment = hostEnvironment;

        public void OnException(ExceptionContext context)
        {

            if (!_hostEnvironment.IsDevelopment())
            {
                // Don't display exception details unless running in Development.
                return;
            }
         

            context.Result = new ContentResult
            {
                Content = context.Exception.ToString()

            };
           
        }
    }
}
