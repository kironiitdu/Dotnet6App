using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CompanyId { get; set; }
    }
}
