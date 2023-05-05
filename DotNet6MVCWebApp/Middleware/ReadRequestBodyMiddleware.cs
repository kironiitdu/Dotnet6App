using DocumentFormat.OpenXml.Spreadsheet;
using DotNet6MVCWebApp.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.Graph;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;


namespace DotNet6MVCWebApp.Middleware
{
    public class ReadRequestBodyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _environment;
        public ReadRequestBodyMiddleware(RequestDelegate next, IWebHostEnvironment environment)
        {
            _next = next;
            _environment = environment;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            var stream = request.Body;// At the begining it holding original request stream                    
            var originalReader = new StreamReader(stream);
            var originalContent = await originalReader.ReadToEndAsync(); // Reading first request

            var retrieveObject = JsonConvert.DeserializeObject<dynamic> (originalContent);

            var readingRequestBody = new RequstBodyReaderModel();
            readingRequestBody.HttpVerb = request.Method;
            readingRequestBody.RequestPath = request.Path;
            readingRequestBody.RequestRawData = originalContent;
            readingRequestBody.HttpStatusCode = HttpStatusCode.OK.ToString();
            //    readingRequestBody.Message = "One of the model binding faild!";

            var memoryStream = new MemoryStream(Encoding.Default.GetBytes(JsonConvert.SerializeObject(readingRequestBody)));

            var formFile = new FormFile(memoryStream, 0, memoryStream.Length, "test", "test.json");
            var path = Path.Combine(_environment.WebRootPath, "WriteIFromJson/", formFile.FileName);


            using (FileStream streamFile = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(streamFile);
                stream.Close();
            }

            //if (retrieveObject)
            //{
            //    //My Custom Response Class 
            //    var readingRequestBody = new RequstBodyReaderModel();
            //    readingRequestBody.HttpVerb = request.Method;
            //    readingRequestBody.RequestPath = request.Path;
            //    readingRequestBody.RequestRawData = originalContent;
            //    readingRequestBody.HttpStatusCode = HttpStatusCode.OK.ToString();
            //    readingRequestBody.Message = "One of the model binding faild!";

            //    //converting my custom response class to jsontype
            //    var json = JsonConvert.SerializeObject(readingRequestBody);
            //    //Modifying existing stream
            //    var requestData = Encoding.UTF8.GetBytes(json);
            //    stream = new MemoryStream(requestData);
            //    request.Body = stream;
            //}


            request.Body = stream;
            await _next(context);
            
        }

        public class RequstBodyReaderModel
        {
            [IgnoreDataMember]
            public string? HttpStatusCode { get; set; }
            public string? HttpVerb { get; set; }
            public string? RequestPath { get; set; }
            public string RequestRawData { get; set; }
            public string? Message { get; set; }
        }

        
    }
}
