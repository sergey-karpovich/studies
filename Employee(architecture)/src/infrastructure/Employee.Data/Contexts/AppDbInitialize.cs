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
                }
                //if (!context.Tarifs.Any())
                //{
                //    context.Tarifs.AddRange(
                //   new Tarif
                //   {
                      
                //       Amount = 40,
                //       StartDate = new DateTime(2022, 1, 1),
                //       TarifId = 1
                //   },
                //   new Tarif
                //   {
                      
                //       Amount = 45,
                //       StartDate = new DateTime(2022, 1, 1),
                //       TarifId = 2
                //   },
                //    new Tarif
                //    {
                        
                //        Amount = 50,
                //        StartDate = new DateTime(2022, 1, 1),
                //        TarifId = 3
                //    });
                //}
                context.SaveChanges();
            }
        }
    }
}
