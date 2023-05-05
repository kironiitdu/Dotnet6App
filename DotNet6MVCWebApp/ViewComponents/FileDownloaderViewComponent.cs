using DocumentFormat.OpenXml.Wordprocessing;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.ViewComponents
{
   
    [ViewComponent(Name = "FileDownloader")]
    public class FileDownloaderViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(DownloadComponentModel fileDownloadViewModel)
        {

            return View("FileDownloader", fileDownloadViewModel);
        }
    }
}
