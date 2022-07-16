using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet6MVCWebApp.Models
{
    public class ProfilePicture
    {
        [ForeignKey("Id")]
        public string Id { get; set; }

        public string Picture { get; set; }
    }
}
