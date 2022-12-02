namespace DotNet6MVCWebApp.Middleware
{
    public class CustomHttpHttpsRequestMiddleware
    {
        private readonly RequestDelegate next;
        public CustomHttpHttpsRequestMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                env = "Production";
            if (env == "Development")
            {
                await next(context);
            }
            else
            {
                if (!context.Request.IsHttps)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("HTTPS required!");
                }
            }


        }
    }
}
