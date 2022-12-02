using DotNet6MVCWebApp.Interface;
using DotNet6MVCWebApp.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotNet6MVCWebApp.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace DotNet6MVCWebApp.Implements
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;



        public AuthenticationRepository(ApplicationDbContext dbContext, IMapper mapper, IConfiguration config)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _config = config;
        }

        public async Task<TokenViewModel> AuthenticateLogin(LoginViewModel loginInfo)
        {
            try
            {
                var isAuthenticate = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserEmail == loginInfo.Email && u.Password == loginInfo.Password);
                var tokenViewModel = new TokenViewModel();
                if (isAuthenticate != null)
                {
                    var getToken = GenerateJSONWebToken(loginInfo);
                    tokenViewModel = _mapper.Map<TokenViewModel>(isAuthenticate);
                    tokenViewModel.Token = getToken;

                }
                return tokenViewModel;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private string GenerateJSONWebToken(LoginViewModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, userInfo.Email),
                        new Claim(JwtRegisteredClaimNames.Email, userInfo.Password),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
               };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
