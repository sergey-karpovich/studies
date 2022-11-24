using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Application.Common.Mappings
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Developer, DeveloperDTO>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<ApiUser, ApiUserDTO>().ReverseMap();
            CreateMap<Auftrag, AuftragDTO>().ReverseMap();
            CreateMap<Tarif, TarifDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            
        }
    }
}
