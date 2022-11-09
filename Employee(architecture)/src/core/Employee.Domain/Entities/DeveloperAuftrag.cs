using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Domain.Entities
{
    public class DeveloperAuftrag
    {
        public int Id { get; set; }

        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }

        public int AuftragId { get; set; }
        public Auftrag Auftrag { get; set; }

        public int TarifId { get; set; }
        public Tarif Tarif { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
