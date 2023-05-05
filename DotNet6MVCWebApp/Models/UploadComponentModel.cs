namespace DotNet6MVCWebApp.Models
{
    public class UploadComponentModel
    {
       public IFormFile? MyUploadedFile { get; set; } = null;
        public string? FileExtntionName { get; set; } = string.Empty;
        public string? UploadedFileName { get; set; } = string.Empty;
        public string? FileExtentionMessage { get; set; } = string.Empty;
        public string? DownloadLink { get; set; } = string.Empty;
    }
}
