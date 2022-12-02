using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DotNet6MVCWebApp.Middleware
{
    public class CustomAuthorizationMiddleware : TypeFilterAttribute
    {
        public CustomAuthorizationMiddleware(string claimType, string claimValue) : base(typeof(FilterCustomAuthorization))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }
}
