

using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class CompanyModel
    {
        [Key]
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }
        public string Website { get; set; }
       
    }
}
