using Microsoft.EntityFrameworkCore;
using SwaggerWebAPIApp.Data;
using SwaggerWebAPIApp.Interface;
using System.Linq.Expressions;

namespace SwaggerWebAPIApp.Repository
{
    public class GenericRepositoryTwo<T> : IGenericRepositoryTwo<T> where T : class
    {
        protected  ApplicationDbContext context;
        internal DbSet<T> dbSet;

        public GenericRepositoryTwo(
           ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public Task<bool> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
