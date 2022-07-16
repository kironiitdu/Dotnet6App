using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    [Route("api/FromQueryAttributeAPI")]
    [ApiController]
    public class FromQueryAttributeAPIController : ControllerBase
    {
        [HttpGet("search")]
        public IActionResult Search([FromQuery] MovieQuery movieQuery)
        {
            //Console.WriteLine($"name={movieQuery.Name} year={movieQuery.Year}");
            return Ok($"name={movieQuery.Name} year={movieQuery.Year}");
        }
    }

    public class MovieQuery
    {
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
