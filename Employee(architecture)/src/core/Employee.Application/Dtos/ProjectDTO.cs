using EmployeeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Application.Dtos
{
    public  class ProjectDTO
    {
        //public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfAdoption { get; set; }
        public DateTime? Deadline { get; set; }
        public decimal? Budjet { get; set; }
        
    }
}
