using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Fname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
       
        
    }
}
