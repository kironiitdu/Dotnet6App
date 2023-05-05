namespace Dotnet6MVC.Middleware
{
    public class MyShortCircuitMiddleware
    {
        private readonly RequestDelegate _next;
        public MyShortCircuitMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {

            //await httpContext.Response.WriteAsync("MyShortCircuitMiddleware Again Called");
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
