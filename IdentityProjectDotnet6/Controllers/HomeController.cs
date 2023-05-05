using IdentityProjectDotnet6.Areas.Identity.Data;
using IdentityProjectDotnet6.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IdentityProjectDotnet6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IUserma<HomeController> _userManager;
        private readonly UserManager<AppUser> _userManager;
       

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoleClaims(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var roleclaim = await _userManager.GetClaimsAsync(user);

            return Ok(roleclaim);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}