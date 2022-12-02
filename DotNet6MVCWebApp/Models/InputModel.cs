using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class InputModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Profile Picture")]
        public byte[] ProfilePicture  { get; set; }
    }
}
