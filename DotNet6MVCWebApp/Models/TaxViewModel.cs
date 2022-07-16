namespace DotNet6MVCWebApp.Models
{
    public class TaxViewModel
    {
        public HeadingModel? Heading { get; set; }
        public TaxModel? Tax { get; set; }
        public List<TaxModel>? TaxList { get; set; }
    }
}
