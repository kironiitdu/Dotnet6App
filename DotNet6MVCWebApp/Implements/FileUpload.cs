using DotNet6MVCWebApp.Interface;
using DotNet6MVCWebApp.Models;
using static DotNet6MVCWebApp.Controllers.FilesController;

namespace DotNet6MVCWebApp.Implements
{

    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _environment;
       
        public FileUpload(IWebHostEnvironment enviornment)
        {
            _environment = enviornment;
           
        }

        //
        public void UploadFile(fileModel formFile)
        {

            if (!Directory.Exists(_environment.WebRootPath + "\\Uploads"))
            {
                Directory.CreateDirectory(_environment.WebRootPath + "\\Uploads");
            }

            using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Uploads" + formFile.files.FileName))
            {

                formFile.files.CopyTo(fileStream);
                fileStream.Flush();

            }
        }
    }

}
