using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DotNet6MVCWebApp.Middleware
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {

                var probURL = "https://localhost:7018/shop/Category/4/Women%2FShoes";

                var newUrl = probURL.Replace("%2F","/");

                context.HttpContext.Response.Redirect("ValidModelState/Index");
                context.Result = new BadRequestObjectResult(context.ModelState);
                context.ModelState.AddModelError("Name", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
        }
    }
}
