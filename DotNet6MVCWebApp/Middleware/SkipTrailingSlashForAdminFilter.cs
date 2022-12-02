using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNet6MVCWebApp.Middleware
{
    public class SkipTrailingSlashForAdminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var originalUrl = filterContext.HttpContext.Request.Path.ToString();
            var newUrl = originalUrl.TrimEnd('/');
            if (originalUrl.Length != newUrl.Length)
                filterContext.HttpContext.Response.Redirect(newUrl);
        }

    }
}
