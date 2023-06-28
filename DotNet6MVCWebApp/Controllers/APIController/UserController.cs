using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("EditAddress")]
        public IActionResult Post([FromBody] UpdateAddressModel model)
        {
            return Ok(model.Email);
        }
    }


    public class UpdateAddressModel
    {
        public string? Email { get; set; }
    }
}
