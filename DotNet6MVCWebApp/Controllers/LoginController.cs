using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    //private readonly UserManager<ApplicationUser> userManager;
    //private readonly SignInManager<ApplicationUser> signInManager;
    public class LoginController : Controller
    {
        public static HttpResponseMessage CallPage(HttpRequest request, string name, string args)
        {
            HttpClient client = new HttpClient();
            using var newRequest = new HttpRequestMessage(new HttpMethod(request.Method), args);
            using HttpResponseMessage response = client.SendAsync(newRequest).Result;

            return response;
        }


        [HttpGet]
        public IActionResult Login(string? returnurl)
        {
           // string url = HttpContext.Current.Request.Url.AbsoluteUri;
            var host = HttpContext.Request.Host;
            var path = HttpContext.Request.Path;
            var absolutepath = host + path;

            ViewData["ReturnUrl"] = returnurl;
            return View();
        }
        //public static HttpResponseMessage CallPage(HttpRequest request, string name, string args)
        //{
        //    HttpClient client = new HttpClient();
        //    using var newRequest = new HttpRequestMessage(new HttpMethod(request.Method), Routes[name] + args);
        //    using HttpResponseMessage response = client.SendAsync(newRequest).Result;
        //    return response;
        //}
        [HttpGet]
        public IActionResult Index()
        {
          
            return View();
        }

        public IActionResult LoginPage()
        {
            return View();
        }
        [AllowAnonymous]
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
