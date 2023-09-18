using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace WindowsWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
          
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var status = await TrackDocumentProcessStatus();
                status = await TrackDocumentProcessStatus();
                if (status == "Success")
                {
                    break;

                }
                Console.WriteLine(status);
                await Task.Delay(1000, stoppingToken);
            }
        }

        public async Task<string> TrackDocumentProcessStatus()
        {
            var rquestObject = new StatusRequestModel();
            rquestObject.RequestId = 1;

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