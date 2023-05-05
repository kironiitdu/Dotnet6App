using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class SameNameController : Controller
    {
        public ActionResult SameNameAction(int? page, int? pageSize)
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
