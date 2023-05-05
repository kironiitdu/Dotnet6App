using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet6MVCWebApp.Models
{
    [Table("Production.Product")]
    public class Product
    {
        
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
    }
}
