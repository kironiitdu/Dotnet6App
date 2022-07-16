using DotNet6MVCWebApp.Models;
using DotNet6MVCWebApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class PostManController : Controller
    {
        private readonly IService _userManager;
        public PostManController(IService addservice)
        {
            _userManager = addservice;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<object> PostUser([FromBody] UserModel model)
        {

            var user = new UserModel()
            {
                FullName = model.FullName,

            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
