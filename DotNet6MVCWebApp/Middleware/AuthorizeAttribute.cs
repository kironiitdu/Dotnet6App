using DotNet6MVCWebApp.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Middleware
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(Role item, Permission action)
   : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { item, action };
        }
    }
}
