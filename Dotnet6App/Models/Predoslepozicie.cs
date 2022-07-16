using System.ComponentModel.DataAnnotations;

namespace Dotnet6App.Models
{
    public class Predoslepozicie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int idZamestnanca { get; set; }
        [Required]
        public string Pozicia { get; set; }
        [Required]
        public DateTime DatumUkoncenia { get; set; }
        [Required]
        public DateTime DatumNastupu { get; set; }
    }
}
