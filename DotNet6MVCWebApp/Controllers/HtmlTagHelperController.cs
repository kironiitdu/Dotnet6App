using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class HtmlTagHelperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult DoubleParamter(string? category, string? topic)
        {
            var response = string.Format("You have sent: Category:{0}, Topic:{1}", category, topic);
            return Ok(response);
        }
        public ActionResult TripleParamter(string? category, string? topic, int? page)
        {
            var response = string.Format("You have sent: Category:{0}, Topic:{1}, Page: {2}", category, topic, page);
            return Ok(response);
        }

    }
}
