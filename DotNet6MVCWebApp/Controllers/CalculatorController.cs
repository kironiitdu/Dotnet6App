using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public ActionResult Index()
        {
            return View(new Calculator_Model());
        }
        public ActionResult CalculateAjaxView()
        {
            return View();
        }

        [HttpPost]
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
    public class Calculator_Model
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Total { get; set; }

    }
}
