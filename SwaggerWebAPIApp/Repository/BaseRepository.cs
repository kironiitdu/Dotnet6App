using Microsoft.EntityFrameworkCore;
using SwaggerWebAPIApp.Data;
using SwaggerWebAPIApp.Interface;
using System.Linq.Expressions;

namespace SwaggerWebAPIApp.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext _context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<TEntity>();
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            var result = dbSet.AddAsync(entity).Result.Entity;
            Save();
            return result;
        }





        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }


        public virtual async Task<bool> UpdateBasedOnCondition(Expression<Func<TEntity, bool>> where, Action<TEntity> select)
        {
            try
            {
                var ListOfRecord = await dbSet.Where(where).ToListAsync();
                if (null != ListOfRecord && ListOfRecord.Count > 0)
                {
                    ListOfRecord.ForEach(select);
                    //  Save();
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

        }

        public async Task<ICollection<TType>> Get<TType>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TType>> select) where TType : class
        {
            if (where == null)
            {
                return await dbSet.Select(select).ToListAsync();
            }
            return await dbSet.Where(where).Select(select).ToListAsync();
        }


        public async Task<int> Count(Expression<Func<TEntity, bool>> where)
        {
            return await dbSet.Where(where).CountAsync();
        }





        public async virtual Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> where)
        {

            //  var test = dbSet.Where(where).ToList();
            return await dbSet.Where(where).ToListAsync();

        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Where(where).ToList();

        }



        public async Task<bool> Any(Expression<Func<TEntity, bool>> where)
        {
            return await dbSet.AnyAsync(where);
        }

        public TEntity GetFirst(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.FirstOrDefault(where);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Single(where);
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }

}
