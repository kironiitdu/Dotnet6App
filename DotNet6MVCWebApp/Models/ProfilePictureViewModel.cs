namespace DotNet6MVCWebApp.Models
{
    public class ProfilePictureViewModel
    {
        public IEnumerable<ProfilePicture> ProfilePictureVM { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUserVM { get; set; }
    }
}
