using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace DotNet6MVCWebApp.Models
{
    public class Prog
    {
        [Key]
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Module { get; set; }
        public string Status { get; set; }
    }
}
