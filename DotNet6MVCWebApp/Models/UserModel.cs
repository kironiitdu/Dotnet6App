using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class UserModel
    {
        [Required]
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNum { get; set; }
        public DateTime ExpDate { get; set; }
        public string CVV { get; set; }
        public bool isApproved { get; set; }

        public UserPurchaseinfo UserPurchaseinfo { get; set; }
    }
}
