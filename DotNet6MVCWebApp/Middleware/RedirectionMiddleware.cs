using Microsoft.AspNetCore.Http.Extensions;

namespace DotNet6MVCWebApp.Middleware
{
    public class RedirectionMiddleware
    {
        private readonly RequestDelegate _next;
        public RedirectionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var originalUrl = context.Request.GetDisplayUrl(); // Check the URL which you want to validate 

            if (originalUrl.Contains("http://localhost:5094/AccessTempData/Index"))
            {
                var redirectToAnotherURL = "https://localhost:44361/userlog/ViewCalculateAge";//URL you want to redirect

                context.Response.Redirect(redirectToAnotherURL);
            }

            await _next(context);
        }
    }
}
