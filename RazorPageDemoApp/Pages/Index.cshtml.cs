using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorPageDemoApp.Enum;


namespace RazorPageDemoApp.Pages
{

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        private readonly IHttpContextAccessor _contextAccessor;
        public IndexModel(ILogger<IndexModel> logger, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

     
        public void OnGet()
        {
            var count = HttpContext.Request.Cookies["_count"];

           
            if (count == null)
            {
                var setCookie = 20;
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddHours(1);
                _contextAccessor.HttpContext?.Response.Cookies.Append("_count", setCookie.ToString(), options);
            }
            else
            {
                int getOlderValue = Convert.ToInt32( HttpContext.Request.Cookies["_count"]);
                var updateCookie = getOlderValue + 10;
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddSeconds(5);
                _contextAccessor.HttpContext?.Response.Cookies.Append("_count", updateCookie.ToString(), options);
            }


        }

        public void OnPost(RequestModel requestModel)
        {
            var getEnumValue = requestModel.Animal;
            var getEnumIndex = (int)requestModel.Animal;
        }



    }
    

    public class RequestModel
    {

        public Animal Animal { get; set; }
    }
}