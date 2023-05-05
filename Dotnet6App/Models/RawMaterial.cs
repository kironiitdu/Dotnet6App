using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dotnet6App.Models
{
    public class RawMaterial
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RawId { get; set; }
        [StringLength(50)]
        public string RawName { get; set; }
        public int RawNumber { get; set; }
    }
}
