using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Repositories.Clients
{
    public class ClientRepository : IClientRepository
    {
        private CompanyContext _context;
        private readonly IMapper _mapper;
        public ClientRepository(CompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ServiceResponse<List<ClientDTO>> GetAll()
        {
            var now = DateTime.UtcNow;
            var clients = _context.Client.ToList();
            var clientDTOs = _mapper.Map<List<ClientDTO>>(clients);
            return new ServiceResponse<List<ClientDTO>>
            {
                Time = now,
                IsSuccess = true,
                Message = "Getting all clients",
                Data = clientDTOs
            };
        }

        public ServiceResponse<ClientDTO> GetById(int id)
        {
            var now = DateTime.UtcNow;
            var client = _context.Client.FirstOrDefault(cl => cl.ClientId == id);
            //var client = _context.Client.Find(id);
            var DTO = _mapper.Map<ClientDTO>(client);
            return new ServiceResponse<ClientDTO>
            {
                Time = now,
                IsSuccess = client != null,
                Message = "Getting client by id",
                Data = DTO
            };
        }

        public Client Create(ClientDTO clientDTO)
        {
            var client = _mapper.Map<Client>(clientDTO);
            _context.Client.Add(client);
            _context.SaveChanges();

            return client;
        }

        public ServiceResponse<bool> Update(ClientDTO clientDTO)
        {
            var now = DateTime.UtcNow;
            var client = _mapper.Map<Client>(clientDTO);
            _context.Attach(client);
            _context.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var response = _context.SaveChanges();

            return new ServiceResponse<bool>
            {
                Time = now,
                IsSuccess = response > 0,
                Message = response > 0 ? "Success" : "Fail",
                Data = response > 0
            };
        }

        public ServiceResponse<bool> Delete(int clientId)
        {
            var client = _context.Client.FirstOrDefault(c => c.ClientId == clientId);
            var now = DateTime.UtcNow;
            if (client == null)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Client to delete not found",
                    Data = false
                };
            }
            _context.Client.Remove(client);
            var response = _context.SaveChanges();
            return new ServiceResponse<bool>
            {
                Time = now,
                IsSuccess = response > 0,
                Message = response > 0 ? "Client deleted" : "Deletioin failed",
                Data = response > 0
            };
        }
    }
}
