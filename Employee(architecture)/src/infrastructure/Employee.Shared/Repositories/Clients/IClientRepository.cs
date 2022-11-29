using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Services;

namespace EmployeeAPI.Repositories.Clients
{
    public interface IClientRepository
    {
        Client Create(ClientDTO clientDTO);
        ServiceResponse<bool> Delete(int clientId);
        ServiceResponse<List<ClientDTO>> GetAll();
        ServiceResponse<ClientDTO> GetById(int id);
        ServiceResponse<bool> Update(ClientDTO clientDTO);
    }
}