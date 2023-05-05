using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNet6MVCWebApp.Controllers
{
    public class AppendTextAreaController : Controller
    {
        public IActionResult Index()
        {

            
            //List<SelectListItem> entityTypeList = new List<SelectListItem>();
            //entityTypeList.Add(new SelectListItem { Text = "Select Type", Value = "Select Type" });
            //entityTypeList.Add(new SelectListItem { Text = "Entity-Type-C#", Value = "Entity-Type-C#" });
            //entityTypeList.Add(new SelectListItem { Text = "Entity-Type-SQL", Value = "Entity-Type-SQL" });
            //entityTypeList.Add(new SelectListItem { Text = "Entity-Type-Asp.net core", Value = "Entity-Type-Asp.net core" });
            List<string> MySpecialAreaPathsList = new List<string>();
            MySpecialAreaPathsList.Add("C#");
            MySpecialAreaPathsList.Add("SQL");
            MySpecialAreaPathsList.Add("Asp.net core");
            ViewBag.myAreaPathsList = MySpecialAreaPathsList;
            return View();
        }
        [HttpGet]
        public JsonResult GetAreaPathChildren(string areapathText)
        {
            var message = string.Format("Data From Controller and parameter passed: {0}", areapathText);
            return new JsonResult(message);

        }
    }
}
