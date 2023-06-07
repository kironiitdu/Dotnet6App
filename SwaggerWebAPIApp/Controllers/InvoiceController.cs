using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerWebAPIApp.Data;
using SwaggerWebAPIApp.Models;

namespace SwaggerWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var Data = _context.Suppliers.ToList();
            var dataViewModel = new DataViewModel();
            dataViewModel.Data = Data;
            return Ok(dataViewModel);
        }
    }
}
