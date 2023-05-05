using System.ComponentModel.DataAnnotations;

namespace SwaggerWebAPIApp.Models
{
    public class Suppliers
    {
        [Key]
        public int SupplierID { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }
    }
}
