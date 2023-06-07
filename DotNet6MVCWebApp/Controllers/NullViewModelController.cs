using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Controllers
{
    public class NullViewModelController : Controller
    {
        public IActionResult Index()
        {
            Stage_Media stage_Media = new Stage_Media();
            stage_Media.Branch_id = 101;    
            stage_Media.stage_id = 404;
            ViewBag.Stage_Media = stage_Media;
            return View();
        }

        [HttpPost]
        public string SaveStage(SaveStage_ViewModel model)
        {
            return $"Stage Id:{model.stage_id} and branch Id : {model.Id} has been Saved Successfully";
        }
    }


    public class SaveStage_ViewModel
    {
        public int stage_id { get; set; }
        public int Id { get; set; }

    }

    public class Stage_Media
    {
        public int Branch_id { get; set; }
        public int stage_id { get; set; }

    }
}
