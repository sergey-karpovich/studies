using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Domain.Entities
{
    public class Rechnung
    {
        public int RechnungId { get; set; }
        public string ClientName { get; set; }
        public string? ClientAddress { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? RechnungsSumme { get; set; }
        public List<RechnungPosition>? RechnungPosition { get; set; } 
    }
}
