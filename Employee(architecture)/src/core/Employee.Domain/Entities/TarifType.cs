using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Domain.Entities
{
    public class TarifType
    { 
        public int Id { get; set; }
        public string Type { get; set; }

        public Tarif? Tarif { get; set; }
        public RechnungPosition? RechnungPosition { get; set; }
        //public List<Tarif> Tarifs { get; set; } = new List<Tarif>();
        //public List<RechnungPosition> RechnungPosition { get; set; } = new List<RechnungPosition>();
    }
}
