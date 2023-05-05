using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;
using System.Net;

namespace RazorPageDemoApp.Middleware
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
            var supportedCultures = new[] { "en-US", "fr" }; 
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0]).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures); 
            //.UseRequestLocalization(localizationOptions);


            var endpoint = context.GetEndpoint();

            var routeURL = context.Request.Path.ToString();
            var host = context.Request.Host;
            var fullRoute = host + routeURL;
            if (routeURL != "/" && !routeURL.Contains("error"))
            {
                Uri requestedRoute = new Uri(fullRoute);

                string[] firstRoute = requestedRoute.Segments;
                string cultureRequested = firstRoute[1];
                var culture = cultureRequested.TrimEnd('/');


                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

                if (!cultureInfo.Name.Contains(culture))
                {

                    context.Response.Redirect("/error/404");
                    await context.Response.CompleteAsync();

                }
            }

            await next(context);
        }
    }
}
