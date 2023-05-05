using DocumentFormat.OpenXml.Office2010.Excel;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet6MVCWebApp.Controllers
{
    public class AjaxRedirectToAnotherActionController : Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult PriceSumByCategoryAndTotalOfALLCategory()
        {
            List<ProductByCateory> productListByCategory = new List<ProductByCateory>();
            productListByCategory.Add(new ProductByCateory() { Category = "Cat-A", Price = 150.5, ProductName = "Product1" });
            productListByCategory.Add(new ProductByCateory() { Category = "Cat-A", Price = 250.00, ProductName = "Product1" });
            productListByCategory.Add(new ProductByCateory() { Category = "Cat-B", Price = 150.50, ProductName = "Product2" });
            productListByCategory.Add(new ProductByCateory() { Category = "Cat-B", Price = 150.50, ProductName = "Product2" });
            productListByCategory.Add(new ProductByCateory() { Category = "Cat-C", Price = 500, ProductName = "Product3" });

            ViewBag.ProductList = productListByCategory;

            List<CalculativeProductByCateory> sumListByCategory = productListByCategory
                .GroupBy(cat => cat.Category)
                .Select(sumByCat => new CalculativeProductByCateory
                {
                    Category = sumByCat.First().Category,
                    ProductName = sumByCat.First().ProductName,
                    PriceSumByEachCategory = sumByCat.Sum(c => c.Price),
                    TotalPriceOfAllCategory = productListByCategory.Sum(p => p.Price)
                }).ToList();
            return View(sumListByCategory);
        }

        public IActionResult CreateOrderWithButtonCheckedProduct(List<ProductViewModel> productViewModel)
        {

           
            return View(productViewModel);

        }

       
        public IActionResult ListProduct(string data)
        {
            var productList = TempData["productViewModel"];
            List<ProductViewModel> productViewModel = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
            return View(productViewModel);
        }


        [HttpPost]
        public IActionResult CreateOrderWithButtonCheckedProducts(List<ProductViewModel> productViewModel)
        {
            string data = System.Text.Json.JsonSerializer.Serialize(productViewModel);
            TempData["productViewModel"] = data;
            return RedirectToAction("ListProduct", data);



        }

    }
    public class ProductByCateory
    {
        public string Category { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        
    }
    public class CalculativeProductByCateory
    {
        public string Category { get; set; }
        public string ProductName { get; set; }
        public double PriceSumByEachCategory { get; set; }
        public double TotalPriceOfAllCategory { get; set; } = 0;
    }
    public class ProductViewModel
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Cost { get; set; }
    }
}
