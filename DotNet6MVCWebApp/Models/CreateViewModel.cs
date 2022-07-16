namespace DotNet6MVCWebApp.Models
{
    public class CreateViewModel
    {
        public Book Book { get; set; }
        public List<Genre>? Genres { get; set; }
        public List<string> GenresList { get; set; }
    }
}
