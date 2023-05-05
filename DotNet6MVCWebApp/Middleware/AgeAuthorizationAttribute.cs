using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Middleware
{
    public class AgeAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public AgeAuthorizationAttribute(int age)
        { 
        
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }

    
}

