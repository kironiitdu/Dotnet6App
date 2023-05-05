using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static DotNet6MVCWebApp.Middleware.OverrideResponseBodyMiddleware;
using System.Net;
using static DotNet6MVCWebApp.Middleware.ReadRequestBodyMiddleware;
using System.Runtime.Serialization;
using System.Text.Json;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadRequestBodyController : ControllerBase
    {
        [HttpPost]
        public IActionResult ReadRequestBody([FromBody] RequstBodyReaderModel readRequestBody)
        {

            return Ok(readRequestBody);
        }

        //[HttpPost]
        //public IActionResult WihtoutjsonIgnore([FromBody] Foo withoutJsonIgnore)
        //{
        //    var json = System.Text.Json.JsonSerializer.Serialize(withoutJsonIgnore);

        //    return Ok(withoutJsonIgnore);
        //}

    }

    [DataContract]
    public class Foo
    {
        
        public Func<int>? DoCalculation { get; init; }
        
        public string? AnotherProp { get; init; }

        [DataMember]
        public string Bar { get; init; }
    }
}
