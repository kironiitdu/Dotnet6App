using System.ComponentModel.DataAnnotations;

namespace SwaggerWebAPIApp.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
    }
}
