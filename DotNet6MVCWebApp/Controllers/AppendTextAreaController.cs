using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.Runtime.Serialization;

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

        [HttpPost]
        public JsonResult BulkPost([FromBody] List<Categoria> categorias)
        {
            return new JsonResult(categorias);
        }

        public IActionResult IndexBulkPost()
        {
            return View();
        }
    }

    public class Categoria
    {
        public int IdClas { get; set; }
       
        [DataMember(Name = "Name")]
        [DisplayName("Nombre de la categoría")]
        public string Name { get; set; }
    }
}
