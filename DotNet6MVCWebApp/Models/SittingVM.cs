using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class SittingVM
    {
        [Required(ErrorMessage = "Please enter a date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public int NumberOfGuests { get; set; }
        public int? SittingTypeId { get; set; }
       // public SelectList SittingType { get; set; }
        public List<SittingTimesVM>? SittingTimes { get; set; }
        public int ErrorNumber { get; set; }
    }
}
