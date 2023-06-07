using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPageDemoApp.Pages
{
    [IgnoreAntiforgeryToken]
    public class Ajax400RequestModel : PageModel
    {
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostUpdateQuantity(string barcode, int palletQuantity, int bagQuantity)
        {
            return new JsonResult(new { success = true });
        }
       
    }
}
