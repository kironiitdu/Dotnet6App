using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;

namespace SwaggerWebAPIApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        //[HttpPost]
        //public async Task<IActionResult> CancelItems([FromBody] StringCompatibleClass items)
        //{
        //    return Ok(items);
        //}
        //[HttpPost]
        //public async Task<IActionResult> CancelItems([FromBody] List<string> items)
        //{
        //    return Ok(items);
        //}

    }

    public class StringCompatibleClass
    {

        public List<string> items { get; set; }
    }

}