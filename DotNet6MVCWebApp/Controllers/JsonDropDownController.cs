using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using DotNet6MVCWebApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNet6MVCWebApp.Controllers
{
    public class JsonDropDownController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
      
        public JsonDropDownController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
          
        }

        public IActionResult LoadDropDown()
        {
            return View();
        }

       

       
        public IActionResult Index()
        {
            try
            {
                var clientList = (from client in _context.Categories
                                  select new SelectListItem()
                                  {
                                      Text = client.CategoryName,
                                      Value = client.CategoryId.ToString(),
                                  }).ToList();

                clientList.Insert(0, new SelectListItem()
                {
                    Text = "----Select----",
                    Value = string.Empty
                });

                return Json(clientList);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
