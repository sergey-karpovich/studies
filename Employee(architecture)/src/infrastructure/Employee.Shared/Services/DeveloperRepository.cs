using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public  class DeveloperRepository
    {
        private CompanyContext _context;
        public DeveloperRepository(CompanyContext context)
        {
            _context = context;
        }
        public Developer AddDeveloper(DeveloperDTO developerDTO)
        {
            var developer = new Developer
            {
                FirstName = developerDTO.FirstName,
                LastName = developerDTO.LastName,
                Description=developerDTO.Description,
                Areas=developerDTO.Areas,
                Salary=developerDTO.Salary,
                HomePhone=developerDTO.HomePhone,
                PhotoPath=developerDTO.PhotoPath,
                BirthDate=developerDTO.BirthDate,
                HireDate=developerDTO.HireDate,
                EndDate=developerDTO.EndDate,
            };
            _context.Developers.Add(developer);
            _context.SaveChanges();

            developer.Tarif=_context.Tarifs.FirstOrDefault(t=>
            t.Id==developerDTO.TarifId);
            foreach(var da in developerDTO.DeveloperAuftragDTO)
            {
                var _developer_augtrag = new DeveloperAuftrag()
                {
                    DeveloperId = developer.Id,
                    AuftragId = da.AuftragId,
                    TarifId = da.TarifId,
                    StartDate=da.StartDate,
                    EndDate=da.EndDate,                    
                };
                _context.DevelopersAuftrags.Add(_developer_augtrag);
                _context.SaveChanges();
            }
            return developer;
        }
        public List<Developer> GetAllDevelopers() => _context.Developers.ToList();
    }
}
