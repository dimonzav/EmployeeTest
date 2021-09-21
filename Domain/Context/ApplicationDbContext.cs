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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(x => x.Birth).HasColumnType("datetime2");
        }
    }
}
