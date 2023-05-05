using System.ComponentModel.DataAnnotations;

namespace SwaggerWebAPIApp.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
       
    }
}
