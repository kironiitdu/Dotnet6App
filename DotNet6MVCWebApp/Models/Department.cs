using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Department Name")]
        public string Name { get; set; }

        public ICollection<Equipment> Equipments { get; set; }
    }
}
