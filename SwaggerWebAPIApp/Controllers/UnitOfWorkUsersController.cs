using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerWebAPIApp.Interface;
using SwaggerWebAPIApp.Models;

namespace SwaggerWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfWorkUsersController : ControllerBase
    {
        private readonly ILogger<UnitOfWorkUsersController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkUsersController(
            ILogger<UnitOfWorkUsersController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var users = await _unitOfWork.Users.All();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var item = await _unitOfWork.Users.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }



        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (ModelState.IsValid)
            {

                await _unitOfWork.Users.Add(user);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetItem", new { user.Id }, user);
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(Guid id, User user)
        {
            if (id != user.Id)
                return BadRequest();

            await _unitOfWork.Users.Upsert(user);
            await _unitOfWork.CompleteAsync();

            // Following up the REST standart on update we need to return NoContent
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var item = await _unitOfWork.Users.GetById(id);

            if (item == null)
                return BadRequest();

            await _unitOfWork.Users.Delete(id);
            await _unitOfWork.CompleteAsync();

            return Ok(item);
        }
    }
}
