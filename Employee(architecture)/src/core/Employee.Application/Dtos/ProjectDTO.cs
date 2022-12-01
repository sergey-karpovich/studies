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
        public int ProjectId { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public bool? IsGKK { get; set; }
        public bool? IsActiv { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ClientId { get; set; }
        public List<DeveloperDTO>? DeveloperDTOList { get; set; }
        public List<AuftragDTO>? AuftragDTOList { get; set; }
    }
}
