using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Services;

namespace EmployeeAPI.Projects.ProjectService
{
    public interface IProjectRepository
    {
        Project Create(ProjectDTO item);
        ServiceResponse<bool> Delete(int projectId);
        ServiceResponse<List<ProjectDTO>> GetAll();
        ServiceResponse<ProjectDTO> GetById(int id);
        ServiceResponse<bool> Update(ProjectDTO projectDTO);
    }
}