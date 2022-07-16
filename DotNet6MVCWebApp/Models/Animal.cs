using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Portrait")]
        public string? PhotoUrl { get; set; }
        public string? LocalTime { get; set; }
        public string? UTCTime { get; set; }
        public string? AzureTime { get; set; }
    }
}
