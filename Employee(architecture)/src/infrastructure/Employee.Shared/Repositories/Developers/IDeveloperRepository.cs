using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Services;

namespace EmployeeAPI.Repositories.Developers
{
    public interface IDeveloperRepository
    {
        Developer Create(DeveloperDTO item);
        ServiceResponse<bool> Delete(int itemId);
        ServiceResponse<List<DeveloperDTO>> GetAllDevelopers();
        ServiceResponse<DeveloperDTO> GetById(int id);
        ServiceResponse<bool> Update(DeveloperDTO item);
    }
}