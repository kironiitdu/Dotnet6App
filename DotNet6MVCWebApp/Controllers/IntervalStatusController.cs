using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static DotNet6MVCWebApp.Controllers.TodoController;
using System.Net;
using System.Net.Http.Headers;

namespace DotNet6MVCWebApp.Controllers
{
    public class IntervalStatusController : Controller
    {
        public async Task<IActionResult> DocumentProcess()
        {

            var status = await TrackDocumentProcessStatus();

            if (status == "Success")
            {

                return Ok(status);
            }
            else
            {
                var timer = new PeriodicTimer(TimeSpan.FromSeconds(10));

                int counter = 0;
                while (await timer.WaitForNextTickAsync())
                {
                    counter++;
                    status = await TrackDocumentProcessStatus();
                    if (status == "Success")
                    {
                        break;
                       
                    }
                    continue;
                }
            }

            return Ok();
        }

        public async Task<string> TrackDocumentProcessStatus()
        {
            var rquestObject = new StatusRequestModel();
            rquestObject.RequestId = 3;

            var data_ = JsonConvert.SerializeObject(rquestObject);
            HttpClient _httpClient = new HttpClient();
            var buffer_ = System.Text.Encoding.UTF8.GetBytes(data_);
            var byteContent_ = new ByteArrayContent(buffer_);
            byteContent_.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            string _urls = "http://localhost:5094/api/Rest/CheckDocumentStatus";
            var responses_ = await _httpClient.PostAsync(_urls, byteContent_);

            if (responses_.StatusCode != HttpStatusCode.OK)
            {
                return "Pending";

            }
            string response = await responses_.Content.ReadAsStringAsync();
            return response;

        }
    }

    public class StatusRequestModel
    {
        public int RequestId { get; set; }
    }

    public class StatusResponseModel
    {
        public string Status { get; set; }
    }
}
