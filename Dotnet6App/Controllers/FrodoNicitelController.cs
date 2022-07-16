using Dotnet6App.Data;
using Dotnet6App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Dotnet6App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrodoNicitelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FrodoNicitelController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("{idZamestnanca}")]
        public async Task<ActionResult> GetPredoslepozicie(int idZamestnanca)
        {
            var Predoslepozicie = _context.Predoslepozicies.Where(id => id.idZamestnanca == idZamestnanca).ToList();

            if (Predoslepozicie == null)
            {
                return NotFound();
            }

            return Ok(Predoslepozicie);
        }
        //[HttpGet("{idZamestnanca}")]
        //public async Task<ActionResult<List<Predoslepozicie>>> GetPredoslepozicie(int idZamestnanca)
        //{
        //    var Predoslepozicie = _context.Predoslepozicies.Where(id => id.idZamestnanca == idZamestnanca).ToList();

        //    if (Predoslepozicie == null)
        //    {
        //        return NotFound();
        //    }

        //    return Predoslepozicie;
        //}

        [HttpGet]
        public async Task<ActionResult> GetPredoslepozicieById(int idZamestnanca)
        {
            var Predoslepozicie = await _context.Predoslepozicies.FindAsync(idZamestnanca);

            if (Predoslepozicie == null)
            {
                return NotFound(Predoslepozicie);
            }
            return Ok(Predoslepozicie);
        }
    }
}
