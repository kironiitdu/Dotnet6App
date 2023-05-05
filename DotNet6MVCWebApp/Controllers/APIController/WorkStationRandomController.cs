using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers.APIController
{

   
    public class WorkStationRandomController : ControllerBase
    {
       
        [HttpPost]
        public IActionResult Post([FromBody] WorkStationRandomValueDTO data)
        {
            if (data != null && data.WorkStationId != 0 && data.Temperature != 0 && data.Pressure != 0)
            {
                //data.Status = true;
                //var workStation = _mapper.Map<WorkStation>(data);
                //_dbContext.WorkStations.Add(workStation);
                //_dbContext.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest("Data is not valid.");
            }
        }
    }

    public class WorkStationRandomValueDTO
    {
        public int WorkStationId { get; set; }
        public decimal Temperature { get; set; }
        public decimal Pressure { get; set; }
        public bool Status { get; set; }
    }

}
