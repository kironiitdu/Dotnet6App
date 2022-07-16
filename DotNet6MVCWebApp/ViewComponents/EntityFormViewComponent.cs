using DotNet6MVCWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.ViewComponents
{
    [ViewComponent(Name = "EntityForm")]
    public class EntityFormViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public EntityFormViewComponent(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var animalList = _context.Animals.ToList();
            string lastUpdateTime = System.IO.File.ReadAllText("./last.txt");
            // string lastUpdateTime = "I am from View Component";

            return View("EntityForm", animalList);
        }
    }
}
