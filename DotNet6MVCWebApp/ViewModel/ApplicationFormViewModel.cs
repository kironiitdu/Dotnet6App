using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.ViewModel
{
    public class ApplicationFormViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        [StringLength(25)]
        [MaxLength(25)]
        public string AppFirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [StringLength(25)]
        [MaxLength(25)]
        public string AppLastName { get; set; }

        [Required(ErrorMessage = "Please make a selection")]
        [Display(Name = "State")]
        public int StateId { get; set; }
        //public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime AppDateOfBirth { get; set; }

        [Required(ErrorMessage = "Total number of persons to occupy apartment is required")]
        [Display(Name = "Total number of persons to occupy apartment")]
        [Range(1, 10, ErrorMessage = "Must be between 1 to 10")]
        public int AppTotalPersonsOccupy { get; set; }

        ////[Required(ErrorMessage = "You must exept terms to continue")]
        //[Display(Name = "I agree to the pre rental application terms & conditions")]
        ////[Range(typeof(bool), "false", "false", ErrorMessage = "You must accept the Terms")]
        //[Controllers.ApplicationController.CheckBoxRequired(ErrorMessage = "You must agree to the terms and condtions!")]
        //public bool AppAgreeToTerms { get; set; }

        [Display(Name = "I agree to the pre rental application terms & conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the terms and condtions!")]
        public bool AppAgreeToTerms { get; set; }
    }
}
