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

namespace EmployeeAPI.Services.TarifService
{
    public class TarifRepository : ITarifRepository
    {
        private CompanyContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<TarifRepository> _logger;
        public TarifRepository(CompanyContext context,
            IMapper mapper,
            ILogger<TarifRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public ServiceResponse<List<TarifDTO>> GetAll()
        {
            _logger.LogInformation("Getting all Tarifs");
            var now = DateTime.UtcNow;
            List<Tarif> tarivs = _context.Tarif.ToList();
            var allTarifsDTO = _mapper.Map<List<TarifDTO>>(tarivs);
            if (allTarifsDTO is null)
            {
                _logger.LogError("allTarifDTO  is null");
                return new ServiceResponse<List<TarifDTO>>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Something went wrong in TarifRepository",
                    Data = null
                };
            }
            try
            {
                return new ServiceResponse<List<TarifDTO>>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Getting all Tarif",
                    Data = allTarifsDTO
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception {e.Message}, {e.StackTrace}");
                return new ServiceResponse<List<TarifDTO>>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Data = null
                };
            }
        }

        public ServiceResponse<TarifDTO> GetById(int id)
        {
            _logger.LogInformation($"Getting  Tarif by id = {id}");
            var now = DateTime.UtcNow;
            try
            {
                var tarif = _context.Tarif.Find(id);
                if(tarif is null)
                {
                    return new ServiceResponse<TarifDTO>
                    {
                        Time = now,
                        IsSuccess = false,
                        Message = "Tarif not found",
                        Data = null
                    };
                }


                var tarifDTO = _mapper.Map<TarifDTO>(tarif);
                return new ServiceResponse<TarifDTO>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Gettirn tarif by id",
                    Data = tarifDTO
                };

            }
            catch (Exception e)
            {
                _logger.LogError($"Exception {e.Message}, {e.StackTrace}");
                return new ServiceResponse<TarifDTO>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace ?? "Something wrong in repository",
                    Data = null
                };
            }
        }

        public Tarif Create(TarifDTO tarifDTO)
        {
            _logger.LogInformation("Creating tarif");
            try
            {
                var tarif = _mapper.Map<Tarif>(tarifDTO);
                _context.Tarif.Add(tarif);
                _context.SaveChanges();
                return tarif;

            }
            catch
            {
                throw;
            }
        }

        public ServiceResponse<bool> Delete(int tarifId)
        {
            _logger.LogInformation($"Deleting Tarif by id = {tarifId}");
            var tarif = _context.Tarif.FirstOrDefault(x =>
                x.TarifId == tarifId);
            var now = DateTime.UtcNow;
            if (tarif == null)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Tarif to delete not found",
                    Data = false
                };
            }
            try
            {
                _context.Tarif.Remove(tarif);
                _context.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Tarif deleted!",
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

        public ServiceResponse<bool> Update(TarifDTO tarifDTO)
        {
            _logger.LogInformation("Updating address");
            var now = DateTime.UtcNow;
            //var tarif = _context.Tarif
            //    .FirstOrDefault(d => d.TarifId == tarifDTO.TarifId);
            var tarif = _mapper.Map<Tarif>(tarifDTO);
            if (tarif == null)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Tarif not found",
                    Data = false
                };
            }
            try
            {
                _context.Attach(tarif);
                _context.Entry(tarif).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _context.SaveChanges();

                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Tarif was updated",
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
