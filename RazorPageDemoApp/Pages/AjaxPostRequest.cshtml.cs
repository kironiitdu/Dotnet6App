using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageDemoApp.Pages
{
    [IgnoreAntiforgeryToken]
    public class AjaxPostRequestModel : PageModel
    {
        public void OnGet()
        {
        }
       
        public ActionResult OnPost([FromBody] List<DepTB> selectedDep)
        {
            // Process data as needed
            return new JsonResult(new { success = true });
        }
    }

    public class DepTB
    {
        public string prop1 { get; set; }
        public string prop2 { get; set; }
    }
}
