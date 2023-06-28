using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNet6MVCWebApp.Controllers
{
    public class SelectListSearchController : Controller
    {
        public IActionResult Index()
        {
            List<SelectListItem> entityTypeList = new List<SelectListItem>();
            entityTypeList.Add(new SelectListItem { Text = "Client-A", Value = "Client-A" });
            entityTypeList.Add(new SelectListItem { Text = "Client-B", Value = "Client-B" });
            entityTypeList.Add(new SelectListItem { Text = "Client-C", Value = "Client-C" });
            entityTypeList.Add(new SelectListItem { Text = "Client-D", Value = "Client-D" });
            entityTypeList.Add(new SelectListItem { Text = "Client-E", Value = "Client-E" });
            entityTypeList.Add(new SelectListItem { Text = "Client-F", Value = "Client-F" });
            entityTypeList.Add(new SelectListItem { Text = "Client-G", Value = "Client-G" });


            ViewBag.ListCategories = entityTypeList;
            return View();
        }
    }
}
