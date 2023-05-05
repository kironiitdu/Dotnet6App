using DotNet6MVCWebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpPutStatusHandleController : ControllerBase
    {
        private readonly ApplicationDbContext _appDbContext;


        public HttpPutStatusHandleController(ApplicationDbContext studentDbContext)
        {
            _appDbContext = studentDbContext;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CaseInformation>>> UpdateCaseInformation(UpdateCaseInformation UpdateCaseInfo)
        {
            //First Check if the case exist
            var isCaseExist = _appDbContext.Teams.Where(check => check.TeamId == UpdateCaseInfo.CaseId || check.TeamName == UpdateCaseInfo.Code).FirstOrDefault();
            if (isCaseExist == null)
            {
                return NotFound();
            }
            // Execute Update Operation
            //using var connection = new SqlConnection(_config.GetConnectionString("SQlServer"));

            //var caseInfo = await connection.ExecuteAsync("dbo.UpdateCaseInformationByIDSP", UpdateCaseInfo, commandType: CommandType.StoredProcedure);


            //Return status what you want
            var updateMessage = "Case has been updated";
            return Ok(updateMessage);
        }
    }

    public class CaseInformation
    {

    }

    public class UpdateCaseInformation
    {
       public int CaseId { get; set; }
       public string Code { get; set; }
    }
}
