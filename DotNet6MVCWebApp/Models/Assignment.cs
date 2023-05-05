using DotNet6MVCWebApp.Controllers;
using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Assignment
    {
        [Key]
        public Guid taskID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int EmployeeId{ get; set; }
        public DateTime dueDate { get; set; }
    }
}
