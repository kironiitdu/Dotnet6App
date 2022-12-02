using AutoMapper;
using DotNet6MVCWebApp.Models;

namespace DotNet6MVCWebApp.AutoMapperProfile
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, UserViewModel>();
            CreateMap<Users, TokenViewModel>();
           
        }
    }
}
