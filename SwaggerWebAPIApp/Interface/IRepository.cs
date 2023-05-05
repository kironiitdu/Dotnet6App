using System.Linq.Expressions;

namespace SwaggerWebAPIApp.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {

        Task<int> Count(Expression<Func<TEntity, bool>> where);
        TEntity GetByID(object id);
        TEntity Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        Task<ICollection<TType>> Get<TType>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TType>> select) where TType : class;
        Task<bool> Any(Expression<Func<TEntity, bool>> where);
        TEntity GetFirst(Expression<Func<TEntity, bool>> where);
        TEntity Single(Expression<Func<TEntity, bool>> where);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> where);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> where);
        Task<bool> UpdateBasedOnCondition(Expression<Func<TEntity, bool>> where, Action<TEntity> select);
        void Save();

    }
}
