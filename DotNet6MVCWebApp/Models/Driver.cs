using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        public int scooberId { get; set; }
        public string driverName { get; set; }
        public string driverScore { get; set; }
        public decimal employedTime { get; set; }
        public string amtApproaches { get; set; }
        //public virtual ICollection<Approach> Approaches { get; set; }
        //public int amtEvaluated { get; set; }
        //public float lastEvaluated { get; set; }
        //public virtual ICollection<Evaluation> Evaluations { get; set; }
        //public Driver()
        //{

        //}
    }
}
