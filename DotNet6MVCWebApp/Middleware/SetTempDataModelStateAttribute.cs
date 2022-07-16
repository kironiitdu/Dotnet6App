using DotNet6MVCWebApp.Controllers;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web;

namespace DotNet6MVCWebApp.Middleware
{

    public class SetTempDataModelStateAttribute : ActionFilterAttribute
    {

        public void Apply(ApplicationModel application)
        {
            var controllers = application.Controllers.ToList();
            foreach (var controller in controllers)
            {
                var actions = controller.Actions.ToList();
                foreach (var action in actions)
                {
                    if (action.ActionMethod.GetCustomAttributes(true).Any(p => p.GetType() == typeof(HttpGetAttribute)))
                    {
                        var actionParams = action.ActionMethod.GetParameters().Where(p => p.GetType() != typeof(CancellationToken));
                        foreach (var param in actionParams)
                        {
                            //add [FromQuery] attribute to param
                            //var x = param.GetCustomAttributes(true);
                        }
                    }
                }
            }
        }
        private void EvaluateValidationAttributes(ParameterInfo parameter, object argument, ModelStateDictionary modelState)
        {
            var validationAttributes = parameter.CustomAttributes;

            foreach (var attributeData in validationAttributes)
            {
                var attributeInstance = CustomAttributeExtensions.GetCustomAttribute(parameter, attributeData.AttributeType);

                var validationAttribute = attributeInstance as ValidationAttribute;

                if (validationAttribute != null)
                {
                    var isValid = validationAttribute.IsValid(argument);
                    if (!isValid)
                    {
                        modelState.AddModelError(parameter.Name, validationAttribute.FormatErrorMessage(parameter.Name));
                    }
                }
            }
        }
        //private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        //{
        //    context.Response.ContentType = "application/json";
        //    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //    await context.Response.WriteAsync(new ErrorDetails()
        //    {
        //        StatusCode = context.Response.StatusCode,
        //        Message = "Internal Server Error from the custom middleware."
        //    }.ToString());
        //}
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var descriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;

            var declaredFields = descriptor.ControllerTypeInfo.DeclaredFields;

            List<string> propertyList = new List<string>();

            foreach (var field in declaredFields)
            {
                Console.WriteLine(field.Name);
                propertyList.Add(field.Name);
            }

           

            if (descriptor != null)
            {
                var parameters = descriptor.MethodInfo.GetParameters();
                foreach (var parameter in parameters)
                {
                    var argument = filterContext.ActionArguments[parameter.Name];

                    EvaluateValidationAttributes(parameter, argument, filterContext.ModelState);
                }
            }

            var valueAsString = filterContext.HttpContext.Request.QueryString;
            var nvc = HttpUtility.ParseQueryString(valueAsString.ToString());
            
           

        }
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    base.OnActionExecuting(filterContext);
        //    if (filterContext.Controller.TempData.ContainsKey("ModelState"))
        //    {
        //        filterContext.Controller.ViewData.ModelState.Merge(
        //            (ModelStateDictionary)filterContext.Controller.TempData["ModelState"]);
        //    }
        //}
        //public class RestoreModelStateFromTempDataAttribute : ActionFilterAttribute
        //{
        //    public override void OnActionExecuting(ActionExecutingContext filterContext)
        //    {
        //        base.OnActionExecuting(filterContext);
        //        if (filterContext.Controller.TempData.ContainsKey("ModelState"))
        //        {
        //            filterContext.Controller.ViewData.ModelState.Merge(
        //                (ModelStateDictionary)filterContext.Controller.TempData["ModelState"]);
        //        }
        //    }
        //}
    }
}
