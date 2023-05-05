using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace SwaggerWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {

        [HttpPost("NewFromFormUpload")]
        public async Task<IActionResult> NewFromFormUpload([FromForm] IFormFile file, [FromForm] FileMetaDataDto metaData)
        {
            return Ok();
        }
        
    }

    public class FileMetaDataDto
    {
        public string Name { get; set; }
    }
}
