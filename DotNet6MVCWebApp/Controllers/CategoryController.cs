using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace DotNet6MVCWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _environment;

        private const string Resource = "https://graph.microsoft.com";

        // Well known ClientID
        private const string ClientId = "1950a258-227b-4e31-a9cf-717495945fc2";

        private static readonly string Tenant = "mytenant.onmicrosoft.com";

        private static readonly HttpProvider HttpProvider = new HttpProvider(new HttpClientHandler(), false);

        private static readonly AuthenticationContext AuthContext = GetAuthenticationContext(Tenant);
        private static AuthenticationContext GetAuthenticationContext(string tenant = null)
        {
            var authString = tenant == null ?
                $"https://login.microsoftonline.com/common/oauth2/token" :
                $"https://login.microsoftonline.com/{tenant}/oauth2/token";

            return new AuthenticationContext(authString);
        }
        //private static GraphServiceClient GetGraphClient(UserPasswordCredential credential)
        //{
        //    var delegateAuthProvider = new DelegateAuthenticationProvider(async (requestMessage) =>
        //    {
        //        var result = AuthContext.TokenCache?.Count > 0 ?
        //            await AuthContext.AcquireTokenSilentAsync(Resource, ClientId) :
        //            await AuthContext.AcquireTokenAsync(Resource, ClientId, credential);
        //        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", result.AccessToken);
        //    });

        //    return new GraphServiceClient(delegateAuthProvider, HttpProvider);
        //}
        public CategoryController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _db = context;
        }
        public IActionResult Index()
        {

            return View();
        }
        public class RefreshTokenClass
        {
            public string token_type { get; set; }
            public string expires_in { get; set; }
            public string resource { get; set; }
            public string scope { get; set; }
            public string access_token { get; set; }
            public string refresh_token { get; set; }

        }

        //public IActionResult GetRefreshTokenGraph()
        //{
        //    string authority = "https://login.microsoftonline.com/adfei.onmicrosoft.com";
        //    string resrouce = "https://graph.microsoft.com";
        //    string clientId = "dfsdfsdfsdf";
        //    string userName = "KironTest";
        //    string password = "12365478";
        //    UserPasswordCredential userPasswordCredential = new UserPasswordCredential(userName, password);
        //    AuthenticationContext authContext = new AuthenticationContext(authority);
        //    var result = authContext.AcquireTokenAsync(resrouce, clientId, userPasswordCredential).Result;
        //    var graphserviceClient = new GraphServiceClient(
        //        new DelegateAuthenticationProvider(
        //            (requestMessage) =>
        //            {
        //                var access_token = authContext.AcquireTokenSilentAsync(resrouce, clientId).Result.AccessToken;
        //                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", access_token);
        //                return Task.FromResult(0);
        //            }));

        //    var a = graphserviceClient.Me.Request().GetAsync().Result;

        //    //simulate the access_token expired to change the access_token
        //    graphserviceClient.AuthenticationProvider =
        //         new DelegateAuthenticationProvider(
        //             (requestMessage) =>
        //             {
        //                 var access_token = "abc";
        //                 requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", access_token);
        //                 return Task.FromResult(0);
        //             });
        //    var b = graphserviceClient.Me.Request().GetAsync().Result;
        //    return null;
        //}
        private async Task<string> GetRefreshToken()
        {

            string tokenUrl = $"https://login.microsoftonline.com/YourTenantIdOrName/oauth2/token";
            var tokenRequest = new HttpRequestMessage(HttpMethod.Post, tokenUrl);

            tokenRequest.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["grant_type"] = "password",
                ["client_id"] = "YourApplicationId",
                ["client_secret"] = "YourApplicationSecret",
                ["resource"] = "https://graph.microsoft.com",
                ["username"] = "YourUsername",
                ["password"] = "YourPass"

            });

            dynamic json;
            dynamic results;

            HttpClient client = new HttpClient();

            var tokenResponse = await client.SendAsync(tokenRequest);

            json = await tokenResponse.Content.ReadAsStringAsync();
            results = JsonConvert.DeserializeObject<RefreshTokenClass>(json);

            Console.WriteLine("Your Refresh Token=>{0}", results.refresh_token);

            return results.refresh_token;
        }
        public async Task<IActionResult> OnPost(Category category)
        {
            if (ModelState.IsValid)
            {
                await _db.Categories.AddAsync(category);
                await _db.SaveChangesAsync();
                return View("Index");
            }
            return View("Index");
        }
        public async Task<IActionResult> AppendRequestHeader()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Clear();

            var message = new HttpRequestMessage(HttpMethod.Get, "https://url/api/someMethod");
            message.Headers.Add("Host", "somesite.site");
            message.Headers.Add("Test", "Test");
            message.Headers.Add("Authorization", "Bearer " + "token_nndafdfad");
          //var response = await httpClient.SendAsync(message);
            Console.WriteLine(message.ToString());
            return Json(message.ToString());
        }
        private class UserPasswordCredential
        {
            private string userName;
            private string password;

            public UserPasswordCredential(string userName, string password)
            {
                this.userName = userName;
                this.password = password;
            }
        }
    }
}
