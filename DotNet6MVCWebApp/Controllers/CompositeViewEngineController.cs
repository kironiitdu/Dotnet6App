using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DotNet6MVCWebApp.Controllers
{
    public class CompositeViewEngineController : Controller
    {
        private readonly ICompositeViewEngine _viewEngine;

        public CompositeViewEngineController(ICompositeViewEngine viewEngine)
        {
            _viewEngine = viewEngine;
        }

        public  ActionResult Index()
        {
            var renderView =  GetViewAsString();
            return View(renderView);
        }
        public ActionResult Contact()
        {
            var renderView = GetViewAsString();

            ViewBag.Content = renderView;
            return View();
        }

        private string GetViewAsString()
        {
            ViewData.Model = new Template();
            var viewEngineResult = _viewEngine.FindView(ControllerContext, "Index", false);

            using (StringWriter sw = new StringWriter())
            {
                ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewEngineResult.View,
                    ViewData,
                    TempData,
                    sw,
                    new HtmlHelperOptions()
                );

                viewEngineResult.View.RenderAsync(viewContext);

                return sw.GetStringBuilder().ToString();
            }

        }
    }

    public class Template
    {
        public string PrimaryColour = "rgb(0, 21, 77)";
    }
}
