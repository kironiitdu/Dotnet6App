using DotNet6MVCWebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    //[ApiVersion("1.0")]
    //[Route("api/[controller]")]
    //[ApiController]
    public class ESmsDialoglkController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public ESmsDialoglkController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        //[AllowAnonymous]
        //[HttpPost("Login")]
       
        public async Task<IActionResult> Login(string userName, string password)
        {

            if (userName == null || password == null)
            {
                return BadRequest();
            }

            var getUserInfo = _context.Users.Where(uname => uname.UserEmail == userName);

            return Ok(getUserInfo);
        }
    }
}
