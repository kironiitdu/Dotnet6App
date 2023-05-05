using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SwaggerWebAPIApp.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{apiVersion}/[controller]")]
    [ApiController]
    public class MyContentController : ControllerBase
    {

        [AllowAnonymous]
        [HttpGet("Getcontent")]
        public async Task<ActionResult> Getcontent([FromQuery] MyModel model)
        {

            return Ok(model);

        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string userName, string password)
        {

            if (userName == null || password == null)
            {
                return BadRequest();
            }


            return Ok();
        }

    }

}

public class MyModel
{
    public string MyName { get; set; }
    public string MySchool { get; set; }
}



