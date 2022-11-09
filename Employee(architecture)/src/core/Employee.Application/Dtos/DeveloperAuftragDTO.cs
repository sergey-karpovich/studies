using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Application.Dtos
{
    public  class DeveloperAuftragDTO
    {
        //public int Id { get; set; }

        public int DeveloperId { get; set; }

        public int AuftragId { get; set; }

        public int TarifId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
