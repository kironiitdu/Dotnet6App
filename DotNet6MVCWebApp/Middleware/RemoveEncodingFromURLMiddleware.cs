using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNet6MVCWebApp.Middleware
{
    public class RemoveEncodingFromURLMiddleware
    {
        private readonly RequestDelegate _next;
        public RemoveEncodingFromURLMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {

            var originalUrl = httpContext.Request.Path.ToString();
            if (originalUrl.Contains("%2F")) {
                var newUrl = originalUrl.Replace("%2F", "/");
                httpContext.Response.Redirect(newUrl);
            }
          
            // Move forward into the pipeline
            await _next(httpContext);
        }
    }
}
