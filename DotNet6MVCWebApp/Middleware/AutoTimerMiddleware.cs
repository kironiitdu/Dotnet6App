namespace DotNet6MVCWebApp.Middleware
{
    public class AutoTimerMiddleware
    {
        private readonly RequestDelegate _next;
        public AutoTimerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {


            var timer = new PeriodicTimer(TimeSpan.FromSeconds(5));

            int counter = 0;
            while (await timer.WaitForNextTickAsync())
            {
                counter++;
               //if (counter > 5) break;
                CallThisMethodEvery5Second(counter);
            }
            // Move forward into the pipeline
            await _next(httpContext);
        }
        public void CallThisMethodEvery5Second(int counter)
        {
            Console.WriteLine("Current counter: {0} Last Fired At: {1}", counter, DateTime.Now);
        }
    }
}
