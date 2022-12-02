using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestController : ControllerBase
    {
        [HttpPost("issue/{issue}/attachments")]
        public IActionResult Rest([FromRoute]string issue, [FromBody]string attachments)
        {
            return Ok(attachments);
        }

        [HttpPost]
        [Route("CreateException")]
        public async Task<IActionResult> CreateException([FromBody] string obj)
        {
            //await _exceptionDetailsService.AddExceptionDetails(exceptionDetails);
            return Ok();
        }
    }
    
}
