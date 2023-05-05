using System.ComponentModel.DataAnnotations;

namespace RazorPageDemoApp.Models
{
    public class ClientService
    {
        [Key]
        public int Id { get; set; }
        public string CliId { get; set; }
        public string ServId { get; set; }
        public bool Active { get; set; }
    }
}
