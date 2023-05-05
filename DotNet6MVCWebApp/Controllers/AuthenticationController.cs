using DotNet6MVCWebApp.Interface;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationService;

        public AuthenticationController(IAuthenticationRepository authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel loginInfo)
        {
            IActionResult response = Unauthorized();

            var user = await _authenticationService.AuthenticateLogin(loginInfo);

            if (user.Token != null)
            {
                response = Ok(new ResponseViewModel { output = "success", msg = "Login Successfully", apiResponse = user });
            }

            return response;
        }


    }
}
