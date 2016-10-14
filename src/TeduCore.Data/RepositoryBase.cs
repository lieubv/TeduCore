using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TeduCore.Data.Interfaces;
using TeduCore.Model.Interfaces;

namespace TeduCore.Data
{
    public class RepositoryBase<T, TKey> : IRepository<T, TKey>
        where T : class, IEntityBase<TKey>
    {
        private TeduCoreDbContext _context;

        #region Properties
        public RepositoryBase(TeduCoreDbContext context)
        {
            _context = context;
        }
        #endregion

        public virtual T Add(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            _context.Set<T>().Add(entity);
            return entity;
        }

        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public virtual void Commit()
        {
            _context.SaveChanges();
        }

        public Task CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public virtual int Count()
        {
            return _context.Set<T>().Count();
        }

        public Task<int> CountAsync()
        {
            return _context.Set<T>().CountAsync();
        }

        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);

            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }
        public T GetSingle(TKey id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.ID.Equals(id));
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }
        public Task<T> GetSingleAsync(TKey id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(x => x.ID.Equals(id));
        }

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual T Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
            return entity;
        }
    }
}
