using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Web;

namespace DotNet6MVCWebApp.Controllers
{
    public class AuthTokenController : Controller
    {
        public IActionResult Index()
        {
            var data = HttpUtility.HtmlEncode("");

            var encodedASCII = Encoding.ASCII.GetBytes("");

            var host = "http://localhost:60695";
            var path = "/ShowProduct/2/شال-آبی";
            path = String.Join(
                "/",
                path.Split("/").Select(s => System.Net.WebUtility.UrlEncode(s))
            );
            return View();
        }
    }
}
