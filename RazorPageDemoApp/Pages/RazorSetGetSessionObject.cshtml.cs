using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace RazorPageDemoApp.Pages
{
    public class RazorSetGetSessionObjectModel : PageModel
    {
        public string? CourseName { get; set; }
        public decimal Price { get; set; }

        public IActionResult OnPostDelete(Course course)
        {
            if (course == null)
            {
                return RedirectToPage("./RazorSetGetSessionObject");
            }

            var cart = HttpContext.Session.GetComplexObjectSession<ShoppingCartObject>("ShoppingCart");
            cart!.Courses!.Remove(cart.Courses.Find(crs => crs.CourseName == course.CourseName));
            HttpContext.Session.SetComplexObjectSession("ShoppingCart", cart);

            return RedirectToPage("./RazorSetGetSessionObject");
        }

        public IActionResult OnPost(Course course)
        {
            AddToCart(course);

            return RedirectToPage("./RazorSetGetSessionObject");
        }
        public void AddToCart(Course course)
        {

            var cart = HttpContext.Session.GetComplexObjectSession<ShoppingCartObject>("ShoppingCart");
            if (cart != null)
            {
                cart!.Courses!.Add(course);
                HttpContext.Session.SetComplexObjectSession("ShoppingCart", cart);
            }
            else
            {
                cart = new ShoppingCartObject();
                cart!.Courses!.Add(course);
                HttpContext.Session.SetComplexObjectSession("ShoppingCart", cart);
            }

        }
    }

    public class ShoppingCartObject
    {
        public List<Course>? Courses { get; set; } = new List<Course>();
      
    }
    public class Course
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public decimal Price { get; set; }
    }
    public static class SessionExtension
    {
        //setting session
        public static void SetComplexObjectSession(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        //getting session
        public static T? GetComplexObjectSession<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
