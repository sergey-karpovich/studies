using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Services;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Repositories.Addresses
{
    public class AddressRepository : IAddressRepository
    {
        private CompanyContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AddressRepository> _logger;
        public AddressRepository(CompanyContext context,
            IMapper mapper,
            ILogger<AddressRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public ServiceResponse<List<AddressDTO>> GetAllAddresses()
        {
            _logger.LogInformation("Getting all Addresses");
            var now = DateTime.UtcNow;
            List<Address> addresses = _context.Address.ToList();
            var allAddressesDTO = _mapper.Map<List<AddressDTO>>(addresses);
            if (allAddressesDTO is null)
            {
                _logger.LogError("AllAddressesDTO  is null");
                return new ServiceResponse<List<AddressDTO>>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Something went wrong in AddressRepository",
                    Data = null
                };
            }
            try
            {
                return new ServiceResponse<List<AddressDTO>>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Getting all Addresses",
                    Data = allAddressesDTO
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception {e.Message}, {e.StackTrace}");
                return new ServiceResponse<List<AddressDTO>>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Data = null
                };
            }
        }

        public ServiceResponse<AddressDTO> GetById(int id)
        {
            _logger.LogInformation($"Getting  Address by id = {id}");
            var now = DateTime.UtcNow;
            try
            {
                var address = _context.Address.Find(id);
                //var address = _context.Address.FirstOrDefault(a => a.AddressId == id);
                //if (address is null)
                //{
                //    return new ServiceResponse<AddressDTO>
                //    {
                //        Time = now,
                //        IsSuccess = false,
                //        Message = "Address not found",
                //        Data = null
                //    };

                //}

                var addressDTO = _mapper.Map<AddressDTO>(address);
                return new ServiceResponse<AddressDTO>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Address by id",
                    Data = addressDTO
                };

            }
            catch (Exception e)
            {
                _logger.LogError($"Exception {e.Message}, {e.StackTrace}");
                return new ServiceResponse<AddressDTO>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace ?? "Something wrong in repository",
                    Data = null
                };
            }
        }

        public Address Create(AddressDTO addressDTO)
        {
            _logger.LogInformation("Creating address");
            try
            {
                var address = _mapper.Map<Address>(addressDTO);
                _context.Address.Add(address);
                _context.SaveChanges();
                return address;                
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace, e.Source);
                throw;               
            }
        }

        public ServiceResponse<bool> Delete(int id)
        {
            _logger.LogInformation($"Deleting Address by id = {id}");
            var address = _context.Address.FirstOrDefault(x =>
                x.AddressId == id);
            var now = DateTime.UtcNow;
            if (address == null)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Address to delete not found",
                    Data = false
                };
            }
            try
            {
                _context.Address.Remove(address);
                _context.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Address deleted!",
                    Data = true
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception {e.Message}, {e.StackTrace}");
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Data = false
                };
            }
        }

        public ServiceResponse<bool> Update(AddressDTO addressDTO)
        {
            _logger.LogInformation("Updating address");
            var now = DateTime.UtcNow;
            var address = _context.Address
                .FirstOrDefault(d => d.AddressId == addressDTO.AddressId);
            if (address == null)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Address not found",
                    Data = false
                };
            }
            try
            {
                address.AddressLine1 = addressDTO.AddressLine1;
                address.AddressLine2 = addressDTO.AddressLine2;
                address.City = addressDTO.City;
                address.Country = addressDTO.Country;
                address.UpdatedOn = DateTime.Now;
                address.PostalCode = addressDTO.PostalCode;
                 
                
                _context.SaveChanges();

                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Address was updated",
                    Data = true
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception {e.Message}, {e.StackTrace}");
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Data = false
                };
            }
        }
    }
}
