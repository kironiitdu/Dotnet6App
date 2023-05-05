using Dotnet6App.Data;
using Dotnet6App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet6App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public UpdateController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateById(int id)
        {
            //Getting Stock By Product Id
            Stock? objStock = _context.Stocks.Where(pro => pro.ProdutctId.Equals(id)).FirstOrDefault();

            if (objStock != null)
            {
                objStock.StockNumber = 600;//Updating New Stock number

            }
            _context.SaveChanges();
            //Getting Stock By Same RawId and ProductId 
            var stocks = _context.Stocks.Where(stId => stId.RawId.Equals(stId.ProdutctId)).ToList();
            return Ok(stocks);
        }
    }
}
