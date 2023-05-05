using Dotnet6MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet6MVC.Controllers
{
    public class UserProfilesController : Controller
    {
        private readonly HoshmandDBContext _context;
        private readonly IWebHostEnvironment _environment;


        public UserProfilesController(IWebHostEnvironment environment, HoshmandDBContext context)
        {
            _environment = environment;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.Where(u=>u.UserId==10).ToListAsync());
        }
    }
}
