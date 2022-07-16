using Dotnet6App.Interface;
using Dotnet6App.Models;

namespace Dotnet6App.Repository
{
    public class SearchGirlFriend : ISearchGirlFriend
    {
        public List<GirlFriend> GetGirlFriend( string boysStatus)
        {
            var listOfGirlFriend = new List<GirlFriend>();

            if (string.IsNullOrEmpty(boysStatus) || boysStatus == null)
            {
                return listOfGirlFriend;
            }
            else
            {
                return null;
            }

        }
    }
}
