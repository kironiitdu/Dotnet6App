using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace SwaggerWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        //[HttpPost("AddNewUser")]
        //public ActionResult AddNewUser([FromBody] UserModel userModel)
        //{
        //   return Ok(userModel);
        //}
        [HttpGet("GetUserWindowsUserName")]
        public IActionResult GetUserWindowsUserName()
        {
            string gettingWindowsUser = HttpContext.User.Identity?.Name;
            var responseMessage = string.Format("You have requested for User : {0}", gettingWindowsUser);
            return Ok(responseMessage);
        }

        [HttpPost("RandomErrorCodeGenerator")]
        public ActionResult RandomErrorCodeGenerator(NotFoundResponse notFoundResponse)
        {
            return Ok(notFoundResponse);
        }
    }
   
    public class NotFoundResponse
    {
       
       // [DefaultValue(ErrorCodes.MyCustomErrorCode)]
        public ErrorCodes ErrorCode { get; set; }
        public int NumericErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }

    public enum ErrorCodes
    {
       
        None = 0,
        RecordNotFound = 5,
        FileNotFound = 7,
        MyCustomErrorCode = 4004,
    }
    public class FilterQuery
    {
       
        public uint? AreaOfAdjustmentId { get; set; }
        public string? DocumentName { get; set; } 
       
    }

    public class OpenApiIgnoreEnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                var enumOpenApiStrings = new List<IOpenApiAny>();

                foreach (var enumValue in Enum.GetValues(context.Type))
                {
                    var member = context.Type.GetMember(enumValue.ToString())[0];
                    if (!member.GetCustomAttributes<OpenApiIgnoreEnumAttribute>().Any())
                    {
                        enumOpenApiStrings.Add(new OpenApiString(enumValue.ToString()));
                    }
                }

                schema.Enum = enumOpenApiStrings;
            }
        }
    }
    public class OpenApiIgnoreEnumAttribute : Attribute
    {
    }

    public class NullEntityBinder : IModelBinder
    {
        
        public NullEntityBinder()
        {
          
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

             var model = new FilterQuery();



            if (bindingContext.ValueProvider.GetValue("AreaOfAdjustmentId").FirstOrDefault() != null)
            {
                model.AreaOfAdjustmentId = Convert.ToUInt32(bindingContext.ValueProvider.GetValue("AreaOfAdjustmentId").FirstOrDefault());
            }

            if (bindingContext.ValueProvider.GetValue("DocumentName").FirstOrDefault() != null)
            {
                model.DocumentName = bindingContext.ValueProvider.GetValue("DocumentName").FirstOrDefault();
            }

            if (model.AreaOfAdjustmentId == null && model.DocumentName == null)
            {
                bindingContext.Result = ModelBindingResult.Success(null);
            }

            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public static class EnumExtension
    {
        public static Enum GetRandomEnumValue(this Type t)
        {
            return Enum.GetValues(t)          // get values from Type provided
                .OfType<Enum>()               // casts to Enum
                .OrderBy(e => Guid.NewGuid()) // mess with order of results
                .FirstOrDefault();            // take first item in result
        }
    }
}
