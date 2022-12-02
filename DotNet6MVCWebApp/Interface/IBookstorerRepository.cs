using DotNet6MVCWebApp.Models;

namespace DotNet6MVCWebApp.Interface
{
    public interface IBookstorerRepository
    {
        public  IList<Book> List();
    }
}
