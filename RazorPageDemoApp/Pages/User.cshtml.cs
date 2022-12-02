using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;

namespace RazorPageDemoApp.Pages
{
    public class UserModel : PageModel
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserUrl{ get; set; }
        public string? ReturnUrl { get; set; }
        
        public void OnGet(string userUrl = null)
        {
            string userURL = "localhost:7062/User?userUrl=";
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            var host = HttpContext.Request.Host;
            var path = HttpContext.Request.Path;
            var absolutepath = host + path;
            returnUrl = returnUrl ?? Url.Content("~/");
           

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
