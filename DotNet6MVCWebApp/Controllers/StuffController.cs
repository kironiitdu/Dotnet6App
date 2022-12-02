using DocumentFormat.OpenXml.InkML;
using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DotNet6MVCWebApp.Controllers
{
    public class StuffController : Controller
    {
        private readonly ApplicationDbContext Context;
        private readonly IWebHostEnvironment _environment;


        public StuffController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            Context = context;
        }

        public IActionResult CreateDynamicButton()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetAllButtonId(List<string> buttonids)
        {
            return Ok(buttonids);
        }

        public class ButtonViewModel
        {
            public List<ButtonClass> listButtons { get; set; }

        }
        public class ButtonClass
        {
            public int buttonids { get; set; }

        }
        public IActionResult Index()
        {
            //CascadingModel model = new CascadingModel();
            //model.Countries = (from customer in this.Context.Countries
            //                   select new SelectListItem
            //                   {
            //                       Value = customer.CountryId.ToString(),
            //                       Text = customer.CountryName
            //                   }).ToList();
            //return View(model);

            //StaffDetailVM detailVM = new StaffDetailVM();
            //detailVM.Countries =  Context.Countries.ToList();
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(int countryId, int stateId, int cityId)
        //{
        //    CascadingModel model = new CascadingModel();
        //    model.Countries = (from customer in this.Context.Countries
        //                       select new SelectListItem
        //                       {
        //                           Value = customer.CountryId.ToString(),
        //                           Text = customer.CountryName
        //                       }).ToList();

        //    model.States = (from customer in this.Context.States
        //                    where customer.CountryId == countryId
        //                    select new SelectListItem
        //                    {
        //                        Value = customer.StateId.ToString(),
        //                        Text = customer.StateName
        //                    }).ToList();

        //    model.Cities = (from customer in this.Context.Cities
        //                    where customer.StateId == stateId
        //                    select new SelectListItem
        //                    {
        //                        Value = customer.CityId.ToString(),
        //                        Text = customer.CityName
        //                    }).ToList();

        //    return View(model);
        //}
        public IActionResult StaffList()
        {
            var staffList = new List<StaffDetailVM>()
            {
                new StaffDetailVM() { StaffId=101,StaffName="Douda", CountryName = "USA",StateName ="New Jersy", CityName ="City In NJ" },
                new StaffDetailVM() { StaffId=102,StaffName="Kiron", CountryName = "UK",StateName ="London", CityName ="Hampe Shire" },
                new StaffDetailVM() { StaffId=103,StaffName="Farid", CountryName = "Canada",StateName ="Alberta", CityName ="Edmonton" },
                new StaffDetailVM() { StaffId=101,StaffName="Jhon", CountryName = "Australia",StateName ="Adelate", CityName ="West Adelate" },
               


            };
            return View(staffList);
        }
            [HttpPost]
        [ActionName("Save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(CascadingModel model)
        {
            if (ModelState.IsValid)
            {
                var newstaffrecords = new StaffDetailVM()
                {
                    StaffId = model.StaffId,
                    StaffName = model.StaffName,
                    CountryName = model.CountryName,
                    StateName = model.StateName,
                    CityName = model.CityName,

                };
                //  this.Context.Stafftbl.Add(newstaffrecords);
               // this.Context.SaveChanges();
            }

            return RedirectToAction("StaffList");
        }
    }


    public class StaffDetailVM
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public List<Country> Countries { get; set; }
        public List<State> States { get; set; }
        public List<City> Cities { get; set; }
    }



    public class CascadingModel
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public  List<Country> Countries { get; set; }
    }
}
