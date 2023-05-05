using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.ViewComponents
{
    [ViewComponent(Name = "FileUploader")]
    public class FileUploaderViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(UploadComponentModel filUploadViewModel)
        {

            return View("FileUploader", filUploadViewModel);
        }
    }
}
