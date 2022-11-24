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

namespace EmployeeAPI.Services.ProjectService
{
    public class ProjectService : IGenericService<Project,ProjectDTO>
    {
        private CompanyContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectService> _logger;
        public ProjectService(CompanyContext context,
            IMapper mapper,
            ILogger<ProjectService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public ServiceResponse<List<ProjectDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<ProjectDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Create(ProjectDTO item)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Update(int itemId, ProjectDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
