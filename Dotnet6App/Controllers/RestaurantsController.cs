using Dotnet6App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Dotnet6App.Controllers
{
    
    [ApiController]
    public class RestaurantsController : ControllerBase
    {


        [ApiVersion("1.0")]
        [Route("api/Restaurants")]
        [HttpGet]
        public async Task<object> Get()
        {

            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "Kiron Send Grid Test");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("philip.goon@microsoft.com", "Test Email From Send Grid By Kiron");
            var plainTextContent = "This Is Plain Test Email Test";
            var htmlContent = "<strong>This Is HTML Sample Test</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return response;
            //var context = Request.HttpContext;
            //var code = context.Response.StatusCode;
            //if (code == 200)
            //{
            //    return StatusCodes.Status401Unauthorized;
            //}
            //else
            //{
            //    return StatusCodes.Status401Unauthorized;
            //}
            // return new string[] { "Restaurent value1", "Restaurent value2" };
        }
       

        [Route("api/Restaurants")]
        [HttpGet]
        public async Task<bool> AssignDataSource(string Id, CatalogItem dataSource)
        {
            //var uri = new Uri("Http://someaddress/reports/api/V2.0");
            //var networkCredential = new NetworkCredential(@"someuser", @"some password", "");

            //var credentialsCache = new CredentialCache { { uri, "NTLM", networkCredential } };
            //var handler = new HttpClientHandler { Credentials = credentialsCache };

            //var client = new HttpClient(handler) { BaseAddress = uri };
            //var response = await client.GetAsync("reports");
            //return response;

            string json = JsonConvert.SerializeObject(dataSource);
            string test = "api/v2.0/Reports(" + Id + ")/DataSource";
            HttpRequestMessage reqeust = new HttpRequestMessage(HttpMethod.Put, test);
            reqeust.Content = new StringContent(json, Encoding.UTF8,"application/json");
            var client = new HttpClient();
            HttpResponseMessage response = client.SendAsync(reqeust).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

      
       
        [Route("api/Restaurants")]
        [HttpGet]
        public async Task<bool> AssignDataSourceWithHandeler(string Id, CatalogItem dataSource)
        {
            var handler = new HttpClientHandler();
           
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(handler);

            string jsonContent = JsonConvert.SerializeObject(dataSource);

            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Clear();

            var responseFromApi = await client.PutAsync("http://localhost:4400/api/v2.0/Reports(" + Id + ")/DataSource", httpContent);
            if (responseFromApi.IsSuccessStatusCode)
            {
                var data = await responseFromApi.Content.ReadAsStringAsync();
            }
            
            return false;
        }
        //public async Task<IEnumerable<string>> ADALTokenAspNetCore()
        //{
        //    return null;

        //    //var authContext = new AuthenticationContext("https://login.microsoftonline.com/common");
        //    //var result = await authContext.AcquireTokenAsync("https://graph.microsoft.com", "your app id", new Uri("urn:ietf:wg:oauth:2.0:oob"), new PlatformParameters(PromptBehavior.Auto));
        //    //var token = result.AccessToken;
        //    //return new string[] { "Restaurent value1", "Restaurent value2" };
        //}




    }
    public class AccessTokenClass
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public long expires_in { get; set; }
    }
    public class CatalogItem
    {
        public string? Id { get; set; }
    }
}
