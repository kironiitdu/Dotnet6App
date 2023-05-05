using DocumentFormat.OpenXml.Wordprocessing;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Controllers
{
    public class DatetimeIssueController : Controller
    {
        public IActionResult Index()
        {
            TicketViewModel ticketViewModel = new TicketViewModel();

            TicketDetails ticketDetails = new TicketDetails();
            ticketDetails.StartDate = DateTime.Today;

            ticketViewModel.TicketDetails = ticketDetails;
            return View(ticketViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketDetails ticketDetails)
        {
            return RedirectToAction("Index");
        }
    }
    public class TicketViewModel
    {
        public TicketDetails TicketDetails { get; set; }
    }

        public class TicketDetails
    {


        [Display(Name = "No Start Date")]
        public bool NoStartDate { get; set; } = true;

        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yy}")]
        public DateTime? StartDate { get; set; } = null;


    }
}
