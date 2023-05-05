using Microsoft.AspNetCore.Mvc;
using SwaggerWebAPIApp.Data;
using SwaggerWebAPIApp.Interface;
using SwaggerWebAPIApp.Models;

namespace SwaggerWebAPIApp.Repository
{
    public class FeatureList : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public FeatureList(ApplicationDbContext dbContext)
        {

           
            _context = dbContext;
        }

        public IViewComponentResult Invoke()
        {

            FeatureManager feature = new FeatureManager(new EfFeatureDal(_context));
            return View();
        }
    }
}
