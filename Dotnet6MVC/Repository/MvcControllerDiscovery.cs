using Dotnet6MVC.IRepository;

namespace Dotnet6MVC.Repository
{
    public class MvcControllerDiscovery : IMvcControllerDiscovery
    {
        public string GetLocalDate()
        {
           var date = DateTime.Today;
            return date.ToString();
        }
    }
}
