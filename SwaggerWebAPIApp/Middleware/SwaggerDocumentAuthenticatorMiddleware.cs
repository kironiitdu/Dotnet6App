using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using System.Net;

namespace SwaggerWebAPIApp.Middleware
{
    public class SwaggerDocumentAuthenticatorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly LinkGenerator _linkGenerator;

        public SwaggerDocumentAuthenticatorMiddleware(RequestDelegate next, LinkGenerator linkGenerator)
        {
            _next = next;
            _linkGenerator = linkGenerator;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {

            UrlActionContext urlActionContext = new UrlActionContext();
            urlActionContext.Controller = "UnAuthorizedPage";
            urlActionContext.Action = "Index";
            string? unAuthorizedUrl = _linkGenerator.GetUriByAction(httpContext, action: urlActionContext.Action, controller: urlActionContext.Controller, null, httpContext.Request.Scheme);
            
            if (httpContext.Request.Path.StartsWithSegments("/swagger"))
            {
                var azureAdUser = httpContext.User.Claims;
                var identityUser = httpContext.User.Identity?.IsAuthenticated;
                
                if (azureAdUser== null || identityUser == false)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    httpContext.Response.Redirect(unAuthorizedUrl);
                    return;
                }
               

            }


            await _next(httpContext);

        }
    }
}
