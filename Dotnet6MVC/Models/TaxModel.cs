using System.ComponentModel.DataAnnotations;

namespace Dotnet6MVC.Models
{
    public class TaxModel
    {
        public int TaxId { get; set; }
        [Required(ErrorMessage ="Tax Name Is Required")]
        public string TaxName { get; set; }
    }
}
