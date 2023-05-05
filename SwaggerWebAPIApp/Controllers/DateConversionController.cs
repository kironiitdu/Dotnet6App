using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Newtonsoft.Json;
using System.Text;

namespace SwaggerWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateConversionController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Create(MyProductClass product)
        {
            return Ok(product.Created);
        }
    }
    
    public class MyProductClass
    {
        public string Name { get; set; }

        public DateTime Created { get; set; }
    }

    public class ProductEntityBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(MyProductClass))
            {

                return new BinderTypeModelBinder(typeof(DateConversionModelBinder));
            }

            return null;
        }
    }
    public class DateConversionModelBinder : IModelBinder
    {

        public DateConversionModelBinder()
        {

        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            var request = bindingContext.HttpContext.Request;
            var stream = request.Body;// At the begining it holding original request stream                    
            var originalReader = new StreamReader(stream);
            var originalContent = originalReader.ReadToEndAsync();

           
            var retrieveObject = JsonConvert.DeserializeObject<dynamic>(originalContent.Result);

            var model = new MyProductClass();


            DateTime dateTime = Convert.ToDateTime(retrieveObject.created);


            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");

            DateTime cstTime = TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Local, cstZone);

            DateTime fromLocalTimeToUTC = TimeZoneInfo.ConvertTimeToUtc(cstTime, cstZone);



            model.Created = fromLocalTimeToUTC;
            model.Name = retrieveObject.name;



            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}
