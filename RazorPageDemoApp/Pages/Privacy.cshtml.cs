using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RazorPageDemoApp.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        [Required]
        [Range(5, 50, ErrorMessage = "Number is invalid")]
        public int TestNumber { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email address is invalid")]
        public string TestString { get; set; }

        public void OnGet()
        {
           
        }
    }
}