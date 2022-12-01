using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Repositories.Auftrags
{
    public class AuftragRepository : IAuftragRepository
    {
        private CompanyContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AuftragRepository> _logger;
        public AuftragRepository(CompanyContext context,
            IMapper mapper,
            ILogger<AuftragRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public ServiceResponse<List<AuftragDTO>> GetAll()
        {
            var now = DateTime.UtcNow;
            var auftrags = _context.Auftrag.ToList();
            var auftragDTOs = _mapper.Map<List<AuftragDTO>>(auftrags);
            return new ServiceResponse<List<AuftragDTO>>
            {
                Time = now,
                IsSuccess = true,
                Message = "Getting all auftrags",
                Data = auftragDTOs
            };
        }

        public ServiceResponse<AuftragDTO> GetById(int id)
        {
            var now = DateTime.UtcNow;
            var model = _context.Auftrag.FirstOrDefault(cl => cl.ClientId == id);
            //var client = _context.Client.Find(id);
            var DTO = _mapper.Map<AuftragDTO>(model);
            return new ServiceResponse<AuftragDTO>
            {
                Time = now,
                IsSuccess = model != null,
                Message = "Getting auftrag by id",
                Data = DTO
            };
        }

        public Auftrag Create(AuftragDTO DTO)
        {
            var model = _mapper.Map<Auftrag>(DTO);
            _context.Auftrag.Add(model);
            _context.SaveChanges();

            return model;
        }

        public ServiceResponse<bool> Delete(int auftragId)
        {
            var auftrag = _context.Auftrag.FirstOrDefault(c => c.AuftragId == auftragId);
            var now = DateTime.UtcNow;
            if (auftrag == null)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Auftrag to delete not found",
                    Data = false
                };
            }
            _context.Auftrag.Remove(auftrag);
            var response = _context.SaveChanges();
            return new ServiceResponse<bool>
            {
                Time = now,
                IsSuccess = response > 0,
                Message = response > 0 ? "Auftrag deleted" : "Deletion failed",
                Data = response > 0
            };
        }

        public ServiceResponse<bool> Update(AuftragDTO DTO)
        {
            var now = DateTime.UtcNow;
            var model = _mapper.Map<Auftrag>(DTO);
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
