using System;
using System.Linq;
using System.Linq.Expressions;

namespace LSB.Data
{
    public interface IRepository<T> : IDisposable
    {

        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();

    }
}
