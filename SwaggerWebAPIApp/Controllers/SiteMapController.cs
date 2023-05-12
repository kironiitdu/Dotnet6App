using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteMapController : ControllerBase
    {
        [HttpGet("GetUserWindowsUserName")]
        public IActionResult GetUserWindowsUserName()
        {
            string gettingWindowsUser = HttpContext.User.Identity?.Name!;
            var responseMessage = string.Format("Current Window User Name: {0}", gettingWindowsUser);
            return Ok(responseMessage);
        }
    }
}
