using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Domain.Entities;

namespace EmployeeAPI.Services.TarifService
{
    public interface ITarifRepository
    {
        Tarif Create(TarifDTO tarifDTO);
        ServiceResponse<bool> Delete(int tarifId);
        ServiceResponse<List<TarifDTO>> GetAll();
        ServiceResponse<TarifDTO> GetById(int id);
        ServiceResponse<bool> Update(TarifDTO tarifDTO);
    }
}