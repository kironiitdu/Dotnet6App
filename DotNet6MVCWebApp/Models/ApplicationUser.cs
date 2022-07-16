using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet6MVCWebApp.Models
{
    public class ApplicationUser
    {
        //[PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        //[PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

       // [PersonalData]
        [Column(TypeName = "nvarchar(1000)")]
        public string ProPicture { get; set; }
       
    }
}
