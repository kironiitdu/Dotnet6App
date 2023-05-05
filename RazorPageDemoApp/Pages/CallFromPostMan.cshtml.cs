using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageDemoApp.Pages
{
    [IgnoreAntiforgeryToken]
    public class CallFromPostManModel : PageModel
    {
        public void OnGet()
        {
        }
       
        public IActionResult OnPost()
        {

            Console.WriteLine("in post");
            // return Page();
            var message = "From Razor Page";
            return new OkObjectResult(message);

        }
    }
}
