using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace DotNet6MVCWebApp.Controllers
{
    public class DropdownLeaveEmptyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public DropdownLeaveEmptyController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        public IActionResult Index()
        {
            var catquery = _context.Categories;

           SelectList ToolCategories = new SelectList(catquery, "CategoryId", "CategoryName");
            ViewBag.ToolCategories = ToolCategories;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> entityTypeList = new List<SelectListItem>();
            entityTypeList.Add(new SelectListItem { Text = "Client-A", Value = "Client-A" });
            entityTypeList.Add(new SelectListItem { Text = "Client-B", Value = "Client-B" });
            entityTypeList.Add(new SelectListItem { Text = "Client-C", Value = "Client-C" });

            ViewBag.ClientsSelectList = entityTypeList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientID,ClientName,PhoneNumber")] ClientModel client)
        {
            try
            {
                if (ModelState.IsValid)

                {
                
                    ModelState.Clear();
                    ModelState.AddModelError("", "Successfully added.");
                    return RedirectToAction("Create");
                }
         
                return RedirectToAction("Create");
            }


            catch (Exception ex)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            return View("Create");
        }
    }

    public class ClientModel
    {
 
        public string? ClientID { get; set; }
        [Required]
        [StringLength(5,ErrorMessage ="Name Required can not be less than 5")]
        public string ClientName { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "No more than 11 and must be number")]
        public string PhoneNumber { get; set; }
    
    }
}
