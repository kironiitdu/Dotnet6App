using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.Serialization;

namespace DotNet6MVCWebApp.Controllers
{
    public class TestController : CustomController
    {
        public const string TitleConst = "Tutorial Const";
        public static string TitleStatic = "Tutorial Static";
        public sealed override string Title { get; set; }
        public sealed override string TitleDescription { get; set; }
        public TestController()
        {
            Title = "Tutorial";
        }

        [HttpGet]
        public IActionResult IndicatorController()
        {

            Title = "Tutorial";

            var descriptor = ControllerContext.ActionDescriptor;

            // var declaredFields = descriptor.ControllerTypeInfo.DeclaredFields;
            var declaredFields = descriptor.ControllerTypeInfo.DeclaredProperties;

            List<string> propertyList = new List<string>();

            foreach (var field in declaredFields)
            {

                propertyList.Add(field.Name);
            }

            return Ok(propertyList);
        }


        public IActionResult AnotherFeildMandatory()
        {
            return View();
        }

    }
}
