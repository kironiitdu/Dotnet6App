using DotNet6MVCWebApp.Models;

namespace DotNet6MVCWebApp.Service
{
    public interface IService
    {
        public  Task<bool> AddSolution(HataCozum psolution);
        public  Task<UserModel> CreateAsync(UserModel user, string password);
    }
}
