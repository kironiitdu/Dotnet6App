using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Interface;
using DotNet6MVCWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet6MVCWebApp.Implements
{
    public class BookstorerRepository : IBookstorerRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _environment;

        public BookstorerRepository(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _db = context;
        }
        public IList<Book> List()
        {
           
            return _db.Books.Include(a => a.Author).ToList();
        }
    }
}
