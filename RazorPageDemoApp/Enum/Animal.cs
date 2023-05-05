using System.ComponentModel.DataAnnotations;

namespace RazorPageDemoApp.Enum
{
    public enum Animal
    {
        [Display(Name = "None")] None = 3,
        [Display(Name = "Dog")] Dog = 1,
        [Display(Name = "Cat")] Cat = 2,
        [Display(Name = "Rat")] Rat = 0,
    }
}
