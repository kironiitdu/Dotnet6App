using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet6MVCWebApp.Models
{
    public class AttributeValue
    {
        public int Id { get; set; }     //add a primary key
        [ForeignKey("AssociatedAttribute")]
        public int AssociatedAttributeId { get; set; }
        public virtual Attribute AssociatedAttribute { get; set; }
        [Required]
        public string Value { get; set; }
        public bool PromptChange { get; set; }
        public bool ShowonInvoice { get; set; }
    }
}
