namespace BlazorServerApp.ExtensionMethod
{
    public class AppManager : IAppManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

     

        public string ReadCookie(string key)
        {
          
            var data = _httpContextAccessor.HttpContext.Request.Cookies[key];

            return data;
        }

        public void WriteCookie(string key, string value, int? daysToPersist = null)
        {
            //// HAVE TRIED VARIOUS OPTIONS HERE
            var options = new CookieOptions
            {
               // SameSite = SameSiteMode.None,
                Secure = true,
                IsEssential = true,
                HttpOnly = false
            };


            if (daysToPersist > 0)
                options.Expires = DateTime.Now.AddDays((double)daysToPersist);
            else
                options.Expires = DateTime.Now.AddSeconds((double)60);

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, options);

        }

        public void DeleteCookie(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }

    }
}
