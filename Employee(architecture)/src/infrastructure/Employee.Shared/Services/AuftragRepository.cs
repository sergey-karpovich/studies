using AutoMapper;
using EmployeeAPI.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public class AuftragRepository
    {
        private CompanyContext _context;
        private readonly IMapper _mapper;
        public AuftragRepository(CompanyContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


    }
}
