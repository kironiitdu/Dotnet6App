using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class TableDateGap
    {
        [Key]
        public int Id { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? TotalGap { get; set; }
        public bool IsGapAvailable { get; set; }
    }
}
