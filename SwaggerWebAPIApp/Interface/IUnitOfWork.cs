using SwaggerWebAPIApp.Repository;

namespace SwaggerWebAPIApp.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ProductRepository Products { get; }
        IserverNamesService ServerNamesService { get; }
        Task CompleteAsync();
    }
}
