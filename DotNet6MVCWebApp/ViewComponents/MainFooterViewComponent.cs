using DotNet6MVCWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.ViewComponents
{
    [ViewComponent(Name = "MainFooter")]
    public class MainFooterViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public MainFooterViewComponent(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var memberList = _context.Members.ToList();
            //string lastUpdateTime = System.IO.File.ReadAllText("./last.txt");
            // string lastUpdateTime = "I am from View Component";

            return View("MainFooter", memberList);
        }
    }
}
