using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace DotNet6MVCWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        string imageBase64 = "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";
      
        public async Task<JsonResult> MainCategories() 
        { 
            var categoryList = new List<CategoryTest>()
            {
                new CategoryTest(){ Id = 1, Name = "Microsoft",ShowMenu = true, Image =imageBase64},
                new CategoryTest(){ Id = 2, Name = "Apple",ShowMenu = false, Image =imageBase64},
                new CategoryTest(){ Id = 3, Name = "Google",ShowMenu = true, Image =imageBase64},
                new CategoryTest(){ Id = 4, Name = "IBM",ShowMenu = false, Image =imageBase64},


            };
            return Json(categoryList);
        }


        [HttpPost]
        public async Task<ActionResult> GameBoard(string id, string mrow, string mcol)
        {
            try
            {

                return Ok(string.Format("Id:{0}, mrow:{1}, mcol:{2}", id, mrow, mcol));
            }
            catch (Exception)
            {
                throw;
            }
        }
   
        public ActionResult LoadCategories()
        {
            return View();
        }

        [NonAction]
        public ActionResult Index()
        {
            return View(new Calculator_Model());
        }
        public ActionResult CalculateAjaxView()
        {
            return View();
        }

       // [HttpPost]
        public ActionResult Index(Calculator_Model cal, string calculate)
        {
            if (calculate == "add")
            {
                cal.Total = cal.Number1 + cal.Number2;
            }
            else if (calculate == "sub")
            {
                cal.Total = cal.Number1 - cal.Number2;
            }
            else if (calculate == "multi")
            {
                cal.Total = cal.Number1 * cal.Number2;
            }
            else if (calculate == "divis")
            {
                cal.Total = cal.Number1 / cal.Number2;
            }

            return View("Index",cal);

        }
        [HttpPost]
        public ActionResult Post(Calculator_Model cal, string calculate)
        {
            if (calculate == "add")
            {
                cal.Total = cal.Number1 + cal.Number2;
            }
            else if (calculate == "sub")
            {
                cal.Total = cal.Number1 - cal.Number2;
            }
            else if (calculate == "multi")
            {
                cal.Total = cal.Number1 * cal.Number2;
            }
            else if (calculate == "divis")
            {
                cal.Total = cal.Number1 / cal.Number2;
            }

            return Json(cal);

        }


    }
    public class CategoryTest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ShowMenu { get; set; }
        public string Image { get; set; }
    }
    public class Calculator_Model
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Total { get; set; }

    }
}
