using Microsoft.EntityFrameworkCore;
using SwaggerWebAPIApp.Data;
using SwaggerWebAPIApp.Interface;
using SwaggerWebAPIApp.Models;

namespace SwaggerWebAPIApp.Repository
{
   
    public class EfFeatureDal: GenericRepositoryTwo<EfFeature>, IEfFeatureDal
    {

        public EfFeatureDal(ApplicationDbContext context) : base(context) { }

        
    }
}
