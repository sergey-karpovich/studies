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

        // not working
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
             
        //    modelBuilder.Entity<Employee>().HasData(
        //        new Employee[]
        //        {
        //        new Employee { EmployeeId=1, LastName="Tom", Title="test data title"},
        //        new Employee { EmployeeId=2, LastName="Alice", Title="test data title"},
        //        new Employee { EmployeeId=3, LastName="Sam", Title="test data title"},                
        //        });
        //}
    }
}
