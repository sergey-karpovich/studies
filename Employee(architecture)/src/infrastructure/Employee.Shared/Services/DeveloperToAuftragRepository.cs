using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public class DeveloperToAuftragRepository
    {
        private CompanyContext _context;
        private readonly IMapper _mapper;
        public DeveloperToAuftragRepository(CompanyContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DeveloperWithAuftragDTO> GetAllDevelopersWithAuftrags()
        {
            var list = new List<DeveloperWithAuftragDTO>();
            var developerToAuftrag = _context.DevelopersAuftrags.ToList();
            foreach(var junction in developerToAuftrag)
            {
                var developer = _context.Developers.FirstOrDefault(d => d.Id == junction.DeveloperId);
                var auftrag = _context.Auftrags.FirstOrDefault(a => a.Id == junction.AuftragId);
                var tarif= _context.Tarifs.FirstOrDefault(t=>t.Id == junction.TarifId);
                var dto = new DeveloperWithAuftragDTO()
                {
                    DeveloperDTO = _mapper.Map<DeveloperDTO>(developer),
                    AuftragDTO = _mapper.Map<AuftragDTO>(auftrag),
                    TarifDTO = _mapper.Map<TarifDTO>(tarif),
                    StartDate = junction.StartDate,
                    EndDate = junction.EndDate
                };
                list.Add(dto);
            }
            return list;
        }

    }
}
