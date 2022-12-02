using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SameNameController : ControllerBase
    {

        [HttpPost]
        public IEnumerable<IActionResult> SameNameAction([FromBody] dynamic data)
        {
            yield return Ok();
        }
    }
}
