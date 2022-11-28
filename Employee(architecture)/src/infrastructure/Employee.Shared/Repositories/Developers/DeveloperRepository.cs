using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Repositories.Developers
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private CompanyContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DeveloperRepository> _logger;

        public DeveloperRepository(
            CompanyContext context,
            IMapper mapper,
            ILogger<DeveloperRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public ServiceResponse<List<DeveloperDTO>> GetAllDevelopers()
        {
            _logger.LogInformation("Getting all Developers");
            var now = DateTime.UtcNow;
            List<Developer> allDevelopers = _context.Developer.ToList();
            var allDevelopersDTO = _mapper.Map<IList<DeveloperDTO>>(allDevelopers);
            if (allDevelopersDTO is null)
            {
                _logger.LogError("AllDevelopersDTO  is null");
                return new ServiceResponse<List<DeveloperDTO>>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Something went wrong in DeveloperRepository",
                    Data = null
                };
            }
            try
            {
                return new ServiceResponse<List<DeveloperDTO>>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Getting all Developers",
                    Data = (List<DeveloperDTO>)allDevelopersDTO
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<DeveloperDTO>>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Data = null
                };
            }

        }

        public ServiceResponse<DeveloperDTO> GetById(int id)
        {
            _logger.LogInformation($"Getting  Developer by id = {id}");
            var now = DateTime.UtcNow;
            try
            {
                var developer = _context.Developer.Find(id);
                var developerDTO = _mapper.Map<DeveloperDTO>(developer);
                return new ServiceResponse<DeveloperDTO>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Developer by id",
                    Data = developerDTO
                };

            }
            catch
            {
                return new ServiceResponse<DeveloperDTO>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Developer not found",
                    Data = null
                };
            }

        }

        public Developer Create(DeveloperDTO developerDTO)
        {
            _logger.LogInformation("Creating developer");
            try
            {
                var developer = _mapper.Map<Developer>(developerDTO);
                _context.Developer.Add(developer);
                _context.SaveChanges();
                return developer;
                //    new ServiceResponse<bool>
                //{
                //    IsSuccess = true,
                //    Message = "New Customer added",
                //    Time = DateTime.UtcNow,
                //    Data = true
                //};
            }
            catch 
            {
                throw;
                //    new ServiceResponse<bool>
                //{
                //    IsSuccess = false,
                //    Message = e.StackTrace,
                //    Time = DateTime.UtcNow,
                //    Data = false
                //};
            }
        }

        public ServiceResponse<bool> Delete(int developerId)
        {
            _logger.LogInformation($"Deleting developer by id = {developerId}");
            var developer = _context.Developer.FirstOrDefault(x => 
                x.DeveloperId == developerId);
            var now = DateTime.UtcNow;
            if (developer == null)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Developer to delete not found",
                    Data = false
                };
            }
            try
            {
                _context.Developer.Remove(developer);
                _context.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Developer deleted!",
                    Data = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Data = false
                };
            }
        }

        public ServiceResponse<bool> Update( DeveloperDTO developerDTO)
        {
            _logger.LogInformation("Updating developer");
            var now = DateTime.UtcNow;
            var Developer = _context.Developer
                .FirstOrDefault(d => d.DeveloperId == developerDTO.DeveloperId);
            if (Developer == null)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Developer not found",
                    Data = false
                };
            }
            try
            {
                Developer.FirstName = developerDTO.FirstName;
                Developer.LastName = developerDTO.LastName;
                Developer.Description = developerDTO.Description;
                Developer.Areas = developerDTO.Areas;
                Developer.Salary = developerDTO.Salary;
                Developer.HomePhone = developerDTO.HomePhone;
                Developer.PhotoPath = developerDTO.PhotoPath;
                Developer.BirthDate = developerDTO.BirthDate;
                Developer.HireDate = developerDTO.HireDate;
                Developer.RetireDate = developerDTO.RetireDate;
                Developer.AddressId = developerDTO.AddressId;
                Developer.TarifId = developerDTO.TarifId;
                if(developerDTO.DeveloperProject != null)
                {
                    List<DeveloperProject> developerProjects = _mapper
                        .Map<List<DeveloperProject>>(developerDTO.DeveloperProject);
                    Developer.DeveloperProject = developerProjects;
                }
                if (developerDTO.RechnungPositionsId != null && developerDTO.RechnungPositionsId.Count>0)
                {
                    List<RechnungPosition> rechnungPositions = new List<RechnungPosition>();
                    foreach(int id in developerDTO.RechnungPositionsId)
                    {
                        var rechPos = _context.RechnungPosition.FirstOrDefault(rp => rp.RechnungPositionId == id);
                        rechnungPositions.Add(rechPos);
                    }
                    Developer.RechnungPositions = rechnungPositions;
                }
                _context.SaveChanges();

                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Developer was updated",
                    Data = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Data = false
                };
            }
        }


        //public Developer AddDeveloper(DeveloperDTO developerDTO)
        //{
        //    var developer = _mapper.Map<Developer>(developerDTO);
        //    //    new Developer
        //    //{
        //    //    FirstName = developerDTO.FirstName,
        //    //    LastName = developerDTO.LastName,
        //    //    Description=developerDTO.Description,
        //    //    Areas=developerDTO.Areas,
        //    //    Salary=developerDTO.Salary,
        //    //    HomePhone=developerDTO.HomePhone,
        //    //    PhotoPath=developerDTO.PhotoPath,
        //    //    BirthDate=developerDTO.BirthDate,
        //    //    HireDate=developerDTO.HireDate,
        //    //    EndDate=developerDTO.EndDate,
        //    //};
        //    _context.Developers.Add(developer);
        //    _context.SaveChanges();

        //    return developer;
        //}
        //public List<Developer> GetAllDevelopers() => _context.Developers.ToList();

        //public TheDeveloperWithAuftragsDTO GetDeveloperById(int id)
        //{
        //    var developer = _context.Developers.Where(t => t.Id == id)
        //        .Select(d => new TheDeveloperWithAuftragsDTO()
        //        {
        //            DeveloperId = d.Id,
        //            FirstName = d.FirstName,
        //            LastName = d.LastName,
        //            Auftrags =d.DeveloperAuftrags.Select(da=>da.Auftrag).ToList(),
        //        }).FirstOrDefault();
        //    return developer;


        //}

        //// Не работают!!!
        //public DeveloperAuftragTarifDTO GetDevAuftrByAuftrag(int auftragId)
        //{
        //    var developerAuftragTarifDTO = _context.Auftrags.Where(a => a.Id == auftragId)
        //        .Select(auftrag =>
        //        new DeveloperAuftragTarifDTO()
        //        {
        //            StartDate = (DateTime)auftrag.StartDate,
        //            EndDate =(DateTime)auftrag.EndDate,
        //            AuftragId = auftrag.Id,
        //            DevelopersDTO = auftrag.DeveloperAuftrags
        //            .Select(da => _mapper.Map<DeveloperDTO>(da.Developer)).ToList()
        //        }).FirstOrDefault();

        //    return developerAuftragTarifDTO;
        //}
        //public  List<DeveloperAuftragTarifDTO> GetDevAuftrByMonth(DateTime firstDayMonth)
        //{
        //    var month = (int)firstDayMonth.Month;
        //    var lastDayMonth = new DateTime(firstDayMonth.Year, month + 1, 1);
        //    var auftrags = (from auftrag in _context.Auftrags
        //                    where (auftrag.StartDate < firstDayMonth &&
        //                    ((auftrag.EndDate??lastDayMonth) <= lastDayMonth))
        //                    select auftrag
        //                    ).ToList();
        //    var developerAuftragTarifDTO = new List<DeveloperAuftragTarifDTO>();
        //    foreach(var auftrag in auftrags)
        //    {
        //        var devAuftrTarDTO = new DeveloperAuftragTarifDTO()
        //        {
        //            DevelopersDTO = _mapper.Map<List<DeveloperDTO>>(
        //                auftrag.DeveloperAuftrags.Select(da =>new DeveloperDTO()
        //                {
        //                    FirstName = da.Developer.FirstName,
        //                    LastName = da.Developer.LastName,
        //                    TarifId = da.TarifId
        //                }).ToList()
        //                ),
        //            StartDate=firstDayMonth,
        //            EndDate=lastDayMonth,
        //            AuftragId=auftrag.Id
        //        };
        //        developerAuftragTarifDTO.Add(devAuftrTarDTO);
        //    }
        //    return developerAuftragTarifDTO;

        //}
    }
}
