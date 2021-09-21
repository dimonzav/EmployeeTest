using System.Collections.Generic;

namespace DataAccess.Repository {
    public interface IWriteRepository<in T> where T : class {
        void Add(T entity);

        void Add(params T[] entities);

        void Add(IEnumerable<T> entities);

        void Delete(object id);

        void Delete(params T[] entities);

        void Delete(IEnumerable<T> entities);

        void Update(T entity);

        void Update(params T[] entities);

        void Update(IEnumerable<T> entities);
    }
}