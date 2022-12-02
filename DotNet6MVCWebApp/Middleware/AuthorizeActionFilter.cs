using DotNet6MVCWebApp.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace DotNet6MVCWebApp.Middleware
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
       
        public  void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (!HttpMethods.IsGet(filterContext.HttpContext.Request.Method))
            {
                filterContext.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
            else
            {
                var optionsAccessor = filterContext.HttpContext.RequestServices.GetRequiredService<IOptions<MvcOptions>>();

                var request = filterContext.HttpContext.Request;

                var host = request.Host;
                if (optionsAccessor.Value.SslPort.HasValue && optionsAccessor.Value.SslPort > 0)
                {
                    // a specific SSL port is specified
                    host = new HostString(host.Host, optionsAccessor.Value.SslPort.Value);
                }
                else
                {
                    // clear the port
                    host = new HostString(host.Host);
                }

                var permanentValue = optionsAccessor.Value.RequireHttpsPermanent;

                var newUrl = string.Concat(
                    "http://",
                    host.ToUriComponent(),
                    request.PathBase.ToUriComponent(),
                    request.Path.ToUriComponent(),
                    request.QueryString.ToUriComponent());

                // redirect to HTTPS version of page
                filterContext.Result = new RedirectResult(newUrl, permanentValue);
             
            }

            ////var isAuthorized = context.HttpContext.User.Claims.Any(c => c.Type == _role.ToString() && c.Value == _permission.ToString());
            //var isAuthorized = context.HttpContext.User.Claims.Any(c => c.Type != null && c.Value != null);

            //if (!isAuthorized)
            //{
            //   // context.HttpContext.Request.Path= "/Login/Login";
            //    context.HttpContext.Response.Redirect("/Team/Index");
            //   // context.Result = new UnauthorizedResult();
            //}

        }
    }
}
