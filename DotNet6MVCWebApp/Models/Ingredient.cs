using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        [Required]
        public string IngredientName { get; set; }

        public int CookieId { get; set; }

    }
}
