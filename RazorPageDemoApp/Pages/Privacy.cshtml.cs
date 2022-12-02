using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageDemoApp.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }
        public string Name { get; set; }

        public void OnGet()
        {
            var host = HttpContext.Request.Host;
            var path = HttpContext.Request.Path;
            var absolutepath = host + path;
            TempData["Url"] = absolutepath;
        }
    }
}