using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static DotNet6MVCWebApp.Controllers.BadRequestController;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AxiosWebApiController : ControllerBase
    {
        [HttpPost]
        [Route("CompanyDetails")]
        public async Task<IActionResult> CompanyDetails(List<CompanyDetails> companyDetails)
        {
            //Using all the data from the request here   
            return Ok(companyDetails);
        }
    }

    public class CompanyDetails
    {
        public string CompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
