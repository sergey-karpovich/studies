using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Data.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data.Contexts
{
    public class CompanyContext : IdentityDbContext<ApiUser>
    {
        public CompanyContext(DbContextOptions<CompanyContext> options)
           : base(options) { }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Project>? Projects { get; set; }
        public DbSet<WorkTime>? WorkTimes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Projects)
                .WithMany(e => e.Employees)
                .UsingEntity<ProjectEmployeeJunction>
                (pe => pe.HasOne<Project>().WithMany(),
                pe => pe.HasOne<Employee>().WithMany())
                .Property(pe => pe.DateJoined)
                .HasDefaultValueSql("getdate()");

        }
    }
}
