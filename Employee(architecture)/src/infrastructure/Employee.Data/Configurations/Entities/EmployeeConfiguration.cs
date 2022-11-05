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
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Sergey",
                    LastName = "Karpovich"
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Max",
                    LastName = "Shmedtman"
                });
        }
    }
}
