using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Controllers
{
    public class ViewBagDropdownController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> ingredientList = new List<SelectListItem>();
            ingredientList.Add(new SelectListItem { Text = "Ingredient-A", Value = "Ingredient-A" });
            ingredientList.Add(new SelectListItem { Text = "Ingredient-B", Value = "Ingredient-B" });
            ingredientList.Add(new SelectListItem { Text = "Ingredient-C", Value = "Ingredient-C" });

            ViewBag.listIngredients = ingredientList;
            return View();
        }
    }

    
}
