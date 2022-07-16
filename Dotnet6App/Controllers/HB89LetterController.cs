using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Dotnet6App.Controllers
{
    [Route("api/CezarPController")]
    [ApiController]
    public class HB89LetterController : ControllerBase
    {
        //public async Task<ActionResult> IsAccountClosed([Required] string nric)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok();

        //}

        [HttpGet]
        public async Task<ActionResult> PostInputUsingArgument(string input, string OutputPath)
        {
            return Ok($"Input: {input}! OutputPath: {OutputPath}");
        }
        //[HttpPost]
        //public async Task<ActionResult> PostInput(Input input)
        //{
        //    return Ok(input);
        //}
        [HttpPost]
        public IActionResult OutfitToevoegen([Required] OutfitVM outfit)
        {

            return Ok(outfit);
        }
    }

    public class Input
    {
        public string InputPropertyName { get; set; }    
        public string OutputPath { get; set; }    
    }
    public class OutfitVM
    {
        public string Prijs { get; set; }
        public string Titel { get; set; }
        public string FileAdress { get; set; }
    }
}
