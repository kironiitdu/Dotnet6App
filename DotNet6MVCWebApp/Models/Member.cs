using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [StringLength(60, MinimumLength = 3)]

        public string? Name { get; set; }

        public string? Gender { get; set; }
        public DateTime DOB { get; set; }

        public string? ImageName { get; set; }
        public string? ImageLocation { get; set; }
       
    }
}
