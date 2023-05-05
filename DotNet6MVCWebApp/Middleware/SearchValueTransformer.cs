using DotNet6MVCWebApp.Interface;
using Microsoft.AspNetCore.Mvc.Routing;

namespace DotNet6MVCWebApp.Middleware
{
    public class SearchValueTransformer : DynamicRouteValueTransformer
    {
        private readonly IProductLocator _productLocator;

        public SearchValueTransformer(IProductLocator productLocator)
        {
            this._productLocator = productLocator;
        }

        public override async ValueTask<RouteValueDictionary> TransformAsync(

            HttpContext httpContext, RouteValueDictionary values)
        {
            var productString = values["product"] as string;
            var id = await this._productLocator.FindProduct("product", out var controller);

            values["controller"] = controller;
            values["action"] = "Get";
            values["id"] = id;

            return values;
        }
    }
}
