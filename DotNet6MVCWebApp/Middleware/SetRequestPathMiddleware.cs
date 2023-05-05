using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;

namespace DotNet6MVCWebApp.Middleware
{
    public class SetRequestPathMiddleware
    {
        private readonly RequestDelegate _next;
        public SetRequestPathMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {

            var originalUrl = context.Request.GetDisplayUrl();
            var routeToCallFirst = "api/ShibAuth";

            var updateUrl = (new UriBuilder(originalUrl) { Host = context.Request.Host.Host, Path = routeToCallFirst }).Uri;


            context.Response.Redirect(updateUrl.AbsoluteUri);
            await _next(context);
        }
    }
}
