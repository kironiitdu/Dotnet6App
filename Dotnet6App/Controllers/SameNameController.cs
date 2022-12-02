using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet6App.Controllers
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
