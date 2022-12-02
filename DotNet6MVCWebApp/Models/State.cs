using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string? StateName { get; set; }
        public int CountryId { get; set; }
    }
}
