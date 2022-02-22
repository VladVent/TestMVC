using ContactManager.DAL.Context;
using ContactManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;



namespace ContactManager.DLL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        ApplicationContext _context;
        DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> GetOrdered(Expression<Func<TEntity, object>> predicate, bool desc = false)
        {
            var ordered = desc ? _dbSet.OrderByDescending(predicate) : _dbSet.OrderBy(predicate);
            return ordered.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.AsNoTracking().Where(predicate).ToList();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public TEntity Create(TEntity item)
        {
            var entity = _dbSet.Add(item).Entity;
            _context.SaveChanges();
            return entity;
        }
        public void Update(TEntity item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> item)
        {
            _dbSet.RemoveRange(item);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var item = _dbSet.Find(id);
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public void CreateRange(IEnumerable<TEntity> persons)
        {
            _dbSet.AddRange(persons);
            _context.SaveChanges();
        }
    }
}
