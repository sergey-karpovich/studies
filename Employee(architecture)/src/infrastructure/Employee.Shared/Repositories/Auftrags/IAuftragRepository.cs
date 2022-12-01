using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Services;

namespace EmployeeAPI.Repositories.Auftrags
{
    public interface IAuftragRepository
    {
        Auftrag Create(AuftragDTO DTO);
        ServiceResponse<bool> Delete(int auftragId);
        ServiceResponse<List<AuftragDTO>> GetAll();
        ServiceResponse<AuftragDTO> GetById(int id);
        ServiceResponse<bool> Update(AuftragDTO DTO);
    }
}