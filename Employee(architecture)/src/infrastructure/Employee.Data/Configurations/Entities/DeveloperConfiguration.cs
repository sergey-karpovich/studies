using EmployeeAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Data.Configurations.Entities
{
    internal class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
    {

        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.HasData(
                new Developer
                {
                    Id = 1,
                    FirstName = "Sergey",
                    LastName = "Karpovich",
                    Salary = 500,
                    Description = "description",
                    Areas="frontend,backend",
                    HomePhone="1111111",
                    PhotoPath="Anonymous.png",
                    BirthDate =new DateTime(1992,12,13),
                    HireDate =new DateTime(2022,1,1),

                    Tarif = new Tarif
                    {
                        Id = 1,
                        Amount = 14,
                        
                        TarifType=new TarifType
                        {
                            Id=1,
                            Type="Development"
                        }
                    }
                },
                new Developer
                {
                    Id = 2,
                    FirstName = "Max",
                    LastName = "Shmedtman",
                    Salary = 500,
                    Description = "description",
                    Areas = "frontend,backend",
                    HomePhone = "222222",
                    PhotoPath = "Anonymous.png",
                    BirthDate = new DateTime(1980,1,1),
                    HireDate = new DateTime(2022,1,1),
                    Tarif = new Tarif
                    {
                        Id = 2,
                        Amount = 40,

                        
                        TarifType = new TarifType
                        {
                            Id = 2,
                            Type = "Project Management"
                        }
                    }
                });
        }
    }
}
