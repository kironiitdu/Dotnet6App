using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public int StateId { get; set; }
    }
}
