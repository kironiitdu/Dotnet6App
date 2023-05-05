using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerWebAPIApp.Middleware
{
    public class SwaggerAPIDocsShorting : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {

            var data = swaggerDoc.Tags.ToList();
            string[] methodsOrder = new string[4] { "get", "post", "put", "delete" };
            foreach (var path in swaggerDoc.Paths)
            {
                foreach (var key in path.Value.Operations.Keys)
                {
                    var paths = swaggerDoc.Paths.OrderBy(e => e.Key).ToList();


                }
            }

        }
    }
}
