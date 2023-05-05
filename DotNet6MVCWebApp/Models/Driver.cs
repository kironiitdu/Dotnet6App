using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet6MVCWebApp.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        public int? scooberId { get; set; }
        public string? driverName { get; set; }
        public string? driverScore { get; set; }
        //[Range(0, 999.99)]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("Employed Salary")]
        public double? employedTime { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Premium Cover")]
        public decimal Premium { get; set; }= new decimal(10.25);
        public decimal? GrossWeight { get; set; }
        public string? amtApproaches { get; set; }
        //public virtual ICollection<Approach> Approaches { get; set; }
        //public int amtEvaluated { get; set; }
        //public float lastEvaluated { get; set; }
        //public virtual ICollection<Evaluation> Evaluations { get; set; }
        //public Driver()
        //{

        //}
    }
}
