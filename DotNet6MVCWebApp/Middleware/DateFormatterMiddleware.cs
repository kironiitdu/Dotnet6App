using System;
using System.Globalization;
using System.Net.Http.Headers;


namespace DotNet6MVCWebApp.Middleware
{
    public class DateFormatterMiddleware
    {
        private readonly RequestDelegate next;
        public DateFormatterMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var userLanguages = context.Request.Headers.AcceptLanguage;
            var selectLan = userLanguages.ToString();


            var languages = selectLan.Split(',')
                .Select(StringWithQualityHeaderValue.Parse)
                .OrderByDescending(s => s.Quality.GetValueOrDefault(1));
            var userLan = languages.Select(val => val.Value).ToList();

            foreach (var item in userLan)
            {
                DateTime currentDate = DateTime.Now;

                if (item.Contains("en-US") || item.Contains("it-IT"))
                {
                    if (item == "en-US")
                    {
                        var enUS_Format = currentDate.ToString("MM-dd-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                        context.Session.SetString("DateFormat", enUS_Format);
                        break;
                    }
                    if (item == "it-IT")
                    {
                        var italy_Format = currentDate.ToString("dd-MM-yyyy", CultureInfo.CreateSpecificCulture("it-IT"));
                        context.Session.SetString("DateFormat", italy_Format);
                        break;
                    }


                }
            }
            await next(context);
        }
    }
}
