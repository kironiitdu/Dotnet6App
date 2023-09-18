using DotNet6MVCWebApp.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class BookStorerController : Controller
    {
        private readonly IBookstorerRepository _bookRepository;

        public BookStorerController(IBookstorerRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
          
            var booklist = _bookRepository.List();
            if (booklist.Count == 0)
            {
                return Content("No data found!");
            }
            return View(booklist);
        }
    }
}
