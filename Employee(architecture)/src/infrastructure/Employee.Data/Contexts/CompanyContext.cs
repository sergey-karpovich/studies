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
        public DbSet<Tarif> Tarifs { get; set; }
        public DbSet<TarifType> TarifTypes { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<DeveloperAuftrag> DevelopersAuftrags { get; set; }
        public DbSet<Auftrag> Auftrags { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Log> Logs { get; set; }
        //public DbSet<Rechnung> Rechnungs { get; set; }
        //public DbSet<RechnungPosition> RechnungPositions { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DeveloperAuftrag>()
                .HasOne(d => d.Developer)
                .WithMany(da => da.DeveloperAuftrags)
                .HasForeignKey(di => di.DeveloperId);
            modelBuilder.Entity<DeveloperAuftrag>()
                .HasOne(d => d.Auftrag)
                .WithMany(da => da.DeveloperAuftrags)
                .HasForeignKey(di => di.AuftragId);

            //modelBuilder.Entity<Auftrag>(entity =>
            //{
            //    entity.HasOne(a => a.Client)
            //    .WithMany(c => c.Auftrags)
            //    .HasForeignKey(c => c.ClientId)
            //    .HasConstraintName("FK_Auftrag_To_Client");

            //    entity.HasOne(a => a.Project)
            //    .WithMany(p => p.Auftrags)
            //    .HasForeignKey(a => a.ProjectId)
            //    .HasConstraintName("FK_Auftrag_To_Project");

            //});

            //modelBuilder.Entity<Developer>()
            //    .HasOne(d => d.Tarif)
            //    .WithMany(t => t.Developers)
            //    .HasForeignKey(d => d.TarifId);

            //modelBuilder.Entity<Tarif>()
            //    .HasOne(t => t.TarifType)
            //    .WithMany(tt => tt.Tarifs)
            //    .HasForeignKey(t => t.TarifId);


            //modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            //modelBuilder.ApplyConfiguration(new DeveloperConfiguration());
            //modelBuilder.ApplyConfiguration(new RoleConfiguration());
            //modelBuilder.ApplyConfiguration(new AuftragConfiguration());



        }
    }
}
