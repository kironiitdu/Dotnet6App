using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPageDemoApp.Pages
{
    public class OnDropdownValueChangeModel : PageModel
    {
        public static List<SelectListItem> GetAll()
        {
            return new List<SelectListItem>
            {
                new SelectListItem() { Value = "0",  Text = "Please Select Value" },
                new SelectListItem() { Value = "1", Text = "Inventory Catalogue" },
                new SelectListItem() { Value = "2", Text = "Service Catalogue" },
                new SelectListItem() { Value = "3", Text = "Sub-Assembly" },
                new SelectListItem() { Value = "4", Text = "Raw Material" },
                new SelectListItem() { Value = "5", Text = "Finish Good" },
                new SelectListItem() { Value = "6", Text = "Service Catalogue" }
            };
        }
        public List<SelectListItem> selectListItems = new List<SelectListItem>();
        public string? ProductTypeId { get; set; }
        public string? SelectedValue { get; set; }

        public void OnGet()
        {
            selectListItems = GetAll();
        }
        public void OnPostMyMethod()
        {
            var dropdownChangedValue = Request.Form["ProductTypeId"].ToString();
            selectListItems = GetAll();
            var searchSelectedValueFromDropdownList = selectListItems.Where(item => item.Value == dropdownChangedValue).First().Text;
            SelectedValue = searchSelectedValueFromDropdownList;
        }
    }
}
