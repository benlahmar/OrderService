using Order.Domain.Iterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repositories
{
    public class BaseRepository<T>:IBaseRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Query => _context.Set<T>();

        public T add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public IEnumerable<T> findAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public T findById(int id)
        {
            T? t = _context.Set<T>().Find(id);
            return t;
        }

        public Task<T> findByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Save(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
