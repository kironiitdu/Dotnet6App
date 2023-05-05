using Microsoft.AspNetCore.Mvc;

namespace SwaggerWebAPIApp.Controllers
{
    public class UnAuthorizedPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
