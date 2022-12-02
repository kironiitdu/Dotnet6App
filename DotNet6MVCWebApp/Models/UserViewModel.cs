namespace DotNet6MVCWebApp.Models
{
    public class UserViewModel
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string MappedWsManager { get; set; }
        public string LoginId { get; set; }
        public Nullable<bool> UserType { get; set; }
    }
}
