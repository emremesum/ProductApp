using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ProductApp.DataAccess;

public class GenericRepository<T>(ProductAppDbContext context) : IGenericRepository<T> where T : class
{
    protected ProductAppDbContext Context = context;

    private readonly DbSet<T> _dbSet = context.Set<T>();

    public IQueryable<T> GetAll() => _dbSet.AsQueryable().AsNoTracking();
   
    public IQueryable<T> where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsNoTracking();
    
    public async ValueTask AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }
    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
    public ValueTask<T?> GetByIdAsync(int id)
    {
        return _dbSet.FindAsync(id);
    }   
}
