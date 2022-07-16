using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Enums
{
    public enum Gender
    {
        //[Description("Please Select")]
        //select = 1,
        //[Description("male")]
        //male = 2,
        //[Description("female")]
        //female = 3,
        [Display(Name = "Please Select")] Select = 0,
        [Display(Name = "Male")] Male = 1,
        [Display(Name = "Female")] Female = 2,
       
    }
}
