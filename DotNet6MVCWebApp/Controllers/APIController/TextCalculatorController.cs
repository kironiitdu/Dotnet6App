using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextCalculatorController : ControllerBase
    {
        [HttpPost]
        public string Calculate([FromBody] FromBodyRequestModel model)
        {
            return new TextCalculator().Add(model.input);
        }
    }

    public class TextCalculator
    {
        public string Add(string input)
        {
            var bindwithInput = "You Have Entered:";
            return bindwithInput + input;
        }

    }

    public class FromBodyRequestModel
    {
        public string input { get; set; }
    }
}
