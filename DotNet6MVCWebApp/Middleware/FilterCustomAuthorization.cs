using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace DotNet6MVCWebApp.Middleware
{
    public class FilterCustomAuthorization : IAuthorizationFilter
    {
        readonly Claim _claim;

        public FilterCustomAuthorization(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Dictionary<string, string> myPermissionList =
                       new Dictionary<string, string>();
            myPermissionList.Add("Role", "CanRead");
            // var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);

            if (!myPermissionList.ContainsValue("CanRead"))
            {
                context.Result = new ForbidResult();
            }
            //if (!hasClaim)
            //{
            //    context.Result = new ForbidResult();
            //}
        }
    }
}
