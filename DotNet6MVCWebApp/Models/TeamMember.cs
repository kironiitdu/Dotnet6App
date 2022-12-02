using Microsoft.Graph;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet6MVCWebApp.Models
{
    public class TeamMember
    {
        [Key]
        public int TeamMemberId { get; set; }

        [Required]
        public string? MemberName { get; set; }
        public string? Phone { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        [ForeignKey("TeamId")]
        public int TeamId { get; set; }

        public virtual Team? Team { get; set; }
    }
}
