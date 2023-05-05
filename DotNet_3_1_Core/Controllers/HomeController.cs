using DotNet_3_1_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_3_1_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        //public List<ProductOrderDto> GetProductOrderDetails()
        //{
        //    using (EtnContext context = new EtnContext())
        //    {
        //        var model = new List<ProductOrderDto>();

        //        model.Add(context.Products.Include(i => i.ProductOrders).ThenInclude(i => i.Order).ToList());
        //        model.Add(context.Orders.Include(i => i.ProductOrders).ThenInclude(i => i.Product).ToList());
        //        return model;
        //    }
        //}

        //public List<ProductOrderDto> GetProductOrderDetails2()
        //{
        //    using (EtnContext context = new EtnContext())
        //    {
        //        //As your method signature is List<ProductOrderDto> thus, define your list type
        //        var model = new List<ProductOrderDto>();
        //        //Get each collection of products and Orders
        //        var products = context.Products.Include(i => i.ProductOrders).ThenInclude(i => i.Order).ToList();
        //        var orders = context.Orders.Include(i => i.ProductOrders).ThenInclude(i => i.Product).ToList();

        //        //Bind products and Orders Into List
        //        model.Add(products);
        //        model.Add(orders);

        //       // Now You can return your list
        //        return model;
        //    }
        //}

        //public ProductOrderDto GetProductOrderDetails()
        //{
        //    using (EtnContext context = new EtnContext())
        //    {
        //        var model = new ProductOrderDto();

        //        model.Products = context.Products.Include(i => i.ProductOrders).ThenInclude(i => i.Order).ToList();
        //        model.Orders  = context.Orders.Include(i => i.ProductOrders).ThenInclude(i => i.Product).ToList();
        //        return model;
        //    }
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class ProductOrder
    {

        public int PId { get; set; }
        public Product Product { get; set; }

        public int OId { get; set; }
        public Order Order { get; set; }
    }

    public class ProductOrderDto
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }

    public class Product
    {
    }

    public class Order
    {
    }
}
