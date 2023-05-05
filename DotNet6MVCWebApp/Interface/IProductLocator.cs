namespace DotNet6MVCWebApp.Interface
{
    public interface IProductLocator
    {
        Task<string> FindProduct(string product, out string controller);
    }
}
