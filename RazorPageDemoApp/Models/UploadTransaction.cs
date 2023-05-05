namespace RazorPageDemoApp.Models
{
    public class UploadTransaction
    {
        public UploadTransaction()
        {
        }

        public string Date { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string TransId { get; set; }
    }
}
