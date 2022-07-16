namespace DotNet6MVCWebApp.Models
{
    public class CreateAnimalViewModel
    {
        public Animal? Animal { get; set; }
        public string? DisplayPhoto { get; set; }
        public string? ImageURL { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
