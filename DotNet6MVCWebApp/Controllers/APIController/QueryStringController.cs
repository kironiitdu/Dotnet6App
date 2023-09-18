using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using static DotNet6MVCWebApp.Controllers.APIController.QueryStringController;

namespace DotNet6MVCWebApp.Controllers.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryStringController : ControllerBase
    {
        [HttpGet, Route("")]
        public async Task<IActionResult> Search([FromQuery] SearchCriteria? searchCriteria = null)
        {
            if (searchCriteria == null )
                return Ok("This never happens...");
            else
                return Ok("Non null value directed");
        }

        [ModelBinder(BinderType = typeof(NullEntityBinder))]
        public class SearchCriteria
        {
            public int? MyCustomIntValue { get; set; }
            public string? MyCustomStringSearchKey { get; set; }
        }
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

            var model = new SearchCriteria();



            if (bindingContext.ValueProvider.GetValue("MyCustomIntValue").FirstOrDefault() != null)
            {
                model.MyCustomIntValue = Convert.ToInt32(bindingContext.ValueProvider.GetValue("MyCustomIntValue").FirstOrDefault());
            }

            if (bindingContext.ValueProvider.GetValue("MyCustomStringSearchKey").FirstOrDefault() != null)
            {
                model.MyCustomStringSearchKey = bindingContext.ValueProvider.GetValue("MyCustomStringSearchKey").FirstOrDefault();
            }

            if (model.MyCustomIntValue == null && model.MyCustomStringSearchKey == null)
            {
                model = null;
                bindingContext.Result = ModelBindingResult.Success(null);
            }
            
            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}
