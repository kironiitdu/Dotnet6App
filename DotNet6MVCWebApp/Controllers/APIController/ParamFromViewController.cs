using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    public class ParamFromViewController : Controller
    {
        public IActionResult Index()
        {
            var response = new ResponseViewModel();
           
            return View(response);
        }
        [HttpPost]
        public IActionResult Edit(int editId)
        {
            TempData["Param"] = editId;
            return View();
        }
    }

    public class ResponseViewModel
    {
        public int Id { get; set; } = 101;
    }
}
