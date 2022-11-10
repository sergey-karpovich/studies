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

    public class DeveloperAuftragTarifDTO
    {
        public List<DeveloperDTO> DevelopersDTO{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AuftragId { get; set; }

        //public int Id { get; set; }
        //public string LastName { get; set; }
        //public decimal? Salary { get; set; }
        //public string? PhotoPath { get; set; }
        //public string? Description { get; set; }
        //public string? Areas { get; set; }
        //public string? HomePhone { get; set; }
        //public DateTime? BirthDate { get; set; }
        //public DateTime? HireDate { get; set; }
        //public DateTime? EndDate { get; set; }

    }

    public class DeveloperWithAuftragDTO
    {
        public DeveloperDTO DeveloperDTO { get; set; }
        public AuftragDTO AuftragDTO { get; set; }
        public TarifDTO TarifDTO { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
