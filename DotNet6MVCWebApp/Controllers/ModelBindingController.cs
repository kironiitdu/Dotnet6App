using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Controllers
{
    public class ModelBindingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CNumber,CCV,ExpireDate,CustomerId")] CreditCard? creditCard)
        {
            try
            {
                if (ModelState.IsValid)

                {
                   
                    return View("Create");
                }
            }


            catch (Exception ex)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(creditCard);
        }
    }

    public class CreditCard
    {

        [DataType(DataType.CreditCard),
         MaxLength(12, ErrorMessage = "Credit card number must be 12 numbers"),
         MinLength(12, ErrorMessage = "Credit card number must be 12 numbers")]
        public string? CNumber { get; set; }
        [RegularExpression("^\\d{3}$", ErrorMessage = "CCV must be 3 numbers")]

        public int CCV { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }
        


    }
}
