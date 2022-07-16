using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        //[Required(ErrorMessage = "CategoryName is required")]
        //[StringLength(100, MinimumLength = 10)]
        public string CategoryName { get; set; }
        public int DisplayOrder { get; set; }
        
       // [Required(ErrorMessage = "End date is required")]
        public DateTime DateCreated { get; set; }

    }
}
