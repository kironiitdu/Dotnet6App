using SwaggerWebAPIApp.Repository;
using Microsoft.EntityFrameworkCore;
using SwaggerWebAPIApp.Data;
using SwaggerWebAPIApp.Interface;
using SwaggerWebAPIApp.Models;

namespace SwaggerWebAPIApp.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductReposiotry
    {
        public ProductRepository(ApplicationDbContext context, ILogger logger) : base(context, logger) { }
        public override async Task<IEnumerable<Product>> All()
        {
            try
            {
                var products = context.Products.ToList();
                return products;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(ProductRepository));
                return new List<Product>();
            }
        }
    }
}
