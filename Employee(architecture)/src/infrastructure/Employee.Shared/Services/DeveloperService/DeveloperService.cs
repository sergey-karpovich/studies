using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services.DeveloperService
{
    public class DeveloperRepository:IGenericService<Developer, DeveloperDTO>
    {
        private CompanyContext _context;
        private readonly IMapper _mapper;
        public DeveloperRepository(CompanyContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ServiceResponse<List<DeveloperDTO>> GetAll()
        {
            var now = DateTime.UtcNow;
            List<Developer> allDevelopers = _context.Developer.ToList();
            var allDevelopersDTO = _mapper.Map<IList<DeveloperDTO>>(allDevelopers);
            if(allDevelopersDTO is null)
            {
                return new ServiceResponse<List<DeveloperDTO>>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Something went wrong in DeveloperService",
                    Data = null
                };
            }
            try
            {
                return new ServiceResponse<List<DeveloperDTO>>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Customer deleted!",
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
            var now = DateTime.UtcNow;
            try
            {
                var developer = _context.Developer.Find(id);
                var developerDTO = _mapper.Map<DeveloperDTO>(developer);
                return new ServiceResponse<DeveloperDTO>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Customer to delete not found",
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

        public ServiceResponse<bool> Create(DeveloperDTO item)
        {
            try
            {
                var developer = _mapper.Map<Developer>(item);
                _context.Developer.Add(developer);
                _context.SaveChanges();
                return new ServiceResponse<bool>
                {
                    IsSuccess = true,
                    Message = "New Customer added",
                    Time = DateTime.UtcNow,
                    Data = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = false
                };
            }
        }

        public ServiceResponse<bool> Delete(int itemId)
        {
            var developer = _context.Developer.FirstOrDefault(x => x.DeveloperId == itemId);
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

        public ServiceResponse<bool> Update(int itemId, DeveloperDTO item)
        {
            var now = DateTime.UtcNow;
            var Developer = _context.Developer.FirstOrDefault(d => d.DeveloperId == itemId);
            if(Developer == null)
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
                Developer.FirstName =item.FirstName;
                Developer.LastName =item.LastName;
                Developer.Description =item.Description;
                Developer.Areas =item.Areas;
                Developer.Salary =item.Salary;
                Developer.HomePhone =item.HomePhone;
                Developer.PhotoPath =item.PhotoPath;
                Developer.BirthDate =item.BirthDate;
                Developer.HireDate =item.HireDate;
                Developer.RetireDate =item.RetireDate;
                Developer.AddressId =item.AddressId;
                Developer.TarifId = item.TarifId;
                foreach(var id in item.DeveloperProjectId)
                {

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
            catch(Exception e)
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
