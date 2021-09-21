using Domain.Entities;
using System.Data.Entity;

namespace Domain.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(x => x.Birth).HasColumnType("datetime2");

            modelBuilder.Entity<Employee>().HasIndex(x => new { x.Number, x.IsStaffMember });
        }
    }
}
