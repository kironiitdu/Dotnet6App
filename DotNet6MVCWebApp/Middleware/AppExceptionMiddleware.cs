using AspNetCore.Unobtrusive.Ajax;

namespace DotNet6MVCWebApp.Middleware
{
    public class AppExceptionMiddleware
    {
        private readonly RequestDelegate next;
        public AppExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            //  var _service = context.RequestServices.GetRequiredService<IUserAccountService>();

            try
            {
                var checkRequest = context.Request;

                var isAjax = checkRequest.IsAjaxRequest();
                if (isAjax)
                {
                    var redirectToDesiredURL = "http://localhost:5094/Home/Index";//URL you want to redirect

                    context.Response.Redirect(redirectToDesiredURL);
                }
                await next(context);
            }
            catch (Exception error)
            {

                //Log Error to db
                var routeData = context.GetRouteData();

                var controllerName = routeData?.Values["controller"];
                var actionName = routeData?.Values["action"];
                var areaName = routeData?.Values["area"];


                //_service.LogAppException(new Application.ViewModels.ErrorLogModel
                //{
                //    errorMessage = error.Message,
                //    errorSource = error.Source,
                //    errorXML = error.ToString(),
                //    errorType = error.GetType().Name,
                //    controllerName = controllerName == null ? "Unknown" : controllerName.ToString(),
                //    actionName = actionName == null ? "Unknown" : actionName.ToString(),
                //    areaName = areaName == null ? " " : areaName.ToString(),

                //});

                context.Response.Redirect(("/error/oops"));
                return;

            }
        }
    }


}
