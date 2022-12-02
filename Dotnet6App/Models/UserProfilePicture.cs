using System.ComponentModel.DataAnnotations;

namespace Dotnet6App.Models
{
    public class UserProfilePicture
    {
        [Key]
        public int UserProfilePictureId { get; set; }
        public string UserId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    }
}
