using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentRequestController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> BookAppointment([FromForm] CreateAppointmentRequestModel requestModel)
        {
            var date = requestModel.Date.ToShortDateString();
            var hour = requestModel.Time.Hour;
            var min = requestModel.Time.Minute;
            var time = hour + ":" + min;

            var dateTime = string.Format("Date: {0}, Time:{1}", date, time);
            return Ok(dateTime);
        }
    }
    public class CreateAppointmentRequestModel
    {

        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }


        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
    }
}
