using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Middleware
{
    public class ValidationExceptionHandlerFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                context.ExceptionHandled = true;
                ValidationException vEx = (ValidationException)context.Exception;
                ModelStateDictionary msd = new ModelStateDictionary();

                //foreach (var err in vEx.Errors)
                //{
                //    msd.AddModelError(err.PropertyName, err.ErrorMessage);
                //}

                //context.ModelState.Merge(msd);

                //context.Result = new RedirectToRouteResult(context.HttpContext.Request.Path);
            }

            base.OnException(context);
        }
    }
}
