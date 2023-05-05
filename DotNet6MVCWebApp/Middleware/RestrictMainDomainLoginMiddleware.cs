using DocumentFormat.OpenXml.InkML;

namespace DotNet6MVCWebApp.Middleware
{
    public class RestrictMainDomainLoginMiddleware
    {
        private readonly RequestDelegate _next;

        public RestrictMainDomainLoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var myError = @"""Test Error Message""";
            
            var newErrorMessage = myError.Trim('"');

            httpContext.Response.Headers.Add("authorization", "Kiron Test Auth Header");

            //var pathToRestrict = "/login";

            //if (httpContext.Request.Path.StartsWithSegments(pathToRestrict))
            //{

            //    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //    await httpContext.Response.WriteAsync("Unauthorized!");

            //}

            await _next(httpContext);
        }
    }
}

