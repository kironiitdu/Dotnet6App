using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageDemoApp.Pages
{
    public class UploadPageHandlerModel : PageModel
    {


        public IFormFile? uploadedFile { get; set; }
        public async Task<IActionResult> OnPostUpload(IFormFile uploadedFile)
        {
            IFormFile? uploadedFormFile = uploadedFile;

            if (uploadedFormFile.Length > 0)
            {
                
            }
            return new EmptyResult();
        }
    }

}
