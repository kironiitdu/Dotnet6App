using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;


        public UploadController(IWebHostEnvironment environment)
        {
            _environment = environment;

        }
        [HttpPost("UploadFromWebFormApp")]
        public async Task<ActionResult> UploadFromWebFormApp([FromForm] FileUploadRequestModel requestModel)
        {

            if (requestModel == null)
            {
                return BadRequest();
            }
            var path = Path.Combine(_environment.WebRootPath, "Files/", requestModel.MyFile.FileName);


            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await requestModel.MyFile.CopyToAsync(stream);
                stream.Close();
            }
            UploadFile uploadFile = new UploadFile()
            {
                FileName = requestModel.MyFile.FileName,
                TempFilPathWithName = path
            };
            return Ok(uploadFile);

            //ResponseViewModel responseModel = new ResponseViewModel();
            //try
            //{
            //    if (fileUpload == null)
            //    {
            //        responseModel.Message = "Please select file.";
            //        return BadRequest(responseModel);
            //    }

            //    //file upload to temp folder
            //    string tempFilPathWithName = Path.GetTempFileName();
            //    using (FileStream file = System.IO.File.OpenWrite(tempFilPathWithName))
            //    {
            //        fileUpload.CopyTo(file);
            //    }
            //    UploadFile uploadFile = new UploadFile()
            //    {
            //        FileName = fileUpload.FileName,
            //        TempFilPathWithName = tempFilPathWithName
            //    };

            //    responseModel.Model = uploadFile;
            //    responseModel.Message = "File successfully uploaded";
            //    return Ok(responseModel);
            //}
            //catch (Exception ex)
            //{
            //    responseModel.ExceptionMessage = ex.ToString();
            //    responseModel.Message = "File upload failed.";
            //}
            //return BadRequest(responseModel);
        }

        [HttpPost("UploadFromWebFromToWebAPI")]
        public IActionResult Upload([FromForm] IFormFile fileUpload)
        {
            ResponseViewModel responseModel = new ResponseViewModel();
            try
            {
                if (fileUpload == null)
                {
                    responseModel.Message = "Please select file.";
                    return BadRequest(responseModel);
                }

                //file upload to temp folder
                string tempFilPathWithName = Path.GetTempFileName();
                using (FileStream file = System.IO.File.OpenWrite(tempFilPathWithName))
                {
                    fileUpload.CopyTo(file);
                }
                UploadFile uploadFile = new UploadFile()
                {
                    FileName = fileUpload.FileName,
                    TempFilPathWithName = tempFilPathWithName
                };

                responseModel.Model = uploadFile;
                responseModel.Message = "File successfully uploaded";
                responseModel.ExceptionMessage = "N/A";
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                responseModel.ExceptionMessage = ex.ToString();
                responseModel.Message = "File upload failed.";
            }
            return BadRequest(responseModel);
        }
        [HttpPost("UploadFromWebFromToWebAPI2")]
        public async Task<ActionResult> UploadFromWebFromToWebAPI([FromForm] IFormFile formFile)
        {

            if (formFile.FileName == null)
            {
                return BadRequest();
            }
            var path = Path.Combine(_environment.WebRootPath, "Files/", formFile.FileName);


            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
                stream.Close();
            }
            UploadFile uploadFile = new UploadFile()
            {
                FileName = formFile.FileName,
                TempFilPathWithName = path
            };


            var responseViewModel = new ResponseViewModel();
            responseViewModel.Model = uploadFile;
            responseViewModel.Message = "File Uploaded...";
            responseViewModel.ExceptionMessage = "N/A";
            return Ok(responseViewModel);

        }
        [Route("UploadFiles")]
        [HttpPost]
        public async Task<ActionResult> PostComplexTypeData([FromForm] APIRequestModel requestModel)
        {
            try
            {
                var path = Path.Combine(_environment.WebRootPath, "Files/", requestModel.MyByteData.FileName);


                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await requestModel.MyByteData.CopyToAsync(stream);
                    stream.Close();
                }
                UploadFile uploadFile = new UploadFile()
                {
                    FileName = requestModel.MyByteData.FileName,
                    TempFilPathWithName = path
                };

                var responseViewModel = new ResponseViewModel();
                responseViewModel.Model = uploadFile;
                responseViewModel.Message = "File Uploaded...";
                responseViewModel.ExceptionMessage = "N/A";
                return Ok(responseViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error. msg: {ex.Message}");
            }
        }
    }

    public class ResponseViewModel
    {
        public object Model { get; set; }
        public string ExceptionMessage { get; set; }
        public string Message { get; set; }
    }

    public class UploadFile
    {
        public string FileName { get; set; }
        public string TempFilPathWithName { get; set; }
    }
    public class APIRequestModel
    {
        public string FilePath { get; set; }
        public IFormFile MyByteData { get; set; }
    }
    public class FileUploadRequestModel
    {
       
        public IFormFile MyFile { get; set; }
    }
}
