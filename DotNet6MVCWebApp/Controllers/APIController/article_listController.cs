using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DotNet6MVCWebApp.Controllers.BadRequestController;

namespace DotNet6MVCWebApp.Controllers.APIController
{[Route("api/[controller]")]
    [ApiController]
    public class article_listController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public async Task<bool> Create([FromBody] article_list article)
        {
            Console.WriteLine("Create");

            if (ModelState.IsValid)
            {
                return true;
            }
            return false;
        }
    }
    
}
