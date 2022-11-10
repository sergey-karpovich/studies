using AutoMapper;
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
        private readonly IMapper _mapper;
        public DeveloperRepository(CompanyContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Developer AddDeveloper(DeveloperDTO developerDTO)
        {
            var developer = _mapper.Map<Developer>(developerDTO);
            //    new Developer
            //{
            //    FirstName = developerDTO.FirstName,
            //    LastName = developerDTO.LastName,
            //    Description=developerDTO.Description,
            //    Areas=developerDTO.Areas,
            //    Salary=developerDTO.Salary,
            //    HomePhone=developerDTO.HomePhone,
            //    PhotoPath=developerDTO.PhotoPath,
            //    BirthDate=developerDTO.BirthDate,
            //    HireDate=developerDTO.HireDate,
            //    EndDate=developerDTO.EndDate,
            //};
            _context.Developers.Add(developer);
            _context.SaveChanges();
           
            return developer;
        }
        public List<Developer> GetAllDevelopers() => _context.Developers.ToList();

        public TheDeveloperWithAuftragsDTO GetDeveloperById(int id)
        {
            var developer = _context.Developers.Where(t => t.Id == id)
                .Select(d => new TheDeveloperWithAuftragsDTO()
                {
                    DeveloperId = d.Id,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Auftrags =d.DeveloperAuftrags.Select(da=>da.Auftrag).ToList(),
                }).FirstOrDefault();
            return developer;

            
        }

        // Не работают!!!
        public DeveloperAuftragTarifDTO GetDevAuftrByAuftrag(int auftragId)
        {
            var developerAuftragTarifDTO = _context.Auftrags.Where(a => a.Id == auftragId)
                .Select(auftrag =>
                new DeveloperAuftragTarifDTO()
                {
                    StartDate = (DateTime)auftrag.StartDate,
                    EndDate =(DateTime)auftrag.EndDate,
                    AuftragId = auftrag.Id,
                    DevelopersDTO = auftrag.DeveloperAuftrags
                    .Select(da => _mapper.Map<DeveloperDTO>(da.Developer)).ToList()
                }).FirstOrDefault();
            
            return developerAuftragTarifDTO;
        }
        public  List<DeveloperAuftragTarifDTO> GetDevAuftrByMonth(DateTime firstDayMonth)
        {
            var month = (int)firstDayMonth.Month;
            var lastDayMonth = new DateTime(firstDayMonth.Year, month + 1, 1);
            var auftrags = (from auftrag in _context.Auftrags
                            where (auftrag.StartDate < firstDayMonth &&
                            ((auftrag.EndDate??lastDayMonth) <= lastDayMonth))
                            select auftrag
                            ).ToList();
            var developerAuftragTarifDTO = new List<DeveloperAuftragTarifDTO>();
            foreach(var auftrag in auftrags)
            {
                var devAuftrTarDTO = new DeveloperAuftragTarifDTO()
                {
                    DevelopersDTO = _mapper.Map<List<DeveloperDTO>>(
                        auftrag.DeveloperAuftrags.Select(da =>new DeveloperDTO()
                        {
                            FirstName = da.Developer.FirstName,
                            LastName = da.Developer.LastName,
                            TarifId = da.TarifId
                        }).ToList()
                        ),
                    StartDate=firstDayMonth,
                    EndDate=lastDayMonth,
                    AuftragId=auftrag.Id
                };
                developerAuftragTarifDTO.Add(devAuftrTarDTO);
            }
            return developerAuftragTarifDTO;
            
        }
    }
}
