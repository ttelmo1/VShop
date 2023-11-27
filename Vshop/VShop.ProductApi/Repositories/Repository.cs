using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace VShop.ProductApi;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public IQueryable<T> Get()
    {
        //duvida: como funciona o set?
        return _context.Set<T>().AsNoTracking();
    }

    public async Task<T?> GetById(Expression<Func<T, bool>> predicate)
    {
        //duvida: como funciona o Expression<Func<T, bool>> predicate?
        return await _context.Set<T>().SingleOrDefaultAsync(predicate);
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<T>().Update(entity);
    }
}
