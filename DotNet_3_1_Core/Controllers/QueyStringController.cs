using Microsoft.AspNetCore.Mvc;

namespace DotNet_3_1_Core.Controllers
{
    public class QueyStringController : Controller
    {
        [Route("QueyString/VerifiedAll", Name="QueryStringValue")]
        public IActionResult VerifiedAll(string id)
        {
            var getQueryString = HttpContext.Request.QueryString.Value;
            return View();
        }
    }
}
