using Newtonsoft.Json;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace DotNet6MVCWebApp.Middleware
{
    public class IFromToJsonMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _environment;
        public IFromToJsonMiddleware(RequestDelegate next, IWebHostEnvironment environment)
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

            var retrieveObject = JsonConvert.DeserializeObject<dynamic>(originalContent);

            var someContent = new RequstBodyReaderModel();
            //someContent.HttpVerb = request.Method;
            //someContent.RequestPath = request.Path;
            //someContent.RequestRawData = originalContent;

            var ddd = JsonConvert.SerializeObject(someContent);

            var memoryStream = new MemoryStream(Encoding.Default.GetBytes(JsonConvert.SerializeObject(someContent)));

            var formFile = new FormFile(memoryStream, 0, memoryStream.Length, "test", "test.json");
            var path = Path.Combine(_environment.WebRootPath, "WriteIFromJson/", formFile.FileName);


            using (FileStream streamFile = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(streamFile);
                stream.Close();
            }

            await _next(context);

        }

        public class RequstBodyReaderModel
        {

           
            public string? HttpVerb { get; set; }
            public string? RequestPath { get; set; }
            public string RequestRawData { get; set; }
           
        }


    }
}

