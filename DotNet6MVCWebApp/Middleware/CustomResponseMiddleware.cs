using Microsoft.AspNetCore.Mvc.Routing;

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
            if (httpContext.Response.StatusCode == 404)
            {
                httpContext.Response.Redirect("/WrongControllerName/WrongAction");
            }
            await _next(httpContext);
        }

    }
}
