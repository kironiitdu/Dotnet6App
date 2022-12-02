using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class FinalProduct
    {
        [Display(Name = "Title")]
        public int ProductTitleId { get; set; }

        [Display(Name = "Type")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Size")]
        public int SizeId { get; set; }
        public int FinalProductId { get; set; }

        
    }
}
