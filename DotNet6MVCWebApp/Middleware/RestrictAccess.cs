using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace DotNet6MVCWebApp.Middleware
{
    public class RestrictAccess : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Request.Path.StartsWithSegments("/api/Operations"))
            {

                context.Result = new JsonResult(new { HttpStatusCode.Unauthorized });

            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
