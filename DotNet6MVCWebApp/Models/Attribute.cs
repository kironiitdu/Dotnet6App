using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Attribute
    {
        public int Id { get; set; }
        [Required]
        public string AttributeName { get; set; }
        public string Description { get; set; }
        public bool UserCanChangeValue { get; set; }
        public ICollection<AttributeValue> Values { get; set; }
    }
}
