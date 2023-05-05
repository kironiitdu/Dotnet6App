using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerWebAPIApp.Interface;

namespace SwaggerWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerNamesServiceController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public ServerNamesServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(object id)
        {
            var item = _unitOfWork.ServerNamesService.GetByID(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        //private readonly IserverNamesService _serverNamesService;

        //public ServerNamesServiceController(IserverNamesService namesService)
        //{
        //    _serverNamesService = namesService;
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(object id)
        //{
        //    var item = _serverNamesService.GetByID(id);

        //    if (item == null)
        //        return NotFound();

        //    return Ok(item);
        //}

    }
}
