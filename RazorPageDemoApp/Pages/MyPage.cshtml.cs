using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageDemoApp.Pages
{
    public class MyPageModel : PageModel
    {
        //public MyDTOObject? Trace { get; set; }
        public int Id { get; set; }
        public string Guidvalue { get; set; }
        public async Task<IActionResult> OnGetAsync(int id, string guidvalue)
        {
            Id = id;
            Guidvalue = guidvalue;
            return Page();
        }
    }
}
