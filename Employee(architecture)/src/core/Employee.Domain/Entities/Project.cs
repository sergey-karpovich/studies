using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Domain.Entities
{    
    public partial class Project
    {               
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsGKK { get; set; }
        public bool? IsActiv { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfAdoption { get; set; }
        public DateTime? Deadline { get; set; }
        public decimal? Budjet { get; set; }

        public List<Auftrag>? Auftrags { get; set; } 

    }
}
