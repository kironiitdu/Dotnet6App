using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityXMLController : ControllerBase
    {
       
       // [Produces("application/xml")]
        public IActionResult GetCity()
        {
            var cityList = new List<City>() 
            { 
                new City { Id = 101, Name = "Alberta" },
                new City { Id = 102, Name = "Toronto" },
                new City { Id = 103, Name = "British Comlombia" },
            };
            return Ok(cityList);
        }
    }


    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
