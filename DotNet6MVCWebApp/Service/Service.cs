using Dotnet6App.Data;
using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using ApplicationDbContext = DotNet6MVCWebApp.Data.ApplicationDbContext;

namespace DotNet6MVCWebApp.Service
{
    public class Service : IService
    {
        private readonly ApplicationDbContext _context;

        public Service(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddSolution(HataCozum psolution)
        {
            try
            {
                _context.Add(psolution);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<UserModel> CreateAsync(UserModel user, string password)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user!;
        }
    }
}
