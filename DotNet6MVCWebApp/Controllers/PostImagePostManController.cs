using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace DotNet6MVCWebApp.Controllers
{
    public class PostImagePostManController : Controller
    {
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
          
           // return Ok(NotFound());
            return StatusCode(StatusCodes.Status404NotFound);
        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IResult GetById2dnWay(int id)
        {

            return Results.NotFound();
        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById3rdWay(int id)
        {

            return Ok(Results.NotFound());
        }
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult LoadImageType(Image? image)
        //{
        //    return View();
        //}
        public Image ByteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }
        dynamic getImage;
        public async Task<IActionResult> DownloadImage(string imageName)
        {
            // var path = Path.GetFullPath("./wwwroot/ImageName/Cover/" + imageName);
            var path = getImage;
            MemoryStream memory = new MemoryStream();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
           // return File(memory, "image/png", path);
            return File(memory, "image/png", path);
        }
        public IActionResult LoadImageType()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateImagenesQuejasOpinionesSugerencia([FromForm] QuejasSugerenciaOpinionesImagenesRequest quejasImagenesRequest, string issueKey)
        {
            string fileInBase64;
            try
            {
                using (var ms = new MemoryStream())
                {
                    quejasImagenesRequest.files.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    getImage = ByteArrayToImage(fileBytes);
                    fileInBase64 = Convert.ToBase64String(fileBytes);
                    ms.Position = 0;

                   
                   // return new FileContentResult(fileBytes, "image/png");
                 // return View("LoadImageType", new QuejasSugerenciaOpinionesImagenesRequest { fileInBase64= "data:image/jpg;base64," + fileInBase64 });
                }

                using (var client = new HttpClient())
                {
                    // Setting Base address.  
                    client.BaseAddress = new Uri($"http://localhost:5094/");
                    // Initialization.  
                    HttpResponseMessage response = new HttpResponseMessage();
                    // HTTP POST  
                  //  response = await client.PostAsJsonAsync($"api/rest/issue/{issueKey}/attachments", fileInBase64).ConfigureAwait(false);
                    response = await client.PostAsJsonAsync($"api/rest/CreateException", fileInBase64);
                    // Verification  
                    if (response.IsSuccessStatusCode)
                    {
                        // Reading Response.  
                        var result = await response.Content.ReadAsStringAsync();
                        //quejasImagenesResponse = JsonConvert.DeserializeObject<QuejasSugerenciaOpinionesImagenesResponse.Root>(result);
                    }
                }
                return Ok("");


            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            
        }
    }

    public class QuejasSugerenciaOpinionesImagenesRequest
    {
        
        public string? fileInBase64 { get; set; }
        public IFormFile files { get; set; }
    }
}