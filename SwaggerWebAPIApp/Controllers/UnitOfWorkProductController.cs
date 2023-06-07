using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerWebAPIApp.Interface;
using SwaggerWebAPIApp.Models;

namespace SwaggerWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfWorkProductController : ControllerBase
    {
        private readonly ILogger<UnitOfWorkProductController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkProductController(
            ILogger<UnitOfWorkProductController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var users = await _unitOfWork.Products.All();

            return Ok(users);
        }
    }

    
}
