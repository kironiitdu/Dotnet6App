using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.Swagger;
using IDocumentFilter = Swashbuckle.Swagger.IDocumentFilter;

namespace SwaggerWebAPIApp.Middleware
{
    public class CustomDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, System.Web.Http.Description.IApiExplorer apiExplorer)
        {
            //make operations alphabetic
            var paths = swaggerDoc.paths.OrderBy(e => e.Key).ToList();
            swaggerDoc.paths = paths.ToDictionary(e => e.Key, e => e.Value);
        }
    }
}
