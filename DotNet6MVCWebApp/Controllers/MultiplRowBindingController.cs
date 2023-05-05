using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class MultiplRowBindingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var orders = new List<Orders>();
            return View(orders);
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Create(List<Orders> Orders)
        {
            Orders newOrders = new Orders();

            foreach (var order in Orders)
            {
                newOrders.Id = 0;
                newOrders.CustomerId = order.CustomerId;
                newOrders.ItemName = order.ItemName;
                newOrders.Price = order.Price;
            }
            return View("Create");
            // I will be processing newOrders into application/json and sending to the backend API
        }
    }

    public class Orders
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string ItemName { get; set; }
        public double Price { get; set; }
    }
}
