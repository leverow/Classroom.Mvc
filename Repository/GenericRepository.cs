using Classroom.Mvc.Data;
using System.Linq.Expressions;

namespace Classroom.Mvc.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var entry = await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        => _context.Set<TEntity>().Where(expression);

    public IQueryable<TEntity> GetAll()
        => _context.Set<TEntity>();

    public TEntity? GetById(Guid id)
        => _context.Set<TEntity>().Find(id);

    public async Task<TEntity> RemoveAsync(TEntity entity)
    {
        var entry = _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entry = _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }
}