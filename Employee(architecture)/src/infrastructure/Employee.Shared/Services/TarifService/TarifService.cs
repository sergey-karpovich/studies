using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services.TarifService
{
    public class TarifService : IGenericService<Tarif, TarifDTO>
    {
        private CompanyContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<TarifService> _logger;
        public TarifService(CompanyContext context,
            IMapper mapper,
            ILogger<TarifService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public ServiceResponse<List<TarifDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<TarifDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Create(TarifDTO item)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Update(int itemId, TarifDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
