using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class ExceptionController : Controller
    {
        public IActionResult Index() =>
        Content($"- {nameof(ExceptionController)}.{nameof(Index)}");
    }
}
