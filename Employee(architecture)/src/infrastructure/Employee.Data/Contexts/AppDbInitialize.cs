using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Contexts
{
    public class AppDbInitialize
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder
                .ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider
                    .GetService<CompanyContext>();

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new IdentityRole
                        {
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new IdentityRole
                        {
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                    context.SaveChanges();
                }

                if (!context.Project.Any())
                {
                    context.Project.AddRange(
                        new Project
                        {                            
                            Name = "First Project",
                            IsGKK = false,
                            IsActiv = true,
                            StartDate = new DateTime(2022,1,1)
                        },
                        new Project
                        {
                           
                            Name = "Second Project",
                            IsGKK = true,
                            IsActiv = true,
                            StartDate = new DateTime(2022, 2, 1)
                        });

                    context.SaveChanges();
                }
                if (!context.Client.Any())
                {
                    context.Client.AddRange(
                    new Client()
                    {                        
                        Name = "BMW"
                    },
                    new Client()
                    {
                       
                        Name = "Client 2"
                    });
                    context.SaveChanges();
                }
                if (!context.Address.Any())
                {
                    context.Address.AddRange(
                    new Address()
                    {
                        CreatedOn = new DateTime(),
                        UpdatedOn = new DateTime(),
                        AddressLine1 = "Lenin street",
                        AddressLine2 = "h. 7",
                        City = "Beloozersk",
                        PostalCode = "225224",
                        Country = "Belarus"
                    }
                    );
                    context.SaveChanges();
                }
                if (!context.Tarif.Any())
                {
                    var clientId = context?.Client?.FirstOrDefault()?.ClientId;
                    if (clientId is null)
                        return;
                    context.Tarif.AddRange(
                    new Tarif
                    {
                        Amount = 40,
                        TarifType = "Development for bmw",
                        DisplayedName = "Development",
                        ClientId = clientId,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,

                    },new Tarif
                    {
                        Amount = 42,
                        TarifType = "Project Management for bmw",
                        DisplayedName = "Project Management",
                        ClientId = clientId,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,

                    },new Tarif
                    {
                        Amount = 30,
                        TarifType = "Requirements Management for bmw",
                        DisplayedName = "Requirements Management",
                        ClientId = clientId,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,

                    }
                    );
                    context.SaveChanges();
                }
                if(!context.Developer.Any())
                {
                    context.Developer.AddRange(
                    
                        new Developer()
                        {
                            FirstName = "Sergey",
                            LastName = "Karpovich",
                            Description = "description",
                            Areas = "frontend,backend",
                            Salary = 500,
                            HomePhone = "234234",
                            PhotoPath = "Anonymous.png",
                            BirthDate = new DateTime(1992, 12, 13),
                            HireDate= new DateTime(2020, 1, 1),
                            
                        },
                        new Developer()
                        {
                            FirstName = "Max",
                            LastName = "Shmedtman",
                            Description = "description",
                            Areas = "frontend,backend",
                            Salary = 1500,
                            HomePhone = "2111111",
                            PhotoPath = "Anonymous.png",
                            BirthDate = new DateTime(1990, 2, 1),
                            HireDate = new DateTime(2020, 1, 1),

                        }
                    );
                    context.SaveChanges();
                }
               
                if(!context.Auftrag.Any())
                {
                    var projectId = context?.Project?.FirstOrDefault()?.ProjectId;
                    var clientId = context?.Client?.FirstOrDefault()?.ClientId;
                    if (clientId is null)
                        return;
                    context.Auftrag.AddRange(
                        new Auftrag()
                        {
                            JobNr = "1111",
                            AuftragNr = "43242",
                            StartDate = new DateTime(2020, 1, 1),
                            EndDate = new DateTime(2020, 3, 1),
                            ProjectId = projectId,
                            ClientId = clientId
                        },
                        new Auftrag()
                        {
                            JobNr = "1112",
                            AuftragNr = "43212",
                            StartDate = new DateTime(2020, 1, 1),
                            EndDate = new DateTime(2020, 3, 1),
                            ProjectId = ++projectId,
                            ClientId = ++clientId
                        }
                        );
                    context.SaveChanges();                
                }
            }
        }
    }
}
