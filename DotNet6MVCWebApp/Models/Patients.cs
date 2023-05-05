using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Patients
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status {get; set; }
        public DateTime DateOfAdm { get; set; }
        public DateTime DateOfDis { get; set; }
    }
}
