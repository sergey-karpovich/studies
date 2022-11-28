using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Services;

namespace EmployeeAPI.Repositories.Addresses
{
    public interface IAddressRepository
    {
        Address Create(AddressDTO addressDTO);
        ServiceResponse<bool> Delete(int id);
        ServiceResponse<List<AddressDTO>> GetAllAddresses();
        ServiceResponse<AddressDTO> GetById(int id);
        ServiceResponse<bool> Update(AddressDTO addressDTO);
    }
}