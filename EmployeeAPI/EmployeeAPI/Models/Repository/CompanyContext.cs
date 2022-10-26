using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Models.Repository
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options)
           : base(options) { }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Project>? Projects { get; set; }
        public DbSet<WorkTime>? WorkTimes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Projects)
                .WithMany(e=>e.Employees)
                .UsingEntity<ProjectEmployeeJunction>
                (pe => pe.HasOne<Project>().WithMany(),
                pe=>pe.HasOne<Employee>().WithMany())
                .Property(pe=>pe.DateJoined)
                .HasDefaultValueSql("getdate()");
            
        }
        // старый способ
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<ProjectEmployeeJunction>()
        //         .HasKey(t => new { t.ProjectId, t.EmployeeId });
        //     modelBuilder.Entity<ProjectEmployeeJunction>()
        //         .HasOne(pe => pe.Employee)
        //         .WithMany(e => e.ProjectsEmployees)
        //         .HasForeignKey(pe => pe.EmployeeId);

        //     modelBuilder.Entity<ProjectEmployeeJunction>()
        //         .HasOne(pe => pe.Project)
        //         .WithMany(e => e.ProjectsEmployees)
        //         .HasForeignKey(pe => pe.ProjectId);
        // }
    }
}
