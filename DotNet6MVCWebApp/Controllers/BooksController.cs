using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Create()
        //{
        //    var genreList = new List<Genre>()
        //    {
        //        new Genre(){ Id =1, Name = "Thrillere"},
        //        new Genre(){ Id =2, Name = "Comedy"},
        //        new Genre(){ Id =3, Name = "Horror"}
               
             

        //    };

        //    CreateViewModel model = new CreateViewModel();
        //    model.Book = new Book();
        //    model.Genres = genreList;
        //    return View(model);
        //}
    }
}
