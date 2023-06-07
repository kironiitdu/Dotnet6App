using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RazorPageDemoApp.Pages
{
    public class EmployeeModel : PageModel
    {
       public Employee? Employee { get; set; }
        public void OnGet()
        {
            Employee = new Employee();
            Employee.ID = 1;
            Employee.FirstName = "Test First Name";
            Employee.Email = "TestEmail@email.com";
            Employee.Mobile = "0123456789";
        }
        public void OnPost()
        {
            Employee = new Employee();
            Employee.ID = Convert.ToInt32(Request.Form["ID"].ToString());
            Employee.FirstName = Request.Form["FirstName"].ToString();
            Employee.Email = Request.Form["Email"].ToString();
            Employee.Mobile = Request.Form["Mobile"].ToString();
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Employee First Name")]
        [StringLength(60,MinimumLength =3)]
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        [Required]
        [Display(Name = "Validation Test")]
        [StringLength(60, MinimumLength = 3)]
        public string InputValidationTest { get; set; }
    }
}
