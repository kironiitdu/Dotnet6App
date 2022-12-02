using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }
        public string? DeveloperName { get; set; }
        public int ProductCategorieId { get; set; }
        public int ProductSubCategorieId { get; set; }
        public string? Skills { get; set; }
    }
}
