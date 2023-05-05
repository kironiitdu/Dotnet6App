using Azure.Core;
using DotNet6MVCWebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static DotNet6MVCWebApp.Controllers.BadRequestController;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestController : ControllerBase
    {
        //[HttpPost("issue/{issue}/attachments")]
        //public IActionResult Rest([FromRoute]string issue, [FromBody]string attachments)
        //{
        //    return Ok(attachments);
        //}
        private readonly ApplicationDbContext _appDbContext;


        public RestController(ApplicationDbContext dbContext)
        {
            _appDbContext = dbContext;
        }
        
        [HttpPost]
        [Route("CheckDocumentStatus")]
        public async Task<IActionResult> CheckDocumentStatus([FromBody] StatusRequestModel obj)
        {
            try
            {
                var checkStatus = _appDbContext.Progs.Where(id => id.BookId == obj.RequestId).FirstOrDefault();

                return Ok(checkStatus?.Status);
            }
            catch (Exception ex)
            {

                throw;
            }
           
           
        }
        //authorization

    }

    public class StatusRequestModel
    {
        public int RequestId { get; set; }
    }

}
