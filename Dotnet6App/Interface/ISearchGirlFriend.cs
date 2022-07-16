using Dotnet6App.Models;

namespace Dotnet6App.Interface
{
    public interface ISearchGirlFriend
    {
        List<GirlFriend> GetGirlFriend(string boysStatus);
    }
}
