using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class IdentityModel
    {
       [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
       
        public string Username { get; set; }
       
        public string PhoneNumber { get; set; }
       
        public string ImageName { get; set; }
        public string ProfilePictureLocation { get; set; }
    }
}
