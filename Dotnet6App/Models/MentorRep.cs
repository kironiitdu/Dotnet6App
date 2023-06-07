using System.ComponentModel.DataAnnotations;

namespace Dotnet6App.Models
{
    public class MentorRep
    {
        [Key]
        public int UserId { get; set; } 
        public int MenteeUserId { get; set; } 
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string? Code { get; set; } 
        public string? Status { get; set; } 

    }
}
