using Ocelot.Middleware;
using System.Net.Http;
using System.Text;
using System.Web;

namespace DotNet6MVCWebApp.Middleware
{
    public class OcelotMiddleware
    {
        private readonly RequestDelegate _next;
        public OcelotMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var nonASCII = "sömêthìng@example.com";
            var getNonASCII = Encoding.ASCII.GetBytes(nonASCII);
          

           var getNonASCII_Anotherway =  HttpUtility.HtmlEncode(nonASCII);

       // string MessageSignatureValue = Encoding.ASCII.GetString(nonASCII);

            var utf8 = new UTF8Encoding();
            byte[] pass = utf8.GetBytes(nonASCII);
            Console.WriteLine(utf8.GetString(pass));

            //   httpClient.DefaultRequestHeaders.Add("Any Hearder", MessageSignatureValue);
            var header = httpContext.Request.Headers["Authorization"];

            // Move forward into the pipeline
            await _next(httpContext);
        }
    }
}
