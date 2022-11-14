using System.Linq.Expressions;

namespace Classroom.Mvc.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> RemoveAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    IQueryable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
    TEntity? GetById(Guid id);
}