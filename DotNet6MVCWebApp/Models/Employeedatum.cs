

using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Employeedatum
    {
       // [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
