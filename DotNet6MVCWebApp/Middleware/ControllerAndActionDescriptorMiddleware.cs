using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace DotNet6MVCWebApp.Middleware
{
    public class ControllerAndActionDescriptorMiddleware : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            string controllerName = context.RouteData.Values["controller"].ToString();
            string actionName = context.RouteData.Values["action"].ToString();

            if (descriptor != null)
            {
                var parameters = descriptor.MethodInfo.GetParameters();

                foreach (var parameter in parameters)
                {
                    Console.WriteLine($"ControllerName: {controllerName}, ActionName: {actionName}, ParameterName: {parameter.ToString()}");

                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            string? controllerName = descriptor?.ControllerName;
            string? actionName = descriptor?.ActionName;

            if(controllerName == "Calculator" && actionName == "Index")
            {
                //set action parameter 
                var ca = descriptor.MethodInfo.CustomAttributes;
            }
            if (descriptor != null)
            {
                var ddd = descriptor.ActionConstraints;
                var xxx= descriptor.BoundProperties;
                var parameters = descriptor.MethodInfo.GetParameters();

                foreach (var parameter in parameters)
                {
                    Console.WriteLine($"ControllerName: {controllerName}, ActionName: {actionName}, ParameterName: {parameter.ToString()}");
                }
            }

        }
    }
}
