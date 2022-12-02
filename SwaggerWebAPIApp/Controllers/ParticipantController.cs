using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.OpenApi.Models;
using SwaggerWebAPIApp.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SwaggerWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateParticipant(Participant participant)
        {

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
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