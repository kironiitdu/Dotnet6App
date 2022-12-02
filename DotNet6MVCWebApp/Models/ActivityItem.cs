using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Graph;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using DataType = System.ComponentModel.DataAnnotations.DataType;

namespace DotNet6MVCWebApp.Models
{
    public class ActivityItem
    {
        [Key]
        public int ActivityItemId { get; set; }

        [Required(ErrorMessage = "A valid Activity Name is required.")]
        [Display(Name = "Activity Name")]
        [StringLength(100)]
        public string ActivityName { get; set; }

        //[Required]
        //[Display(Name = "Activity Type")]
        //public int ActivityTypeId { get; set; }

        //[Required]
        //[Display(Name = "Date Activity Created")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Date Activity Modified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatetModified { get; set; }

        //[Required]
        //[Display(Name = "Created By (Employee ID)")]
        //[RegularExpression("^[1-9][0-9]{6}$", ErrorMessage = "A valid Employee ID is required!")]
        //public int? CreatedBy { get; set; }

        //[Display(Name = "Project Co-Ordinator (Employee ID)")]
        //[RegularExpression("^[1-9][0-9]{6}$", ErrorMessage = "A valid Employee ID is required!")]
        //public int? PC { get; set; }

        //[DefaultValue(true)]
        //public bool Live { get; set; }

        //public virtual ActivityType ActivityType { get; set; }

    }
}
