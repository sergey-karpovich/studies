using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Domain.Entities
{    
    public partial class Project
    {               
        public int ProjectId { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public bool? IsGKK { get; set; }
        public bool? IsActiv { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ClientId { get; set; }
        public Client Client { get; set; }
        public List<DeveloperProject>? DeveloperProject { get; set; }

        public List<Auftrag>? Auftrag { get; set; } 

    }
}
