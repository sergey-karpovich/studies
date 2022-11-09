using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Domain.Entities
{
    public class Tarif
    {        
        public int Id { get; set; }        
        public decimal Amount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int TarifTypeId { get; set; }
        public TarifType TarifType { get; set; }
        //public List<Developer> Developers { get; set; } = new List<Developer>();
    }
}
