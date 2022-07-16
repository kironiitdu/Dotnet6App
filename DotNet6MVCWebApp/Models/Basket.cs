namespace DotNet6MVCWebApp.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public string Sharp { get; set; }
        public string Material { get; set; }
        public List<Fruit> Fruits { get; set; }
    }
}
