using DotNet6MVCWebApp.Interface;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationService;

        public AuthenticateController(IAuthenticationRepository authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel loginInfo)
        {
            IActionResult response = Unauthorized();

            var user = await _authenticationService.AuthenticateLogin(loginInfo);

            if (user.Token != null)
            {
                response = Ok(user.Token);
            }
           
            return response;
        }

    }
}
