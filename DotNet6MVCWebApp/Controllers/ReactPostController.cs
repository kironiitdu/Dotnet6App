using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class ReactPostController : Controller
    {
        public static List<City> ListCasCadingDropDown = new List<City>()
        {
            //INDIA
            new City() { CountryId =101, CityId =1, CityName = "Delhi" },
            new City() { CountryId =101, CityId =2, CityName = "Haydrabad" },
            new City() { CountryId =101, CityId =3, CityName = "Pune" }, 
            //USA
            new City() { CountryId =102, CityId =4, CityName = "New York" },
            new City() { CountryId =102, CityId =5, CityName = "Silicon Valley" },
            new City() { CountryId =102, CityId =6, CityName = "Dallaus" },
            //UK
            new City() { CountryId =103, CityId =7, CityName = "London" },
            new City() { CountryId =103, CityId =8, CityName = "Cardif" },
            new City() { CountryId =103, CityId =9, CityName = "Sundarland" },
             //Candada
            new City() { CountryId =104, CityId =10, CityName = "Alberta" },
            new City() { CountryId =104, CityId =11, CityName = "Ontario" },
            new City() { CountryId =104, CityId =12, CityName = "Manitoba" },
        };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateSewaPeralatan()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] List<IFormFile> files)
        {
            return Ok(files);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeeSchedule([FromBody] FeeScheduleRequest1Dto model)
        {
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public IActionResult CreateSewaPeralatan([FromBody] Sewa model)
        {

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<JsonResult> CascadeDropDowns(string type, int id)
        {
            var mdoel2 = ListCasCadingDropDown.Where(t => t.CityName == type || t.CountryId == id).ToList();
            return Json(mdoel2);
        }

        public IActionResult CascadingDropdown()
        {

            return View();
        }
        public IActionResult CalculateRequestGetError()
        {

            return View();
        }



    }

    public class FeeScheduleRequest1Dto
    {

        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
    }
    public class Sewa
    {

        public string NotaSewa { get; set; }
        public int PelangganId { get; set; }
        public string TempatAcara { get; set; }
    }

    public class DocumentDto
    {
        public List<IFormFile> Files { get; set; } = new List<IFormFile>();
        //public string ProductName { get; set; }
        //public string ProductCode { get; set; }
        //public decimal Productprice { get; set; }
    }
}
