using AutoMapper;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services.HoursService
{
    public class HoursServise 
    {
        private CompanyContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<HoursServise> _logger;
        public HoursServise(CompanyContext context,
            IMapper mapper,
            ILogger<HoursServise> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public List<MonthTotalHours> GetAll()
        {
            throw new NotImplementedException();
        }

        public MonthTotalHours GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<MonthTotalHours> Create(MonthTotalHours item)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<MonthTotalHours> Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<MonthTotalHours> Update(int itemId, MonthTotalHours item)
        {
            throw new NotImplementedException();
        }
    }
}
