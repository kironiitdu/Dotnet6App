using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using System.ComponentModel;
using System.Linq;

namespace DotNet6MVCWebApp.Controllers
{
    public class FileUploadViewComponentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public FileUploadViewComponentController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public async Task<IActionResult> DownloadPdfFile(string fileName)
        {
          var ddd =   TempData["FileName"];
            var readFileFromThisPath = Path.GetFullPath("./wwwroot/ViewComponentUpload/" + fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(readFileFromThisPath);
            return File(fileBytes, "application/force-download", fileName);
           
        }
        public async Task<IActionResult> DownloadFile(string downloadlink)
        {
            var path = Path.GetFullPath("./wwwroot/ViewComponentUpload/" + downloadlink);
            MemoryStream memory = new MemoryStream();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "image/png", Path.GetFileName(path));
        }
        public async Task<IActionResult> Index(UploadComponentModel FileName)
        {

            var uploadedFileDetails = new UploadComponentModel();
            if (FileName.MyUploadedFile == null)
            {
                return View(uploadedFileDetails);
            }
            else
            {
                string checkFileExtension = System.IO.Path.GetExtension(FileName.MyUploadedFile.FileName);

                string[] expectedFile = { ".pdf", ".png", ".jpeg" };

                if (expectedFile.Contains(checkFileExtension))
                {
                    //Save file into directory
                    var path = Path.Combine(_environment.WebRootPath, "ViewComponentUpload", FileName.MyUploadedFile.FileName);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await FileName.MyUploadedFile.CopyToAsync(stream);
                        stream.Close();
                    }

                    uploadedFileDetails.FileExtentionMessage = "Right extension uploaded";
                    uploadedFileDetails.MyUploadedFile = FileName.MyUploadedFile;
                    uploadedFileDetails.FileExtntionName = checkFileExtension;
                    uploadedFileDetails.UploadedFileName = FileName.MyUploadedFile.FileName;
                    uploadedFileDetails.DownloadLink = FileName.MyUploadedFile.FileName;
                }
                else
                {
                    uploadedFileDetails.MyUploadedFile = FileName.MyUploadedFile;
                    uploadedFileDetails.FileExtntionName = checkFileExtension;
                    uploadedFileDetails.UploadedFileName = FileName.MyUploadedFile.FileName;
                    uploadedFileDetails.FileExtentionMessage = "Invalid file type";
                    uploadedFileDetails.DownloadLink = "Sorry no download link available!";
                }




                return View(uploadedFileDetails);
            }

        }

        public async Task<IActionResult> UploadDownload(DownloadComponentModel FileName)
        {
            var downloadableFileDetails = new DownloadComponentModel();
            if (FileName.FileUpload == null)
            {
                return View(downloadableFileDetails);
            }
            else
            {
                string checkFileExtension = System.IO.Path.GetExtension(FileName.FileUpload.FileName);

                string[] expectedFile = { ".pdf" };

                if (expectedFile.Contains(checkFileExtension))
                {
                    //Save file into directory
                    var path = Path.Combine(_environment.WebRootPath, "ViewComponentUpload", FileName.FileUpload.FileName);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await FileName.FileUpload.CopyToAsync(stream);
                        stream.Close();
                    }
                    TempData["FileName"] = "IIS.docx";
                    ViewBag.FileName = "IIS.docx";
                    //Covert your file from PDF to Word file and get the converted file name
                    //I am not writing convert login here just getting the file name of converted file 
                    downloadableFileDetails.FileExtentionMessage = checkFileExtension +" to docx";
                    downloadableFileDetails.DownloadLink = "IIS.docx";//Pass converted file name here.
                }
                else
                {

                    downloadableFileDetails.FileExtentionMessage = "Invalid file type";
                    downloadableFileDetails.DownloadLink = "Sorry no download link available!";
                }
            }
            
            return View(downloadableFileDetails);
        }
    }
}
