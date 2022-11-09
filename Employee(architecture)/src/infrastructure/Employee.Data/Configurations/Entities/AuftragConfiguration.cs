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
    internal class AuftragConfiguration : IEntityTypeConfiguration<Auftrag>
    {

        public void Configure(EntityTypeBuilder<Auftrag> builder)
        {
            builder.HasData(
                new Auftrag
                {
                    Id = 1,
                    JobNr = "some Number",
                    AuftragNr ="some number",
                    StartDate =new DateTime(2020,1,1),
                    EndDate =new DateTime(2023,1,1),
                    //Project=new  Project
                    //{
                    //    Id = 1,
                    //    Name = "EmployeeAPI",
                    //    IsGKK = false,
                    //    IsActiv = true
                    //},
                    //Client = new Client { Id = 1, Name = "BMW" },

                });
        }
    }
}
