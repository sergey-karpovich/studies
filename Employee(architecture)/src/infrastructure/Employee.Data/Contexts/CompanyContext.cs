using EmployeeAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data.Contexts
{
    public class CompanyContext : IdentityDbContext<ApiUser>
    {
        public CompanyContext(DbContextOptions<CompanyContext> options)
           : base(options) { }
        public DbSet<Tarif> Tarif { get; set; }
        public DbSet<Developer> Developer { get; set; }
        public DbSet<DeveloperProject> DevelopersAuftrag { get; set; }
        public DbSet<Auftrag> Auftrag { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Rechnung> Rechnung { get; set; }
        public DbSet<RechnungPosition> RechnungPosition { get; set; }
        public DbSet<MonthTotalHours> MonthTotalHours { get; set; }
        public DbSet<Address> Address { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DeveloperProject>()
                .HasOne(d => d.Developer)
                .WithMany(da => da.DeveloperProject)
                .HasForeignKey(di => di.DeveloperId);
            modelBuilder.Entity<DeveloperProject>()
                .HasOne(d => d.Project)
                .WithMany(da => da.DeveloperProject)
                .HasForeignKey(di => di.ProjectId);

            // Не работает
           // modelBuilder.ApplyConfiguration(new RoleConfiguration());


        }
    }
}
