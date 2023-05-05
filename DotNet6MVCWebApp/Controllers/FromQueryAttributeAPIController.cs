using AutoMapper.Internal;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using System.Linq;

namespace DotNet6MVCWebApp.Controllers
{
    [Route("api/FromQueryAttributeAPI")]
    [ApiController]
    public class FromQueryAttributeAPIController : ControllerBase
    {
        [HttpGet("search")]
        public IActionResult Search([FromQuery] MovieQuery movieQuery)
        {
            //Console.WriteLine($"name={movieQuery.Name} year={movieQuery.Year}");
            return Ok($"name={movieQuery.Name} year={movieQuery.Year}");
        }

        [HttpGet("GetFrom3Tables")]
        public IActionResult GetFrom3Tables()
        {
            List<Bags> listBags = new List<Bags>();
            listBags.Add(new Bags() {  Id = 101, Name = "Bag A", Quantity =10, Category = "Cat-A"});
            listBags.Add(new Bags() {  Id = 102, Name = "Bag B", Quantity =15, Category = "Cat-A"});
            listBags.Add(new Bags() {  Id = 103, Name = "Bag C", Quantity =20, Category = "Cat-A"});

            List<Shirts> listShirts = new List<Shirts>();
            listShirts.Add(new Shirts() { Id = 101, Name = "Shirt A", Quantity = 10, Category = "Cat-B" });
            listShirts.Add(new Shirts() { Id = 102, Name = "Shirt B", Quantity = 15, Category = "Cat-B" });
            listShirts.Add(new Shirts() { Id = 103, Name = "Shirt C", Quantity = 20, Category = "Cat-B" });

            List<Shoes> listShoes = new List<Shoes>();
            listShoes.Add(new Shoes() { Id = 101, Name = "Shirt A", Quantity = 10, Category = "Cat-S" });
            listShoes.Add(new Shoes() { Id = 102, Name = "Shirt B", Quantity = 15, Category = "Cat-S" });
            listShoes.Add(new Shoes() { Id = 103, Name = "Shirt C", Quantity = 20, Category = "Cat-S" });


            var genericClass = new List<GenericClass>();
            foreach (var item in listBags)
            {
                var bag = new GenericClass();
                bag.Id = item.Id;
                bag.Name = item.Name;
                bag.Quantity = item.Quantity;
                bag.Category = item.Category;
                genericClass.Add(bag);
            }
            
            foreach (var item in listShirts)
            {
                var shirt = new GenericClass();
                shirt.Id = item.Id;
                shirt.Name = item.Name;
                shirt.Quantity = item.Quantity;
                shirt.Category = item.Category;
                genericClass.Add(shirt);
            }

            foreach (var item in listShoes)
            {
                var shoes = new GenericClass();
                shoes.Id = item.Id;
                shoes.Name = item.Name;
                shoes.Quantity = item.Quantity;
                shoes.Category = item.Category;
                genericClass.Add(shoes);
            }


            //Way: 1 Linq Query

            var AllTableListUsingLinq = from a in listBags
                             join b in listShirts on a.Id equals b.Id
                             join c in listShoes on b.Id equals c.Id
                             select new
                             {
                                 FromBagsID = a.Id,
                                 FromBagsName = a.Name,
                                 FromBagsQuantity = a.Quantity,
                                 FromBagsCategory = a.Category,

                                 FromShirtsID = b.Id,
                                 FromShirtsName = b.Name,
                                 FromShirtsQuantity = b.Quantity,
                                 FromShirtsCategory = b.Category,

                                 FromShoesID = c.Id,
                                 FromShoesName = c.Name,
                                 FromShoesQuantity = c.Quantity,
                                 FromShoesCategory = c.Category

                             };

            //Way: 2 : ViewModel
            var allTableUsingViewModel = new AllViewModel();
            allTableUsingViewModel.Bags = listBags;
            allTableUsingViewModel.Shirts = listShirts;
            allTableUsingViewModel.Shoes = listShoes;
           

            return Ok(genericClass);
        }

        [HttpGet("GetFrom3TablesWithSameKey")]
        public IActionResult GetFrom3TablesWithSameKey()
        {
            List<Bags> listBags = new List<Bags>();
            listBags.Add(new Bags() { Id = 101, Name = "Bag A", Quantity = 10, Category = "Cat-A" });
            listBags.Add(new Bags() { Id = 102, Name = "Bag B", Quantity = 15, Category = "Cat-A" });
            listBags.Add(new Bags() { Id = 103, Name = "Bag C", Quantity = 20, Category = "Cat-A" });

            List<Shirts> listShirts = new List<Shirts>();
            listShirts.Add(new Shirts() { Id = 101, Name = "Shirt A", Quantity = 10, Category = "Cat-B" });
            listShirts.Add(new Shirts() { Id = 102, Name = "Shirt B", Quantity = 15, Category = "Cat-B" });
            listShirts.Add(new Shirts() { Id = 103, Name = "Shirt C", Quantity = 20, Category = "Cat-B" });

            List<Shoes> listShoes = new List<Shoes>();
            listShoes.Add(new Shoes() { Id = 101, Name = "Shirt A", Quantity = 10, Category = "Cat-S" });
            listShoes.Add(new Shoes() { Id = 102, Name = "Shirt B", Quantity = 15, Category = "Cat-S" });
            listShoes.Add(new Shoes() { Id = 103, Name = "Shirt C", Quantity = 20, Category = "Cat-S" });


            var genericClass = new List<GenericClass>();
           
            foreach (var item in listBags)
            {
                var bag = new GenericClass();
                bag.Id = item.Id;
                bag.Name = item.Name;
                bag.Quantity = item.Quantity;
                bag.Category = item.Category;
                genericClass.Add(bag);
            }

            foreach (var item in listShirts)
            {
                var shirt = new GenericClass();
                shirt.Id = item.Id;
                shirt.Name = item.Name;
                shirt.Quantity = item.Quantity;
                shirt.Category = item.Category;
                genericClass.Add(shirt);
            }

            foreach (var item in listShoes)
            {
                var shoes = new GenericClass();
                shoes.Id = item.Id;
                shoes.Name = item.Name;
                shoes.Quantity = item.Quantity;
                shoes.Category = item.Category;
                genericClass.Add(shoes);
            }

            return Ok(genericClass);
        }
    }

    public class MovieQuery
    {
        public string Name { get; set; }
        public int Year { get; set; }
    }
    public class GenericClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }
    public class Bags
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }
    public class Shirts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }
    public class Shoes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }

    public class AllViewModel
    {
        public List<Bags> Bags { get; set; }
        public List<Shirts> Shirts { get; set; }
        public List<Shoes> Shoes { get; set; }
    }
}
