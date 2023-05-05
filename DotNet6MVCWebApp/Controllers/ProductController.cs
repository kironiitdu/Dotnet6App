using DotNet6MVCWebApp.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace DotNet6MVCWebApp.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Get(FromRouteAttribute Url)
        {
            return Ok(Url);

        }
    }

 
    
}
