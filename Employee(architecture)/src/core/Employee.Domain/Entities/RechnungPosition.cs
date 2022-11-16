using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Domain.Entities
{
    public class RechnungPosition
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? Hours { get; set; }
        public decimal? Sum { get; set; }
        public int? TarifTypeId { get; set; }
        public TarifType? TarifType { get; set; }
        public List<Developer>? Developers { get; set; } 
        public int RechungId { get; set; }
        public Rechnung? Rechnung { get; set; }
    }
}
