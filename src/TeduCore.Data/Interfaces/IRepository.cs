using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TeduCore.Model.Interfaces;

namespace TeduCore.Data.Interfaces
{
    public interface IRepository<T, TKey> where T : class, IEntityBase<TKey>
    {
        T Add(T entity);

        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        void Commit();

        Task CommitAsync();

        int Count();

        Task<int> CountAsync();

        void Delete(T entity);

        void DeleteWhere(Expression<Func<T, bool>> predicate);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();

        T GetSingle(TKey id);

        T GetSingle(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetSingleAsync(TKey id);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        T Update(T entity);
    }
}