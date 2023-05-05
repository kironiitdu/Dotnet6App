using System.Globalization;

namespace DotNet6MVCWebApp.Middleware
{
    public class CheckCultureAndRouteThenRedirect
    {
        private readonly RequestDelegate next;
        public CheckCultureAndRouteThenRedirect(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            
            await next(context);
        }
    }
}
