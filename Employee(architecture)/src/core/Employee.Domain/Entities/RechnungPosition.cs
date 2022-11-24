using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Domain.Entities
{
    public class RechnungPosition
    {
        public int RechnungPositionId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? DisplayedTarifName { get; set; }
        public double? Hours { get; set; }
        public decimal? Sum { get; set; }
        public int? TarifId { get; set; }       
        public List<Developer>? Developer { get; set; } 
        public int RechungId { get; set; }
        public Rechnung Rechnung { get; set; }
    }
}
