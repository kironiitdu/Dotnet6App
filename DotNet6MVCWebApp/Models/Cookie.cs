using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Cookie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Ingredient>? Ingridients { get; set; }
       // public DateTime? CreatedDateTime { get; set; } = DateTime.Now;
    }
}
