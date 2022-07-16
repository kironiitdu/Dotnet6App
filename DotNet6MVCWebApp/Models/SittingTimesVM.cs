using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class SittingTimesVM
    {
        public int SittingId { get; set; }
        public int SittingTypeId { get; set; }
        public DateTime Date { get; set; }
        public int RestaurantId { get; set; }
        public int NumberOfGuests { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm tt}")]
        public DateTime ChosenTime { get; set; }
        public DateTime SittingsStart { get; set; }
        public DateTime SittingsEnd { get; set; }
        public int CutOffTime { get; set; }
        public string Email { get; set; }
    }
}
