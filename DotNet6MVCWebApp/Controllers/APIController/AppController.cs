using Azure.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Newtonsoft.Json;
using System.Text;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    [ApiController]
    public class AppController : ControllerBase
    {

        private readonly IWebHostEnvironment _environment;


        public AppController(IWebHostEnvironment environment)
        {
            _environment = environment;

        }
        [Route("api/GetSchoolsDetails")]
        [HttpPost("GetSchoolsDetails")]
        public ActionResult<SchoolModel> GetSchoolsDetails(string [] SchoolsUuid)
        {
           return Ok(SchoolsUuid);
        }
        [HttpPost]
        [Route("api/JsonToIFrom")]
        public async Task<IActionResult> JsonToIFrom([FromForm] APIRequestModel content)
        {
            var memoryStream = new MemoryStream(Encoding.Default.GetBytes(JsonConvert.SerializeObject(content)));

            var formFile = new FormFile(memoryStream, 0, memoryStream.Length, "test", "test.json");
            var path = Path.Combine(_environment.WebRootPath, "WriteIFromJson/", formFile.FileName);


            using (FileStream streamFile = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(streamFile);
                streamFile.Close();
            }
            return Ok(content);
        }



        [HttpPost]
        [Route("api/upload")]
        public async Task<IActionResult> UploadDocumentsAsync([FromForm] Request file)
        {
           
            return Ok(file);
        }


        [Route("UploadFiles")]
        [HttpPost]
        public async Task<ActionResult> PostComplexTypeData([FromForm] APIRequestModel requestModel)
        {
            try
            {
                var path = Path.Combine(_environment.WebRootPath, "WordAutomation/", requestModel.MyByteData.FileName);


                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await requestModel.MyByteData.CopyToAsync(stream);
                    stream.Close();
                }
                // System.IO.File.WriteAllBytes(@"C:\WordAutomation\home.zip", rawData);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error. msg: {ex.Message}");
            }
        }

        [Route("ProcessFoo")]
        [HttpPost]
        public IActionResult ProcessFoo(Foo foo)
        {
            return Ok(foo);
        }

    }

    public class SchoolModel
    {
        

    }
    //public class Foo
    //{
    //    public int Id { get; set; }
    //    public List<Thing> Things { get; set; }

    //}

    public class Thing
    {
        public string Name { get; set; }
    }
    public class APIRequestModel
    {
        public string FilePath { get; set; }
        public IFormFile MyByteData { get; set; }
    }

    public class Document
    {
        public string FileName { get; set; }
        public IFormFile Buffer { get; set; }
    }


    public class Request
    {
        public string Uploader { get; set; }
        public List<Document> Documents { get; set; }
    }


}
