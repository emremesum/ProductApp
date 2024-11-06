using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.DataAccess;

public interface IGenericRepository<T> where T : class

{
    IQueryable<T> GetAll();
    ValueTask<T?> GetByIdAsync(int id);
    IQueryable<T> where(Expression<Func<T, bool>> predicate);
    ValueTask AddAsync(T entity);
    void Delete(T entity);
    void Update(T entity);
}

