using Microsoft.AspNetCore.Mvc;
using BlazorServerApp.ExtensionMethod;

namespace BlazorServerApp.Data
{
    public class CookieServiceBlazor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieServiceBlazor(IHttpContextAccessor httpContextAccessor)
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
            
            var options = new CookieOptions
            {
                Secure = true,
                IsEssential = true,
                HttpOnly = false,
            };


            if (daysToPersist > 0)
                options.Expires = DateTime.Now.AddDays((double)daysToPersist);
            else
                options.Expires = DateTime.Now.AddSeconds((double)60);

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, options);

        }
        public Task<CustomCookie> GetCookiesAsync()
        {
            WriteCookie("CookieKey", "Kiron Cookie Test Blazor", 30);
            var cookieObject = new CustomCookie();
            cookieObject.CookieKey = "CookieKey";
            cookieObject.CookieValue = ReadCookie("CookieKey");
            return Task.FromResult(cookieObject);
        }
    }

}

public class CustomCookie
{
    public string? CookieKey { get; set; }
    public string? CookieValue { get; set; }
}

