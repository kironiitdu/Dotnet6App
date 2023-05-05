using Microsoft.AspNetCore.Mvc.Routing;
using System.Globalization;

namespace DotNet6MVCWebApp.Middleware
{
    public class CustomResponseMiddleware
    {
        private readonly RequestDelegate _next;
       
        public CustomResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            //if (httpContext.Response.StatusCode == 404)
            //{
            //    httpContext.Response.Redirect("/WrongControllerName/WrongAction");
            //}
            await _next(httpContext);
        }

    }
}
