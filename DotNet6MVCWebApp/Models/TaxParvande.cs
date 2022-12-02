namespace DotNet6MVCWebApp.Models
{
    public class TaxParvande
    {
        public IFormFile? prosessMastand { get; set; }
        public int prosessId { get; set; }   
        public bool state { get; set; }   
        public string? prosessName { get; set; }
    }
}
