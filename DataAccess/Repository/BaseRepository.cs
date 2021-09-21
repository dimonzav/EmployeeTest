using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public abstract class BaseRepository<T> : IWriteRepository<T> where T : class {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        protected BaseRepository(DbContext context) {
            _dbContext = context ?? throw new ArgumentException(nameof(context));
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity) {
            _dbSet.Add(entity);
        }

        public void Add(params T[] entities) {
            _dbSet.AddRange(entities);
        }

        public void Add(IEnumerable<T> entities) {
            _dbSet.AddRange(entities);
        }

        public void Delete(object id) {
            T entity = _dbSet.Find(id);
            if (entity != null) {
                _dbSet.Remove(entity);
            }
        }

        public void Delete(params T[] entities) {
            _dbSet.RemoveRange(entities);
        }

        public void Delete(IEnumerable<T> entities) {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity) {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Update(params T[] entities) {
            foreach (T item in entities)
            {
                Update(item);
            }
        }

        public void Update(IEnumerable<T> entities) {
            foreach (T item in entities)
            {
                Update(item);
            }
        }

        protected virtual IQueryable<T> Query(string sql, params object[] parameters) {
            return _dbSet.SqlQuery(sql, parameters).AsQueryable();
        }

        public T Search(params object[] keyValues) {
            return _dbSet.Find(keyValues);
        }

        public T Single(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool disableTracking = false) {
            IQueryable<T> query = _dbSet;
            if (disableTracking) {
                query = query.AsNoTracking();
            }
            if (predicate != null) {
                query = query.Where(predicate);
            }
            if (orderBy != null) {
                return orderBy(query).FirstOrDefault();
            }
            return query.FirstOrDefault();
        }

        protected IQueryable<T> GetList(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool disableTracking = false) {
            IQueryable<T> query = _dbSet;
            if (disableTracking) {
                query = query.AsNoTracking();
            }
            if (predicate != null) {
                query = query.Where(predicate);
            }
            return orderBy != null ? orderBy(query) : query;
        }

        protected IQueryable<TResult> GetList<TResult>(Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool disableTracking = false) where TResult : class {
            IQueryable<T> query = _dbSet;
            if (disableTracking) {
                query = query.AsNoTracking();
            }
            if (predicate != null) {
                query = query.Where(predicate);
            }
            return orderBy != null
                ? orderBy(query).Select(selector)
                : query.Select(selector);
        }
    }
}