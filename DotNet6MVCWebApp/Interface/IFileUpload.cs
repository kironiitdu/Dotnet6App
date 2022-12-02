using DotNet6MVCWebApp.Models;
using static DotNet6MVCWebApp.Controllers.FilesController;

namespace DotNet6MVCWebApp.Interface
{
    public interface IFileUpload
    {
        public void UploadFile(fileModel formFile);
    }
}
