using Dotnet6App.Data;
using Dotnet6App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dotnet6App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecuteSpInDotNet6Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ExecuteSpInDotNet6Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ExecuteSpInDotNet6(int userId)
        {
            var sqlCommand = $"EXEC Supp {userId}";
            var getValueFromSp = await _context.MentorReps.FromSqlRaw(sqlCommand).ToListAsync();
            return Ok(getValueFromSp);
        }


    }
}
