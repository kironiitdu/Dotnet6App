using System.ComponentModel.DataAnnotations;

namespace RegistrationServerApp.Models
{
    public class User
    {
        [Key]
        public long UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? LoginId { get; set; }
        public string? Password { get; set; }
    }
}
