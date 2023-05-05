using Microsoft.EntityFrameworkCore;
using SwaggerWebAPIApp.Data;
using SwaggerWebAPIApp.Interface;
using SwaggerWebAPIApp.Models;
using System.Linq;

namespace SwaggerWebAPIApp.Repository
{
    public class ServerNamesService : BaseRepository<ServerNames>, IserverNamesService
    {
        public ServerNamesService(ApplicationDbContext context) : base(context)
        {
        }


        public override ServerNames GetByID(object id)
        {
            return _context.ServerNames.Where(sn => sn.ServerID == (int)id).FirstOrDefault();

        }
    }
}
