using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services.HoursService
{
    public class HoursRepository 
    {
        private CompanyContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<HoursRepository> _logger;
        public HoursRepository(CompanyContext context,
            IMapper mapper,
            ILogger<HoursRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public ServiceResponse<List<HoursInMonthDTO>> GetAll()
        {
            var now = DateTime.UtcNow;
            var hours = _context.HoursInMonth.ToList();
            var hoursDTO = _mapper.Map<List<HoursInMonthDTO>>(hours);
            return new ServiceResponse<List<HoursInMonthDTO>>
            {
                Time = now,
                IsSuccess = true,
                Message = "Getting all hours",
                Data = hoursDTO
            };
        }

        public ServiceResponse<HoursInMonthDTO> GetById(int id)
        {
            var now = DateTime.UtcNow;
            var model = _context.HoursInMonth.FirstOrDefault(cl => cl.HoursInMonthId == id);
            var DTO = _mapper.Map<HoursInMonthDTO>(model);
            return new ServiceResponse<HoursInMonthDTO>
            {
                Time = now,
                IsSuccess = model != null,
                Message = "Getting hours by id",
                Data = DTO
            };
        }

        public  HoursInMonth Create(HoursInMonth DTO)
        {
            var model = _mapper.Map<HoursInMonth>(DTO);
            _context.HoursInMonth.Add(model);
            _context.SaveChanges();

            return model;
        }

        public ServiceResponse<bool> Delete(int hoursId)
        {
            var hours = _context.HoursInMonth.FirstOrDefault(c => c.HoursInMonthId == hoursId);
            var now = DateTime.UtcNow;
            if (hours == null)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Record to delete not found",
                    Data = false
                };
            }
            _context.HoursInMonth.Remove(hours);
            var response = _context.SaveChanges();
            return new ServiceResponse<bool>
            {
                Time = now,
                IsSuccess = response > 0,
                Message = response > 0 ? "Record deleted" : "Deletioin failed",
                Data = response > 0
            };
        }

        public ServiceResponse<bool> Update( HoursInMonth hours)
        {
            var now = DateTime.UtcNow;
            var model = _mapper.Map<HoursInMonth>(hours);
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
