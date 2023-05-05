using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Ocelot.Infrastructure.Extensions;
using System.Collections.Specialized;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;

namespace DotNet6MVCWebApp.Controllers
{
    public class DynamicFromSubmitController : Controller
    {
        public IActionResult FormOne()
        {
            return View();
        }
        public IActionResult FormTwo()
        {
            return View();
        }
        public IActionResult DynamicButton()
        {
            return View();
        }
        public IActionResult DynamicFormInsideDiv()
        {
            return View();
        }

        //public IActionResult DynamicOutput(string inputForm)
        //{

        //    ViewBag.dynamicOutputSubmitForm = inputForm;

        //    return View();
        //}
        public IActionResult DynamicOutput()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IFormCollection formData)
        {


            HttpRequest request = HttpContext.Request;

            

            //NameValueCollection form = (NameValueCollection)request.GetType().InvokeMember("_form",
            //    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField,
            //    null, request, null);
            var dynamicFormDataDictionary = new Dictionary<string, object>();

            foreach (var item in formData)
            {

                dynamicFormDataDictionary.Add(item.Key, item.Value);
                dynamicFormDataDictionary.Remove("__RequestVerificationToken");
            }


            return View("DynamicOutput", dynamicFormDataDictionary);
        }
    }
}
