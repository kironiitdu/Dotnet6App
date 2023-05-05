using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageDemoApp.Pages
{
    public class NullReferenceExceptionModel : PageModel
    {
        List<string> months = new List<string>();
        public DateTime date { get; set; }

        public int num = 4;// --> also this give the same error if i try to put in the h1 tag
        public DateTime specificDate { get; set; }

        public void OnGet()
        {
            date = DateTime.Now;
            specificDate = new DateTime(2022, 08, 01);
        }
    }
}
