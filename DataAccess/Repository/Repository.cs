using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repository {
    public class Repository<T> : BaseRepository<T>, IRepository<T> where T : class {
        public Repository(DbContext context) : base(context) { }

        public new ICollection<T> GetList(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool disableTracking = false) {
            return base.GetList(predicate, orderBy, disableTracking).ToList();
        }

        public new ICollection<TResult> GetList<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null,
            bool disableTracking = false) where TResult : class {
            return base.GetList(selector, predicate, orderBy, disableTracking).ToList();
        }
    }
}