using SwaggerWebAPIApp.Data;
using SwaggerWebAPIApp.Interface;
using SwaggerWebAPIApp.Repository;

namespace SwaggerWebAPIApp.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public IUserRepository Users { get; private set; }
        public ProductRepository Products { get; private set; }
        public IserverNamesService ServerNamesService { get; private set; }

       

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(context, _logger);
            Products = new ProductRepository(context, _logger);
            ServerNamesService = new ServerNamesService(context);
        }
        
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
