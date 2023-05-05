using DotNet6MVCWebApp.Interface;

namespace DotNet6MVCWebApp.Implements
{
    public class ProductLocator : IProductLocator
    {
        public Task<string> FindProduct(string product, out string controller)
        {
            throw new NotImplementedException();
        }
    }
}
