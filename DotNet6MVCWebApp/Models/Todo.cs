using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class Todo
    {
        [Display(Name = "Item Id")]
        [Required]
        public int ItemId { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, MinimumLength = 10)]
        public string Description { get; set; }
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start date is required")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Text To Date Picker")]
      //  [DisplayFormat(DataFormatString = "{0:d/M/yyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> TestDate { get; set; }

        public class SortByStartDate : IComparer<Todo>
        {
            public int Compare(Todo x, Todo y)
            {
                return x.StartDate.CompareTo(y.StartDate);
            }
        }

        public class SortByEndDate : IComparer<Todo>
        {
            public int Compare(Todo x, Todo y)
            {
                return x.EndDate.CompareTo(y.EndDate);
            }
        }
    }
}
