using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json.Nodes;

namespace RazorPageDemoApp.Pages
{
    [IgnoreAntiforgeryToken]
    public class JqueryDatatableModel : PageModel
    {
        public IEnumerable<SelectListItem>? StoreList { get; set; }
        public Package? Package { get; set; }
        public void OnGet()
        {
            var newLocations = new List<StoreList>()
                 {
                  new StoreList {Id = 1, Name = "Store-1"},
                  new StoreList {Id = 2, Name = "Store-2"},
                  new StoreList {Id = 3, Name = "Store-3"},
                 };
            StoreList = newLocations.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

        }
        public List<ClassLocations> GetLocationsReport()
        {
            var newLocations = new List<ClassLocations>()
                 {
                  new ClassLocations {Id=1,StoreName = "Store-1", PackageName = "Package-1",Contact = "Contact-1" },
                  new ClassLocations {Id=2,StoreName = "Store-2", PackageName = "Package-2",Contact = "Contact-2" },
                  new ClassLocations {Id=3,StoreName = "Store-3", PackageName = "Package-3",Contact = "Contact-3" },

                 };
            return newLocations;
        }

        
        public IActionResult OnPostFetchReport(int PackageID)
        {
            var LocationsReport = new List<ClassLocations>();
           
            if (PackageID != 0)
            {
                LocationsReport = GetLocationsReport();
            }
            
            return new JsonResult(new { data = LocationsReport });
        }
    }
    public class ClassLocations
    {
        public int Id { get; set; }
        public string? StoreName { get; set; }
        public string? PackageName { get; set; }
        public string? Contact { get; set; }
    }

    public class StoreList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Package
    {
        public string Id { get; set; } = string.Empty;
    }
}
