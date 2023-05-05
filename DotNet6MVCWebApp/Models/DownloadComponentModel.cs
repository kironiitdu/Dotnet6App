namespace DotNet6MVCWebApp.Models
{
    public class DownloadComponentModel
    {
        public IFormFile? FileUpload { get; set; } = null;
        public string? FileUploadFileFormats { get; set; } = "application/pdf";
        public string? FileExtentionMessage { get; set; } = string.Empty;
        public string? DownloadLink { get; set; } = string.Empty;
    }
}
