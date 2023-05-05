using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace SwaggerWebAPIApp.Middleware
{
    public class RestrictSwaggerAccess : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Request.Path.StartsWithSegments("/swagger"))
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
