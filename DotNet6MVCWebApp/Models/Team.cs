using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        public string? TeamName { get; set; }
        public string? Coach { get; set; }
        public int? NumberTeamMembers { get; set; }

        public virtual List<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
    }
}
