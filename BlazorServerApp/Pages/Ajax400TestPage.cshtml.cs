using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorServerApp.Pages
{
    [IgnoreAntiforgeryToken]
    public class Ajax400TestPageModel : PageModel
    {
        public IActionResult OnPostTest()
        {

            return Content("Success", "text/plain");
        }

        public IActionResult OnGetTest()
        {
            return Content("Success", "text/plain");
        }
    }
}
