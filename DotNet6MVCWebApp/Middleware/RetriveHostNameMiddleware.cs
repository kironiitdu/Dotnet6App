using Microsoft.IdentityModel.Tokens;
using Ocelot.Infrastructure;
using System.Collections.Specialized;
using System.Reflection;

namespace DotNet6MVCWebApp.Middleware
{
    public class RetriveHostNameMiddleware
    {
        private readonly RequestDelegate _next;

        public RetriveHostNameMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
           
            if (httpContext.Request.ContentType != null)
            {
                var state = httpContext.Request?.Form["state"];
            }

            await _next(httpContext);
        }
    }
}
