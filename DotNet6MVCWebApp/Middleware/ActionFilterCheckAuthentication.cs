using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;

namespace DotNet6MVCWebApp.Middleware
{
    public class ActionFilterCheckAuthentication 
    {
        private readonly RequestDelegate next;
        public ActionFilterCheckAuthentication(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
          //  var isAuthorized = context.HttpContext.User.Claims.Any(c => c.Type != null && c.Value != null);
           // var isAuthorized = context.User.Claims.Any(c => c.Type != null && c.Value != null);
            bool isAuthorized = false;

            if (!isAuthorized)
            {

               // context.HttpContext.Response.Redirect("/Login/Index");
                context.Response.Redirect("/Login/Index");

            }
            else
            {
                await next(context);
            }
           
        }
        
    }
}
