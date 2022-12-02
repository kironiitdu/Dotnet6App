using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Graph;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web;

namespace DotNet6MVCWebApp.Controllers
{
    public class ActionHelperController : Controller
    {
        private readonly LinkGenerator _linkGenerator;

        public ActionHelperController(LinkGenerator linkGenerator)
        {

            _linkGenerator = linkGenerator;
        }


        public IActionResult Index()
        {




            UrlActionContext urlActionContext = new UrlActionContext();
            urlActionContext.Controller = "Animal";
            urlActionContext.Action = "MemberList";
            var redirectUrl = _linkGenerator.GetUriByAction(HttpContext, action: urlActionContext.Action, controller: urlActionContext.Controller, null, HttpContext.Request.Scheme);


            return Redirect(redirectUrl);
        }


        public IActionResult CascadingDropdownProduct()
        {
            return View();
        }

        public IActionResult ListAllControllerAction()
        {

            Assembly asm = Assembly.GetAssembly(typeof(ActionHelperController));

            var controlleractionlist = asm.GetTypes()
                    .Where(type => typeof(Microsoft.AspNetCore.Mvc.Controller).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
                    .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();
            return Ok(controlleractionlist);
        }

    }
    public class FinalProductViewModel
    {
        [Display(Name = "Title")]
        public int ProductTitleId { get; set; }

        [Display(Name = "Type")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Size")]
        public int SizeId { get; set; }
    }
}
