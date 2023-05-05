using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.OpenApi.Models;
using SwaggerWebAPIApp.Middleware;
using SwaggerWebAPIApp.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SwaggerWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        //[HttpPost]
        //public async Task<IActionResult> CreateParticipant(Participant participant)
        //{

        //    return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        //}


        //[HttpGet("{requestId}", Name = "GetStatus")]
        //public virtual IActionResult GetStatus([FromHeader][Required()] string authorization, [FromRoute][Required] string requestId)
        //{
        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "My Token");
        //    return Ok();
        //}


        [HttpPost]
        public IActionResult Insert(Customer customer)
        {
            if (ModelState.IsValid)
            {

            }
            return Ok(customer);
        }


    }

    public class Customer
    {
        [Required]

        [MinLength(5,ErrorMessage ="Must be min 5 digit")]
        public string CustomerId { get; set; }

   

    }
    public record Person
    {
        [Required]
        public string email { get; set; }
      
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
       
    }


    public partial class Participant
    {
        public int ParticipantId { get; set; }
        public string ParticipantName { get; set; }
        // [JsonIgnore]
        public virtual StudyParticipant? StudyParticipant { get; set; }
    }

    public class StudyParticipant
    {
        public int StudyParticipantId { get; set; }
        public string StudyParticipantName { get; set; }
    }


    public class IParticipantMD
    {

        public virtual StudyParticipant? StudyParticipant { get; set; }
    }
}