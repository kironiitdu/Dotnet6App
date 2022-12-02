using DotNet6MVCWebApp.Models;

namespace DotNet6MVCWebApp.Interface
{
    public interface IAuthenticationRepository
    {
        Task<TokenViewModel> AuthenticateLogin(LoginViewModel loginInfo);
    }
}
