using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Domain.Entities
{
    public class Developer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }
        public string? Areas { get; set; }
        public decimal? Salary { get; set; }
        public string? HomePhone { get; set; }
        public string? PhotoPath { get; set; }
        public DateTime? BirthDate { get; set; }        
        public DateTime? HireDate { get; set; }        
        public DateTime? EndDate { get; set; }

        public List<DeveloperAuftrag>? DeveloperAuftrags { get; set; } = new List<DeveloperAuftrag>();
        public int? TarifId { get; set; }
        public Tarif? Tarif { get; set; }
        public RechnungPosition? RechnungPosition { get; set; }


    }
}
