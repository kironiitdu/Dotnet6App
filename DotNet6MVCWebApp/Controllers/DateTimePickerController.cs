using DotNet6MVCWebApp.Models;
using Itenso.TimePeriod;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace DotNet6MVCWebApp.Controllers
{
    public class DateTimePickerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookAppointment([FromForm] CreateAppointmentRequest requestModel)
        {
            var date = requestModel.Date.ToShortDateString();
            var hour = requestModel.Time.Hour;
            var min = requestModel.Time.Minute;
            var time = hour + ":" + min;

            var dateTime = string.Format("Date: {0}, Time:{1}", date, time);
            return Ok(dateTime);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAppointmentRequest requestModel)
        {
            try
            {
                // string dddd = requestModel.Date.ToString("dd/M/yyy", CultureInfo.InvariantCulture);

                var date = requestModel.Date.ToShortDateString();
                var hour = requestModel.Time.Hour;
                var min = requestModel.Time.Minute;
                var time = hour + ":" + min;
                if (ModelState.IsValid)

                {

                    return View("Index");
                }
            }


            catch (Exception ex)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(Index);
        }
    }


    public class CreateAppointmentRequest
    {
       
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }


        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
    }
}
