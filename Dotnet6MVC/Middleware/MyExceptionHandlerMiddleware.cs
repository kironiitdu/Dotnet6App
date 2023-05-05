using log4net.Core;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace DotNet6MVCWebApp.Middleware
{
    public class MyExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public MyExceptionHandlerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {

            try
            {
               
                await _next(httpContext);
                if (!httpContext.Response.HasStarted)
                {
                    int exception = Convert.ToInt32("ssss");
                }
               
              
            }
            
            catch (Exception ex)
            {
                //    _logger.LogCritical("[Exp][API] Something went wrong: {}", ex);
                
                await HandleExceptionAsync(httpContext, ex);

            }


        }
        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
         
            var json = JsonSerializer.Serialize(new
            {
                errorDetails = exception.Message,
                status = "Do not write any response if in previous middlwar already has written any response!",
                errorCode = (int)HttpStatusCode.InternalServerError,
            });

            await httpContext.Response.WriteAsync(json);
        }
    }
}
