using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    [Route("Document/HB89Letter")]
    public class HB89LetterController : Controller
    {

        [Route("")]
        [Route("Show")]
        public ActionResult Show(HB89LetterViewModel vm)
        {
           return View(vm);
        }
    }

    public class HB89LetterViewModel
    {
        public string Name { get; set; }
    }
}
