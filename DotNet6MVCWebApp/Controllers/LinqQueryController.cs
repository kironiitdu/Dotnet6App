using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace DotNet6MVCWebApp.Controllers
{
    public class LinqQueryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetChildFromParentByCustomerId()
        {
            var childList = new List<ChildTable>()
            {
                new ChildTable(){ Id =101,ChildName = "Child-A",CustomerId = 202},
                new ChildTable(){ Id =102,ChildName = "Child-B",CustomerId = 203},
                new ChildTable(){ Id =103,ChildName = "Child-C",CustomerId = 202},
                new ChildTable(){ Id =104,ChildName = "Child-D",CustomerId = 204},


            };

            var parentList = new List<ParentTable>()
            {
                new ParentTable(){ Id =301,ParentName = "Parent-A",CustomerId = 202},
                new ParentTable(){ Id =302,ParentName = "Parent-B",CustomerId = 202},
                new ParentTable(){ Id =303,ParentName = "Parent-C",CustomerId = 203},
                new ParentTable(){ Id =304,ParentName = "Parent-D",CustomerId = 205},


            };


            //Way One
            var findMatchedByCustId = from child in childList
                                      where (from parent in parentList select parent.CustomerId)
                                      .Contains(child.CustomerId)
                                      select child;


            //Way Two

            var usingLinqJoin = (from parent in parentList
                                 join child in childList on parent.CustomerId equals child.CustomerId
                                 select parent).ToList().Distinct();




            return Ok(findMatchedByCustId);
        }
        public List<Cart> GetCart(int? Id)
        {
            var productList = new List<ProductTable>()
            {
                new ProductTable(){ Id =101,Name = "Pro-A",Stock = 50, Desc = "Product Desc A"},
                new ProductTable(){ Id =102,Name = "Pro-B",Stock = 100,Desc = "Product Desc B"},
                new ProductTable(){ Id =103,Name = "Pro-C",Stock = 130,Desc = "Product Desc C"},
                new ProductTable(){ Id =104,Name = "Pro-D",Stock = 200,Desc = "Product Desc D"},


            };
            var cartList = new List<Cart>()
            {
                new Cart(){ Id =1,Quantity = 5, ProductId = 101, ProductTable = productList.Where(p=>p.Id == 101).FirstOrDefault()},
                new Cart(){ Id =1,Quantity = 2, ProductId = 104, ProductTable = productList.FirstOrDefault(p=>p.Id == 104)},
                new Cart(){ Id =2,Quantity = 10, ProductId = 102, ProductTable = productList.FirstOrDefault(p=>p.Id == 102)},
                new Cart(){ Id =2,Quantity = 52, ProductId = 103, ProductTable = productList.FirstOrDefault(p=>p.Id == 103)},
                new Cart(){ Id =3,Quantity = 10, ProductId = 104, ProductTable = productList.FirstOrDefault(p=>p.Id == 104)},


            };
            return cartList.Where(cid=>cid.Id == Id).ToList();
        }
        public IActionResult IndexCart(int? cartId)
        {  
            var data = GetCart(cartId);
            return View(data);
        }


        public ActionResult GetProductDetailsFromProductIdInCart()
        {
            var productList = new List<ProductTable>()
            {
                new ProductTable(){ Id =101,Name = "Pro-A",Stock = 50, Desc = "Product Desc A"},
                new ProductTable(){ Id =102,Name = "Pro-B",Stock = 100,Desc = "Product Desc B"},
                new ProductTable(){ Id =103,Name = "Pro-C",Stock = 130,Desc = "Product Desc C"},
                new ProductTable(){ Id =104,Name = "Pro-D",Stock = 200,Desc = "Product Desc D"},


            };
            var cartList = new List<Cart>()
            {
                new Cart(){ Id =1,Quantity = 5, ProductId = 101, ProductTable = productList.Where(p=>p.Id == 101).FirstOrDefault()},
                new Cart(){ Id =1,Quantity = 2, ProductId = 104, ProductTable = productList.FirstOrDefault(p=>p.Id == 104)},



            };

            return Ok(cartList);
        }
    }

    public class ChildTable
    {
        public int Id { get; set; }
        public string ChildName { get; set; }
        public int CustomerId { get; set; }
    }

    public class ParentTable
    {
        public int Id { get; set; }
        public string ParentName { get; set; }
        public int CustomerId { get; set; }
    }

    public class ProductTable
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }
    public class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public virtual ProductTable? ProductTable { get; set; }
    }
}
