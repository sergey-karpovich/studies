﻿using AutoMapper;
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
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<WorkTime, WorkTimeDTO>().ReverseMap();
        }
    }
}
