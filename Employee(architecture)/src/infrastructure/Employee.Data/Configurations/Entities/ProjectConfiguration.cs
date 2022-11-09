using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeAPI.Data.Configurations.Entities
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {

        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData(                
                new Project
                {
                    Id = 1,
                    Name = "Project 1",
                    IsGKK = false,
                    IsActiv = true
                },
                new Project
                {
                    Id = 2,
                    Name = "SecondProject",
                    IsGKK = false,
                    IsActiv = true
                });
            
        }
    }
}
