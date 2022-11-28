using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services.AuftragService
{
    public class AuftragService : IGenericService<Auftrag, AuftragDTO>
    {
        private CompanyContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AuftragService> _logger;
        public AuftragService(CompanyContext context,
            IMapper mapper,
            ILogger<AuftragService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public ServiceResponse<List<AuftragDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<AuftragDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Create(AuftragDTO item)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Update(int itemId, AuftragDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
