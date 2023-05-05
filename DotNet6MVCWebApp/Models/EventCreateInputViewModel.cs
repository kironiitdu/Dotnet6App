namespace DotNet6MVCWebApp.Models
{
    public class EventCreateInputViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string TicketSelection { get; set; }
        public string Description { get; set; }
    }
}
