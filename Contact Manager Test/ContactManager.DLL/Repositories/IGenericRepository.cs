using ContactManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DLL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T Create(T item);
        T FindById(int id);
        IEnumerable<T> Get();
        IEnumerable<T> GetOrdered(Expression<Func<T, object>> predicate, bool desc = false);
        IEnumerable<T> Get(Func<T, bool> predicate);
        IEnumerable<T> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
        void Remove(T item);
        void Remove(int item);
        void RemoveRange(IEnumerable<T> item);
        void Update(T item);
        void CreateRange(IEnumerable<T> persons);
    }
}
