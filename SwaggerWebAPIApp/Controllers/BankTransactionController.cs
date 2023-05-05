using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace SwaggerWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankTransactionController : ControllerBase
    {

        [HttpGet("GetAccountBalance")]
        public async Task<ActionResult<BankTransactionDto>> GetAccountBalance([FromQuery] BankTransactionDto bankDto)
        {
            //var results = await _bankTransactionService.GetTotalBalance(bankDto);
            return Ok(bankDto);
        }
        [HttpPost("GenericAction")]
        public async Task<ActionResult> GenericAction(IFormCollection param)
        {
            //var results = await _bankTransactionService.GetTotalBalance(bankDto);
            return Ok(param);
        }
        [HttpPost("UploadMultipleFile")]
        public async Task<bool> UploadMultipleFile(List<IFormFile> formFiles)
        {
            try
            {
                //if (_isInProgress)
                //{
                //    return false;
                //}

                //HttpContext.Request.EnableBuffering(bufferThreshold: 1024 * 45, bufferLimit: 1024 * 100);
                // var ddd = HttpContext.Response.BodyWriter;



                var totalBytes = formFiles.Sum(f => f.Length);

                foreach (var formFile in formFiles)
                {
                    // _isInProgress = true;

                    var buffer = new byte[16 * 1024];

                    //  await using var fileStream = File.Create(GetUploadPath() + Path.GetExtension(formFile.FileName));
                    // await using var stream = formFile.OpenReadStream();
                    await using var stream = formFile.OpenReadStream();


                    long totalReadBytes = 0;
                    int readBytes;

                    while ((readBytes = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        var ms = new MemoryStream();
                        await ms.WriteAsync(buffer, 0, readBytes);
                        //  await stream.WriteAsync(buffer, 0, readBytes);
                        //await stream.WriteAsync(new ReadOnlyMemory<byte>(buffer));
                        // await stream.FlushAsync();
                        totalReadBytes += readBytes;

                        //   _completedPercentOfUploadProgress = (int)(totalReadBytes / (float)totalBytes * 100.0);
                        await Task.Delay(10); // It is only to make the process slower
                    }
                }

                //  _isInProgress = false;

                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }
    }
    public class BankTransactionDto
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }

    //[FromQuery]
}
