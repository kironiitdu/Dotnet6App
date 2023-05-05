using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using System.Security.Policy;

namespace DotNet6MVCWebApp.Middleware
{
    public class ReverseAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly LinkGenerator _linkGenerator;
        public ReverseAuthMiddleware(RequestDelegate next, LinkGenerator linkGenerator)
        {
            _next = next;
            _linkGenerator = linkGenerator;
        }
       
       
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
             
                if (httpContext.Response.StatusCode == 404)
                {
                    httpContext.Response.Redirect("/ShowthatController/Index");
                }
                UrlActionContext urlActionContext = new UrlActionContext();
                urlActionContext.Controller = "LoopUpload";
                urlActionContext.Action = "Index";
                var url = _linkGenerator.GetUriByAction(httpContext, action: urlActionContext.Action, controller: urlActionContext.Controller, null, httpContext.Request.Scheme);
               
            }
            catch (Exception ex)
            {

                throw;
            }
            

            // bool isAuthorized = true;
            var isAuthorized = httpContext.User.Claims.Any(c => c.Type != null && c.Value != null);
           
            
            //if (!isAuthorized && httpContext.Request.Path.Value != "/Login/Index")
            //{
            //    httpContext.Response.Redirect("/Login/Index");
            //}

            //If the user authenticated and the Path not login then we can Move forward into the pipeline
            await _next(httpContext);
        }

       
    }


}

