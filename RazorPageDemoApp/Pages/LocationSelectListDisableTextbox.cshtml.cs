using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPageDemoApp.Pages
{
    public class LocationSelectListDisableTextboxModel : PageModel
    {
        public static List<SelectListItem> GetAll()
        {
            return new List<SelectListItem>
            {
                new SelectListItem() { Value = "0", Text = "Please Select Value" },
                new SelectListItem() { Value = "1", Text = "Location-A" },
                new SelectListItem() { Value = "2", Text = "Location-B" },
                new SelectListItem() { Value = "3", Text = "Location-C" },
                new SelectListItem() { Value = "4", Text = "Disable Textbox" }

            };
        }

        public List<SelectListItem> selectListItems = new List<SelectListItem>();
        public void OnGet()
        {
            selectListItems = GetAll();

        }
    }
}
