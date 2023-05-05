using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet6MVCWebApp.Models
{
    public class Equipment
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Equipment Name")]
        public string Name { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public string Status { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        [Required]
        public string InternalConsigned { get; set; }
        public string entityType { get; set; }

        public DateTime EOLDate { get; set; }
        //    [Key]
        //    public int Id { get; set; }

        //    [Required]
        //    [DisplayName("Equipment Name")]
        //    public string Name { get; set; }

        //    [Required]
        //    public int Amount { get; set; }

        //    [Required]
        //    public string Status { get; set; }
        //    //[ForeignKey("Department")]
        //    //public int? DepartmentId { get; set; }
        //    //public virtual Department Department { get; set; }

        //    public int DepartmentId { get; set; }
        //    public Department Department { get; set; }



    }
}
