using System.ComponentModel.DataAnnotations;

namespace RazorPageDemoApp.Enum
{
    public enum Gender
    {
        [Display(Name = "Please Select")] Select = 0,
        [Display(Name = "Male")] Male = 1,
        [Display(Name = "Female")] Female = 2,

    }
}
