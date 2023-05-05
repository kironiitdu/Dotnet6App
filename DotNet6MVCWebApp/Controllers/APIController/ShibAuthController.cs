using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShibAuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {

            var message = "From ShibAuth";
            return Ok(message);

        }
    }
}
