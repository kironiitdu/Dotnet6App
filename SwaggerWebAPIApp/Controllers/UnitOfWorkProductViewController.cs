using Microsoft.AspNetCore.Mvc;
using SwaggerWebAPIApp.Interface;

namespace SwaggerWebAPIApp.Controllers
{
    public class UnitOfWorkProductViewController : Controller
    {
        private readonly ILogger<UnitOfWorkProductViewController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkProductViewController(
            ILogger<UnitOfWorkProductViewController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _unitOfWork.Products.All();
            return View(products);
        }
    }
}
