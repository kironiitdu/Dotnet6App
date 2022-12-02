using Azure.Core;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.Graph.TermStore;
using System.Net;

namespace DotNet6MVCWebApp.Middleware
{
    public class RestrictLoginFromCertainDomainMiddleware
    {
        private readonly RequestDelegate _next;

        public RestrictLoginFromCertainDomainMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
           
            var pathToRestrict = "/login";

            var host = httpContext.Request.Host.Host;

            var path = httpContext.Request.Path.Value?.ToLower();
         
            var completePath = host + path;

            if (completePath.Contains(pathToRestrict.ToLower()))
            {
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await httpContext.Response.WriteAsync("Unauthorized!");
            }
            
            await _next(httpContext);
        }
    }
}
