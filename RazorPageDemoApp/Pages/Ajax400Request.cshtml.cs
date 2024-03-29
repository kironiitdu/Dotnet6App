using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPageDemoApp.Pages
{
    [IgnoreAntiforgeryToken]
    public class Ajax400RequestModel : PageModel
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
