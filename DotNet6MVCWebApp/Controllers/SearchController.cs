using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using DataType = System.ComponentModel.DataAnnotations.DataType;

namespace DotNet6MVCWebApp.Controllers
{
    public class SearchController : Controller
    {
        public static List<Class01Name> listOfClass01Name = new List<Class01Name>()
        {
            new Class01Name() { Id =101, String01Name ="Titanic",String02Name = "Romantic", Int01Name =01, Bool01Name = false, DateTime01Name = new DateTime(2023-01-15) },
            new Class01Name() { Id =102, String01Name ="Forest gump",String02Name = "Motivational", Int01Name =02, Bool01Name = true, DateTime01Name = new DateTime(2023-01-12) },
            new Class01Name() { Id =103, String01Name ="Spider Man",String02Name = "Action", Int01Name =03, Bool01Name = false, DateTime01Name = new DateTime(2023-01-10) },
            new Class01Name() { Id =104, String01Name ="Harry Potter",String02Name = "Suspense", Int01Name =04, Bool01Name = true, DateTime01Name = new DateTime(2023-01-13)},

        };

        public  List<SelectListItem> String02NameSelectionList = new List<SelectListItem>()
        {
             new SelectListItem { Text = "Motivational", Value = "Motivational" },
             new SelectListItem { Text = "Romantic", Value = "Romantic" },
             new SelectListItem { Text = "Action", Value = "Action" },
             new SelectListItem { Text = "Comedy", Value = "Comedy" }
        };

       

public async Task<IActionResult> Index2(string String02NameSelected, string searchString)
        {


            if (String02NameSelected == "All" && searchString == null)
            {
              
                var dataWithoutfileter = new SearchByGroupName();
                dataWithoutfileter.String02NameSelection = new SelectList(String02NameSelectionList, "Text", "Value");
                dataWithoutfileter.Class01NameList = listOfClass01Name;
                return View(dataWithoutfileter);
            }

          
            if (!String.IsNullOrEmpty(String02NameSelected) && String02NameSelected !="All")
            {
                var objOfClass = new SearchByGroupName();
                var string02NameQuery = listOfClass01Name.Where(m => m.String01Name.ToLower().Contains(String02NameSelected.ToLower()) || m.String02Name.ToLower().Contains(String02NameSelected.ToLower()));
                objOfClass.Class01NameList = string02NameQuery.ToList();

                objOfClass.String02NameSelection = new SelectList(String02NameSelectionList, "Text", "Value");


                return View(objOfClass);
            }


            if (!String.IsNullOrEmpty(searchString))
            {
                var objOfClass = new SearchByGroupName();
                var string02NameQuery = listOfClass01Name.Where(m => m.String01Name.ToLower().Contains(searchString.ToLower()) || m.String02Name.ToLower().Contains(searchString.ToLower()));
                objOfClass.Class01NameList = string02NameQuery.ToList();

                objOfClass.String02NameSelection = new SelectList(String02NameSelectionList, "Text", "Value");


                return View(objOfClass);
            }

            //First loading
            var objSearchByGroupName = new SearchByGroupName();
            objSearchByGroupName.String02NameSelection = new SelectList(String02NameSelectionList, "Text", "Value");
            objSearchByGroupName.Class01NameList = listOfClass01Name;
            return View(objSearchByGroupName);


           
        }
    }
    public class Class01Name
    {
        public int Id { get; set; }

        public string? String01Name { get; set; }

        public string? String02Name { get; set; }

        public int? Int01Name { get; set; }

        public bool? Bool01Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateTime01Name { get; set; }

    }
    public class SearchByGroupName
    {
        public List<Class01Name>? Class01NameList { get; set; }                
        public SelectList? String02NameSelection { get; set; }                
        public string? String02NameSelected { get; set; }                   
        public string? SearchString { get; set; }                            
    }
}
