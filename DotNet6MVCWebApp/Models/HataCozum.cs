using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class HataCozum
    {
        [Key]
        public int ID { get; set; }
        public int HataID { get; set; }
        public string? CozulenHataAdi { get; set; }
        public string? CozumAciklama { get; set; }
        public double Seconds { get; set; }
    }
}
