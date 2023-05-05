using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace DotNet6MVCWebApp.Controllers
{
    public class HttpClientController : Controller
    {

        private readonly IWebHostEnvironment _environment;


        public HttpClientController(IWebHostEnvironment environment)
        {
            _environment = environment;

        }
        public async Task<IActionResult> SendByteDataToAPIControllre()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            clientHandler.UseDefaultCredentials = true;
            HttpClient _httpClient = new HttpClient(clientHandler);
            _httpClient.DefaultRequestHeaders.Clear();

            //Bind Request Model

            var requestMode = new HttpClientReqeustModel();

            requestMode.MyByteData = System.IO.File.ReadAllBytes(@"D:\Md Farid Uddin Resume.pdf");
            requestMode.FilePath = @"D:\Md Farid Uddin Resume.pdf";
            requestMode.FileName = "MyFilename.pdf";

            //Create Multipart Request
            var formContent = new MultipartFormDataContent();

            formContent.Add(new StringContent(requestMode.FilePath), "FilePath");
            formContent.Add(new StreamContent(new MemoryStream(requestMode.MyByteData)), "MyByteData", requestMode.FileName);

            var response = await _httpClient.PostAsync("http://localhost:5094/UploadFiles", formContent);

            return Ok();
        }
        public async Task<IActionResult> Index()
        {

            var path = Path.Combine(_environment.WebRootPath, "Documents", "Md Farid Uddin Resume.pdf");
            var fileNameFromPath = System.IO.Path.GetFileName(path);
            var obj = new Request()
            {
                Uploader = "John Doe",
                Documents = new List<Document>
                    {
                        new Document()
                        {
                            FileName ="I Love Coding.pdf",
                           // Buffer = System.IO.File.ReadAllBytes(@"C:\Users\uddin\source\repos\Dotnet6App\DotNet6MVCWebApp\wwwroot\Documents\KironGitHub.pdf")
                            Buffer = System.IO.File.ReadAllBytes(@"D:\Md Farid Uddin Resume.pdf")
                        }
                    }
            };


            ////http://localhost:5094/api/Rest/CheckDocumentStatus
            //using (var http = new HttpClient())
            //{
            //    var encodedJson = JsonConvert.SerializeObject(obj);
            //    var conent = new StringContent(encodedJson, Encoding.UTF8, "application/json");
            //    HttpResponseMessage response = await http.PostAsync("http://localhost:5094/api/upload", conent);
            //    response.EnsureSuccessStatusCode();
            //}

            var httpClient = new HttpClient
            {
                BaseAddress = new("http://localhost:5094")
            };

            //await using var stream = System.IO.File.OpenRead(@"C:\Users\uddin\source\repos\Dotnet6App\DotNet6MVCWebApp\wwwroot\Documents\KironGitHub.pdf");

            //using var request = new HttpRequestMessage(HttpMethod.Post, "/api/upload");

            //using var content = new MultipartFormDataContent
            //    {
            //        { new StreamContent(stream), "file", "KironGitHub.pdf" }
            //    };

            //request.Content = content;

            //HttpResponseMessage response =  await client.SendAsync(request);

            var formContent = new MultipartFormDataContent();

            formContent.Add(new StringContent(obj.Uploader), "Uploader");

            formContent.Add(new StringContent(obj.Documents[0].FileName), "Documents[0].FileName");
            formContent.Add(new StreamContent(new MemoryStream(obj.Documents[0].Buffer)), "Documents[0].Buffer", obj.Documents[0].FileName);



            var response = await httpClient.PostAsync("/api/upload", formContent);



            return Ok();
        }
    }
    public class HttpClientReqeustModel
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public byte[] MyByteData { get; set; }
    }

    public class Document
    {
        public string FileName { get; set; }
        public byte[] Buffer { get; set; }
    }


    public class Request
    {
        public string Uploader { get; set; }
        public List<Document> Documents { get; set; }
    }
    //public class Document
    //{
    //    public string FileName { get; set; }
    //    public byte[] Buffer { get; set; }
    //}


    //public class Request
    //{
    //    public string Uploader { get; set; }
    //    public List<Document> Documents { get; set; }
    //}
}
