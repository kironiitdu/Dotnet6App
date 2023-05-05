using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static DotNet6MVCWebApp.Controllers.TodoController;
using static System.Net.WebRequestMethods;

namespace DotNet6MVCWebApp.Controllers
{
    public class BadRequestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string param_1 = "First Parameter Value";
            string param_2 = "Second Parameter Value";

            var callAPI = AddAdditionalItem(param_1, param_2);
            return Ok(callAPI);
        }
        public async Task AddAdditionalItem(string valueTest1, string valueDateTest1)
        {
            var requestURI = "http://localhost:5094/api/article_list/Create";
            article_list inputSQL = new article_list();
            inputSQL.articlename = "My First Value";
            inputSQL.date = "My Last Value";
            var callMethod = await PostJsonAsync(requestURI, inputSQL);
            //using (var client = new HttpClient())
            //{
            //    // Setting Base address.  
            //    client.BaseAddress = new Uri($"http://localhost:5094/");
            //    // Initialization.  
            //    HttpResponseMessage response = new HttpResponseMessage();

            //    //Bind Model property
            //    article_list inputSQL = new article_list();
            //    inputSQL.articlename = valueTest1;
            //    inputSQL.date = valueDateTest1;
            //    //Call Endpoint
            //    response = await client.PostAsJsonAsync($"api/article_list/Create", inputSQL);
            //    Console.WriteLine(response.StatusCode);
            //    Console.WriteLine(await response.Content.ReadAsStringAsync());
            //    // Verification  
            //    if (response.IsSuccessStatusCode)
            //    {
            //        // Reading Response.  
            //        var result = await response.Content.ReadAsStringAsync();
            //        Console.WriteLine(result);
            //    }


            //}


        }
        public async Task<HttpResponseMessage> PostJsonAsync<T>(string requestUri, T content)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient httpClient = new HttpClient();
            string myContent = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(requestUri, stringContent);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            httpClient.Dispose();
            return response;
        }
        //private async Task AddAdditionalItem(string valueTest1, string valueDateTest1)
        //{
        //    var baseUrl = "";
        //    article_list inputSQL = new article_list();
        //    inputSQL.articlename = valueTest1;
        //    inputSQL.date = valueDateTest1;

        //    var x = await Http.PostJsonAsync(baseUrl + "/api/article_list/create", inputSQL);
        //    Console.WriteLine(x.StatusCode);

        // }


        public class article_list
        {
#nullable enable
            public string? articlename
            {
                get;
                set;
            }
            public string? date
            {
                get;
                set;
            }
        }
    }
}
