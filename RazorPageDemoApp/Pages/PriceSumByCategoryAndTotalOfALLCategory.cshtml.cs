using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageDemoApp.Pages
{
    public class PriceSumByCategoryAndTotalOfALLCategoryModel : PageModel
    {
        public List<CalculativeProductByCateory>  calculativeProductByCateories { get; set; }
        public List<ProductByCateory>  ListProductCateories { get; set; }
        public void OnGet()
        {
            List<ProductByCateory> productListByCategory = new List<ProductByCateory>();
            productListByCategory.Add(new ProductByCateory() { Category = "Cat-A", Price = 150.5, ProductName = "Product1" });
            productListByCategory.Add(new ProductByCateory() { Category = "Cat-A", Price = 250.00, ProductName = "Product1" });
            productListByCategory.Add(new ProductByCateory() { Category = "Cat-B", Price = 150.50, ProductName = "Product2" });
            productListByCategory.Add(new ProductByCateory() { Category = "Cat-B", Price = 150.50, ProductName = "Product2" });
            productListByCategory.Add(new ProductByCateory() { Category = "Cat-C", Price = 500, ProductName = "Product3" });

            ListProductCateories = productListByCategory;

            List<CalculativeProductByCateory> sumListByCategory = productListByCategory
                .GroupBy(cat => cat.Category)
                .Select(sumByCat => new CalculativeProductByCateory
                {
                    Category = sumByCat.First().Category,
                    ProductName = sumByCat.First().ProductName,
                    PriceSumByEachCategory = sumByCat.Sum(c => c.Price),
                    TotalPriceOfAllCategory = productListByCategory.Sum(p => p.Price)
                }).ToList();
            calculativeProductByCateories = sumListByCategory;
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
}
