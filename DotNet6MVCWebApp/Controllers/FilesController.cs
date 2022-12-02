using DotNet6MVCWebApp.Implements;
using DotNet6MVCWebApp.Interface;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class FilesController : Controller
    {
        private readonly IFileUpload _fileUplaod;

        public FilesController(IFileUpload fileUplaod)
        {
            _fileUplaod = fileUplaod;
        }
        [HttpPost]
        public IActionResult UploadFile(fileModel objFile)
        {
            try
            {
                if (objFile.files.Length > 0)
                {
                    _fileUplaod.UploadFile(objFile);
                    return Ok("Upload" + objFile.files.FileName);
                }
                else
                {
                    return Ok("Failed");
                }
            }
            catch (System.Exception ex)
            {

                return Ok(ex.Message.ToString());
            }

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
