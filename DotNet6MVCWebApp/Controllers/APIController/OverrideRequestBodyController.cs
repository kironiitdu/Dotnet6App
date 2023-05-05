using DotNet6MVCWebApp.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System.Net;
using static DotNet6MVCWebApp.Middleware.OverrideResponseBodyMiddleware;

namespace DotNet6MVCWebApp.Controllers.APIController
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class OverrideRequestBodyController : ControllerBase
    {
       
        [HttpPost]
        public IActionResult OverrideRequestBody([FromBody] ApiCustomResponseClass responseClass)
        {

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add("Content-Type", "application/json");
                webClient.Headers.Add("x-access-token", apikey);

                string reponse = webClient.DownloadString("https://www.goldapi.io/api/XAU/USD");//      <= 403 Forbidden here
                dynamic dobj = JsonConvert.DeserializeObject<dynamic>(reponse);
                var temp = dobj["price"];
                Console.WriteLine(reponse);
                return Ok(responseClass);
            }
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        static string apikey = "goldapi-c4c4rleia2owq-io";
    }


    
}
