using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DotNet6MVCWebApp.Controllers
{
    public class MultipartFromDataUploadController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            clientHandler.UseDefaultCredentials = true;
            HttpClient client2 = new HttpClient(clientHandler);
            client2.DefaultRequestHeaders.Clear();

            //Bind Request Model

            var requestMode = new HttpClientReqeustModel();

            requestMode.MyByteData = System.IO.File.ReadAllBytes(@"D:\Md Farid Uddin Resume.pdf");
            requestMode.FilePath = @"D:\Md Farid Uddin Resume.pdf";
            requestMode.FileName = "MyFilename.pdf";

            //Create Multipart Request
            var formContent = new MultipartFormDataContent();

            formContent.Add(new StringContent(requestMode.FilePath), "FilePath");
            formContent.Add(new StreamContent(new MemoryStream(requestMode.MyByteData)), "MyByteData", requestMode.FileName);

            var response = await client2.PostAsync("http://localhost:5094/UploadFiles", formContent);

            return View();
        }
    }


}
