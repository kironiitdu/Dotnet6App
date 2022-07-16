namespace DotNet6MVCWebApp.Models
{
    public class Book
    {

        public int Id { get; set; }
        public int MininumAge { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public ICollection<Genre>? Genres { get; set; }
    }
}
