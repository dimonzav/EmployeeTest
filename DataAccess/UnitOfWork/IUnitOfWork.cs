using DataAccess.Repository;
using System.Data.Entity;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IRepositoryFactory
    {
        int SaveChanges();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
