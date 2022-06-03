using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Company.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options){}
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Project>? Projects{get;set;}
        public DbSet<WorkTime>? WorkTimes{get;set;}
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkTime>()
                .Property(e=>e.money).HasColumnType("decimal(8,2")
                .HasField("salary")
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
        
    }
}
