

using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Required Field..")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Required Field..")]
        [StringLength(50, MinimumLength =2, ErrorMessage = "Must be btween 3 to 50")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Required Field..")]
        public string Bio { get; set; }

        public List<Movie> Movies { get; set; }

    }
}
