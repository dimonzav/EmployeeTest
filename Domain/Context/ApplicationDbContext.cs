using Domain.Entities;
using System.Data.Entity;

namespace Domain.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Employee> Blogs { get; set; }
    }
}
