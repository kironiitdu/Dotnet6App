using Newtonsoft.Json;
using System.Text;

namespace DotNet6MVCWebApp.Middleware
{
    public class OverrideResponseBodyMiddleware
    {
        private readonly RequestDelegate _next;
        public OverrideResponseBodyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            var stream = request.Body;// At the begining it holding original request stream                    
            var originalReader = new StreamReader(stream);
            var originalContent = await originalReader.ReadToEndAsync(); // Reading first request
           

            if (context.Response.StatusCode == 200)
            {
               
                //My Custom Response Class 
                var overringNewResponse = new ApiCustomResponseClass();
                overringNewResponse.ResponseCode = "400";
                overringNewResponse.OldRequestBody = originalContent;
                overringNewResponse.ResponseMessage = "Here I am overring the request body";

                //converting my custom response class to jsontype
                var json = JsonConvert.SerializeObject(overringNewResponse);
                //Modifying existing stream
                var requestData = Encoding.UTF8.GetBytes(json);
                stream = new MemoryStream(requestData);
                
            }
            else {

                //Binding original data as it is
                var requestData = Encoding.UTF8.GetBytes(originalContent);
                stream = new MemoryStream(requestData);
                
            }
            
            //Writing the new response body with  modified steam of custom response
            request.Body = stream;

            await _next(context);
        }

        public class ApiCustomResponseClass
        {
            public string? ResponseCode { get; set; }
            public string? OldRequestBody { get; set; }
            public string? ResponseMessage { get; set; }
        }
    }
}
