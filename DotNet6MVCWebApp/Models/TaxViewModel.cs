namespace DotNet6MVCWebApp.Models
{
    public class TaxViewModel
    {
        public HeadingModel? Heading { get; set; }
        public TaxModel? Tax { get; set; }
        public List<TaxModel>? TaxList { get; set; }
        public bool? Level1a { get; set; } = false;
        public bool? Level1b { get; set; } = false;
        public bool? Level1c { get; set; } = false;
        public bool? Level2a { get; set; } = false;
        public bool? Level2b { get; set; } = false;
        public bool? Level3b { get; set; } = false;
        public bool? Level3a { get; set; } = false;
        public bool? Level3c { get; set; } = false;
        
    }
}
