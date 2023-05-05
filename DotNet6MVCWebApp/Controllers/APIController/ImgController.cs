using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgController : ControllerBase
    {
        [HttpGet]
        [Route("get/{**slug}")]
        public byte[] Get1([FromRoute] string slug)
        {
            var path = HttpContext.Request.Path.ToString();
            var routeValues = path.Split('/').Skip(3).ToArray();
            return null;
        }

        //[HttpGet]
        //[Route("get")]
        //public byte[] Get([FromQuery] string? parameters)
        //{
        //    return null;
        //}
    }


    
}
