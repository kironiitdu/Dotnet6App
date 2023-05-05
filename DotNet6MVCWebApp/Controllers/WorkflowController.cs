using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class WorkflowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AnotherIndex(string message)
        {
            ViewBag.message = message;
            return View();
        }

        public IActionResult List(string? Id)
        {
            ViewBag.Value = Id;
            return View();
        }
        [HttpPost]
        public ActionResult UpdateStatus(string ID)
        {
            try
            {
               
                return RedirectToAction("List", "Workflow", new { Id = "U" + ID });

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message,
                });
            }
        }
        [HttpDelete]
        public JsonResult OnPostDelete(int id)
        {
           // _ItemApplication.Delete(id);
            return new JsonResult(new { status = true, message = "Done!" });

        }
        [HttpPost]
        public async Task<bool> ShippingFinishDeleteItem(String body)
        {

            return true;
        }
      
        public IActionResult PostJsonString()
        {
            return View();
        }

    }
}
