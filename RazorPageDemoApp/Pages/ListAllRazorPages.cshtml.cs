using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using System.Reflection;

namespace RazorPageDemoApp.Pages
{
    public class ListAllRazorPagesModel : PageModel
    {
        private readonly IEnumerable<EndpointDataSource> _endpointSources;
        public ListAllRazorPagesModel(IEnumerable<EndpointDataSource> endpointDataSources)
        {
            _endpointSources = endpointDataSources;
        }
       
        public IEnumerable<RouteEndpoint> EndpointSources { get; set; }
        public void OnGet()
        {

            EndpointSources = _endpointSources
                        .SelectMany(es => es.Endpoints)
                        .OfType<RouteEndpoint>();
            
            

            

        }
    }
}
