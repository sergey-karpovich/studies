using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using Microsoft.AspNetCore.Builder;
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
                               
                
                if (!context.Projects.Any())
                {
                    context.Projects.AddRange(
                        new Project
                        {
                            
                            Name = "Project 1",
                            IsGKK = false,
                            IsActiv = true
                        },
                        new Project
                        {
                           
                            Name = "SecondProject",
                            IsGKK = false,
                            IsActiv = true
                        });

                    context.SaveChanges();
                }
                if (!context.Clients.Any())
                {
                    context.Clients.AddRange(
                    new Client()
                    {
                        
                        Name = "Client 1"
                    },
                    new Client()
                    {
                       
                        Name = "Client 2"
                    });
                    context.SaveChanges();
                }
                if (!context.TarifTypes.Any())
                {
                    context.TarifTypes.AddRange(
                    new TarifType
                    {
                       
                        Type = "Development"
                    },
                    new TarifType
                    {
                        
                        Type = "Project Manager"
                    },
                    new TarifType
                    {
                        
                        Type = "Requirements Management"
                    });
                    context.SaveChanges();
                }
                if (!context.Tarifs.Any())
                {
                    var tarifTypeId=context.TarifTypes.FirstOrDefault().Id;
                    context.Tarifs.AddRange(
                    new Tarif
                    {

                        Amount = 40,
                        StartDate = new DateTime(2022, 1, 1),
                        TarifTypeId = tarifTypeId
                    },
                    new Tarif
                    {

                        Amount = 45,
                        StartDate = new DateTime(2022, 1, 1),
                        TarifTypeId = ++tarifTypeId
                    },
                    new Tarif
                    {

                        Amount = 50,
                        StartDate = new DateTime(2022, 1, 1),
                        TarifTypeId = ++tarifTypeId
                    }) ;
                    context.SaveChanges();
                }
                if(!context.Developers.Any())
                {
                    context.Developers.AddRange(
                    
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
                if(!context.Auftrags.Any())
                {
                    context.Auftrags.AddRange(
                        new Auftrag()
                        {
                            JobNr ="2342",
                            AuftragNr = "43242",
                            StartDate = new DateTime(2020, 1, 1),
                            EndDate = new DateTime(2020, 3, 1)
                        },
                        new Auftrag()
                        {
                            JobNr = "2343",
                            AuftragNr = "43212",
                            StartDate = new DateTime(2020, 1, 1),                            
                        }
                        );
                    context.SaveChanges();                
                }
            }
        }
    }
}
