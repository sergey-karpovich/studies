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
                    DeveloperId = 1,
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
                        TarifId = 1,
                        Amount = 14,
                        
                        
                    }
                },
                new Developer
                {
                    DeveloperId = 2,
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
                        TarifId = 2,
                        Amount = 40,

                        
                         
                    }
                });
        }
    }
}
