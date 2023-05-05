using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class ViewModelErrorController : Controller
    {
        private readonly IEnumerable<EndpointDataSource> _endpointSources;
        public IEnumerable<RouteEndpoint> EndpointSources { get; set; }
        public ViewModelErrorController(IEnumerable<EndpointDataSource> endpointDataSources)
        {
            _endpointSources = endpointDataSources;
        }

        public IActionResult Index()
        {
            EndpointSources = _endpointSources
                       .SelectMany(es => es.Endpoints)
                       .OfType<RouteEndpoint>();
            ViewBag.EndpointSources = EndpointSources;
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }

    public class GetPageDetails
    {
        List<RouteEndpoint> EndpointSources { get; set; }
    }
}
