using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
    }
}
