using EmployeeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Application.Dtos
{
    internal class ProjectDTO
    {
        public long ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfAdoption { get; set; }
        public DateTime? Deadline { get; set; }
        public decimal? Budjet { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
