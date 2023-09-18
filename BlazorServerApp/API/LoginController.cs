using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BlazorServerApp.API
{
    [ApiController]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {

            var options = new CookieOptions
            {
                Secure = true,
                IsEssential = true,
                HttpOnly = false,
                Expires = DateTime.Now.AddMinutes(3)
            };

            Response.Cookies.Append("KironKey", "MyCookieValue", options);
            return Ok();
        }
    }
}
