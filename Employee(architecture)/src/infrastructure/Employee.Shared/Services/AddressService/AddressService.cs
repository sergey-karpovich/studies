using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services.AddressService
{
    public class AddressService : IGenericService<Address,AddressDTO>
    {
        private CompanyContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AddressService> _logger;
        public AddressService(CompanyContext context,
            IMapper mapper,
            ILogger<AddressService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public ServiceResponse<List<AddressDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<AddressDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Create(AddressDTO item)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Update(int itemId, AddressDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
