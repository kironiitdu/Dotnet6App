using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace DotNet6MVCWebApp.Controllers
{
    public class RogerBlinkinsController : Controller
    {
       
        public IActionResult Index()
        {
            var proPic = new List<ProfilePicture>()
            {
                new ProfilePicture(){ Picture = "Pic A",Id ="1"},
                new ProfilePicture(){ Picture = "Plan B",Id = "2"},
                new ProfilePicture(){ Picture = "Plan C",Id ="3"},

            };
            var appUser = new List<ApplicationUser>()
            {
                new ApplicationUser(){ FirstName = "First A",LastName ="Last Name - X",ProPicture ="P"},
                new ApplicationUser(){ FirstName = "First B",LastName = "Last Name - Y",ProPicture ="Q"},
                new ApplicationUser(){ FirstName = "First C",LastName ="Last Name - Z",ProPicture ="R"},

            };

            var ViewModel = new ProfilePictureViewModel();
            ViewModel.ProfilePictureVM = proPic;
            ViewModel.ApplicationUserVM = appUser;

            return View(ViewModel);
        }
    }
}
