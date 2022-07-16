using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    //private readonly UserManager<ApplicationUser> userManager;
    //private readonly SignInManager<ApplicationUser> signInManager;
    public class LoginController : Controller
    {


        //[HttpGet("internal-signin")]
        //public ChallengeResult InternalSignIn(string returnUrl = "/")
        //{
        //    var redirectUrl = Url.Page("/Account/ExternalLogin", pageHandler: "Callback", values: new { returnUrl, area = "Identity" });
        //    var properties = _signInManager.ConfigureExternalAuthenticationProperties(AzureADDefaults.AuthenticationScheme, redirectUrl);
        //    return new ChallengeResult(AzureADDefaults.AuthenticationScheme, properties);
        //}
        [HttpGet]
        public IActionResult Login(string? returnurl)
        {
            ViewData["ReturnUrl"] = returnurl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string? returnurl)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: true);
                var result = true;

                if (result)
                {
                    return LocalRedirect(returnurl);
                }

                if (result)
                {
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(loginViewModel);
                }
            }

            return View(loginViewModel);
        }
    }
}
