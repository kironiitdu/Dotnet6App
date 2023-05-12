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

        public IActionResult OnPostDelete(CartItem course)
        {
            if (course == null)
            {
                return RedirectToPage("./RazorSetGetSessionObject");
            }
            //Calling Item Remove Method and passing cart item
            RemoveItemFromCart(course);

            return RedirectToPage("./RazorSetGetSessionObject");
        }

        public void RemoveItemFromCart(CartItem course)
        {
            var cart = HttpContext.Session.GetComplexObjectSession<ShoppingCartObject>("ShoppingCart");
            cart!.CartItems!.Remove(cart.CartItems.Find(crs => crs.CourseName == course.CourseName));
            HttpContext.Session.SetComplexObjectSession("ShoppingCart", cart);
        }

        public IActionResult OnPost(CartItem course)
        {
            AddToCart(course);

            return RedirectToPage("./RazorSetGetSessionObject");
        }
        public void AddToCart(CartItem course)
        {

            var cart = HttpContext.Session.GetComplexObjectSession<ShoppingCartObject>("ShoppingCart");
            if (cart != null)
            {
                cart!.CartItems!.Add(course);
                HttpContext.Session.SetComplexObjectSession("ShoppingCart", cart);
            }
            else
            {
                cart = new ShoppingCartObject();
                cart!.CartItems!.Add(course);
                HttpContext.Session.SetComplexObjectSession("ShoppingCart", cart);
            }

        }
    }

    public class ShoppingCartObject
    {
        public List<CartItem>? CartItems { get; set; } = new List<CartItem>();
      
    }
    public class CartItem
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
