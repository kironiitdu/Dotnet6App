using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RazorPageDemoApp.Pages
{
    public class IngredientsModel : PageModel
    {

        public List<Cookie> Cookie { get; set; }
        public void OnGet()
        {
            var ingredientList = new List<Ingredient>()
            {
                new Ingredient(){ IngredientId = 401,IngredientName  ="Ingredient-A"},
                new Ingredient(){ IngredientId = 401,IngredientName  ="Ingredient-B"},


            };
            var ingredientList2 = new List<Ingredient>()
            {
                new Ingredient(){ IngredientId = 403,IngredientName  ="Ingredient-C"},
                new Ingredient(){ IngredientId = 404,IngredientName  ="Ingredient-D"},


            };
            var cookiesList = new List<Cookie>()
            {
                new Cookie(){ Id =301,Name = "PineApple-Yellow", Ingridients =ingredientList},
                new Cookie(){ Id =302,Name = "Apple-While", Ingridients =ingredientList2},
                new Cookie(){ Id =303,Name = "Orange-Yellow", Ingridients =ingredientList},

            };
            Cookie = cookiesList;


        }
    }

    public class Cookie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Ingredient> Ingridients { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }

    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        [Required]
        public string IngredientName { get; set; }
    }
}
