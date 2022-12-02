using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Graph;
using System.Text.Encodings.Web;

namespace DotNet6MVCWebApp.Controllers
{
    public class RedirectToWrongController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public RedirectToWrongController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        [HttpGet]
        public IActionResult AddSchedule(int id)
        {
            EventScheduleViewModel viewModel = new EventScheduleViewModel();
            //viewModel.Event = _db.Events.Find(id);
            //viewModel.Client = _db.Clients.Find(viewModel.Event.ClientId);
            //viewModel.EmployeeSchedule = new ScheduleDisplayDetails();
            //viewModel.EmployeeSchedule.StartTime = viewModel.Event.StartTime;
            //viewModel.EmployeeSchedule.EndTime = viewModel.Event.EndTime;
            //viewModel.EmployeeList = _db.Employees.ToList();

            //viewModel.Schedules = (from es in _db.EventSchedules
            //                       join s in _db.Schedules on es.ScheduleId equals s.Id
            //                       join e in _db.Employees on s.EmployeeId equals e.Id
            //                       where es.EventId == viewModel.Event.Id
            //                       select new ScheduleDisplayDetails
            //                       {
            //                           ScheduleId = s.Id,
            //                           EmployeeId = s.EmployeeId,
            //                           EmployeeName = e.Name,
            //                           StartTime = s.StartTime,
            //                           EndTime = s.EndTime
            //                       }).ToList();
            return View(viewModel);
        }
        //[HttpPost]
        //public IActionResult AddSchedule(EventScheduleViewModel viewModel)
        //{
        //    //ModelState.Clear();
        //    //viewModel.Event = _db.Events.Find(viewModel.Event.Id);
        //    //viewModel.Client = _db.Clients.Find(viewModel.Client.Id);

        //    ///*I have multiple error checks here that use temp data and I suspect this is why action 
        //    //  is always getting called when the page loads.*/
        //    //if (viewModel.EmployeeSchedule.EmployeeId == 0)
        //    //{
        //    //    TempData["Error"] = "Please select the employee you would like to add to schedule";
        //    //    return View("AddSchedule", viewModel);
        //    //}

        //    ////more validation checks here

        //    //Schedule scheduleToAdd = new Schedule()
        //    //{
        //    //    EmployeeId = viewModel.EmployeeSchedule.EmployeeId,
        //    //    StartTime = viewModel.EmployeeSchedule.StartTime,
        //    //    EndTime = viewModel.EmployeeSchedule.EndTime
        //    //};
        //    //_db.Schedules.Add(scheduleToAdd);
        //    //_db.SaveChanges();

        //    //EventSchedule eventScheule = new EventSchedule()
        //    //{
        //    //    EventId = viewModel.Event.Id,
        //    //    ScheduleId = scheduleToAdd.Id
        //    //};
        //    //_db.EventSchedules.Add(eventScheule);
        //    //_db.SaveChanges();

        //    //ScheduleDisplayDetails employeeSchedule = new ScheduleDisplayDetails()
        //    //{
        //    //    ScheduleId = scheduleToAdd.Id,
        //    //    EmployeeId = viewModel.EmployeeSchedule.EmployeeId,
        //    //    EmployeeName = viewModel.EmployeeSchedule.EmployeeName,
        //    //    StartTime = viewModel.EmployeeSchedule.StartTime,
        //    //    EndTime = viewModel.EmployeeSchedule.EndTime
        //    //};

        //    //if (viewModel.Schedules == null)
        //    //{
        //    //    viewModel.Schedules = new List<ScheduleDisplayDetails>();
        //    //    viewModel.Schedules.Add(employeeSchedule);
        //    //}
        //    //else
        //    //{
        //    //    viewModel.Schedules.Add(employeeSchedule);
        //    //}
        //    return View("AddSchedule", viewModel);
        //}
        public IActionResult LoadView()
        {
            RegisterModel registerModel = new RegisterModel();
            return View(registerModel);
        }
        public async Task<IActionResult> Index(string searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
               // var result = _context.Movie.Where(m => m.Title!.Contains(searchText));
                var result = _context.Animals.Where(m => m.Name!.Contains(searchText));
                return View(result);
            }

            return View();
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync())
            //                                      .ToList();
            //if (ModelState.IsValid)
            //{
            //    var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
            //    var result = await _userManager.CreateAsync(user, Input.Password);
            //    if (result.Succeeded)
            //    {
            //        _logger.LogInformation("User created a new account with password.");

            //        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            //        var callbackUrl = Url.Page(
            //            "/Account/ConfirmEmail",
            //            pageHandler: null,
            //            values: new { area = "Identity", userId = user.Id, code = code },
            //            protocol: Request.Scheme);

            //        await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
            //            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            //        if (_userManager.Options.SignIn.RequireConfirmedAccount)
            //        {
            //            return RedirectToPage("RegisterConfirmation",
            //                                  new { email = Input.Email });
            //        }
            //        else
            //        {
            //            await _signInManager.SignInAsync(user, isPersistent: false);
            //            return LocalRedirect(returnUrl);
            //        }
            //    }
            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError(string.Empty, error.Description);
            //    }
            //}

            // If we got this far, something failed, redisplay form
            return View();
        }
        //[HttpPost]
        //public IActionResult RemoveSchedule(int? id)
        //{
        //    //var selectedSchedule = _db.Schedules.Find(id);
        //    //EventSchedule eventSchedule = _db.EventSchedules.Where(es => es.ScheduleId == id).FirstOrDefault();
        //    //var eventId = eventSchedule.EventId;

        //    //if (selectedSchedule != null)
        //    //{
        //    //    _db.Schedules.Remove(selectedSchedule);
        //    //    _db.EventSchedules.Remove(eventSchedule);
        //    //    _db.SaveChanges();
        //    //}
        //  //  return RedirectToAction("AddSchedule", new { id = id });
        //    return RedirectToAction("AddSchedule",id);
        //    //redirects to AddSchedule post action
        //}
    }

    public class EventScheduleViewModel
    {
        public int Id { get; set; }
       
    }
}
