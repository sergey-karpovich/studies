using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Projects.ProjectService
{
    public class ProjectRepository : IProjectRepository
    {
        private CompanyContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectRepository> _logger;
        public ProjectRepository(CompanyContext context,
            IMapper mapper,
            ILogger<ProjectRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public ServiceResponse<List<ProjectDTO>> GetAll()
        {
            var now = DateTime.UtcNow;
            var projects = _context.Project.ToList();
            var projectDTOs = _mapper.Map<List<ProjectDTO>>(projects);
            return new ServiceResponse<List<ProjectDTO>>
            {
                Time = now,
                IsSuccess = true,
                Message = "Getting all Project",
                Data = projectDTOs
            };
        }

        public ServiceResponse<ProjectDTO> GetById(int id)
        {
            var now = DateTime.UtcNow;
            var model = _context.Project.FirstOrDefault(cl => cl.ClientId == id);

            var DTO = _mapper.Map<ProjectDTO>(model);
            return new ServiceResponse<ProjectDTO>
            {
                Time = now,
                IsSuccess = model != null,
                Message = "Getting project by id",
                Data = DTO
            };
        }

        public Project Create(ProjectDTO item)
        {
            var model = _mapper.Map<Project>(item);
            _context.Project.Add(model);
            _context.SaveChanges();

            return model;
        }

        public ServiceResponse<bool> Delete(int projectId)
        {
            var project = _context.Project.FirstOrDefault(c => c.ProjectId == projectId);
            var now = DateTime.UtcNow;
            if (project == null)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Client to delete not found",
                    Data = false
                };
            }
            _context.Project.Remove(project);
            var response = _context.SaveChanges();
            return new ServiceResponse<bool>
            {
                Time = now,
                IsSuccess = response > 0,
                Message = response > 0 ? "Project deleted" : "Deletioin failed",
                Data = response > 0
            };
        }

        public ServiceResponse<bool> Update(ProjectDTO projectDTO)
        {
            var now = DateTime.UtcNow;
            var model = _mapper.Map<Project>(projectDTO);
            _context.Attach(model);
            _context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var response = _context.SaveChanges();

            return new ServiceResponse<bool>
            {
                Time = now,
                IsSuccess = response > 0,
                Message = response > 0 ? "Success" : "Fail",
                Data = response > 0
            };
        }
    }
}
