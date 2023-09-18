using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RazorPageDemoApp.Pages
{
    public class AjaxPostRequestModel : PageModel
    {
        [BindProperty]
        public DemoModelClass? FormValue { get; set; }
        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {

            var checkSubmittedVaue = FormValue;
            // Process data as needed
            // Call your database layer 
            return new JsonResult(new { success = true });
        }

    }



    public class DemoModelClass
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


    }




    //public ActionResult OnPost([FromBody] List<DemoModelClass> selectedDep)
    //{
    //    // Process data as needed
    //    // Call your database layer 
    //    return new JsonResult(new { success = true });
    //}
}
