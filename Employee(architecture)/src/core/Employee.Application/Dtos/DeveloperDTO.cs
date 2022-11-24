using EmployeeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Application.Dtos
{
    public class DeveloperDTO
    {
        public int DeveloperId { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }
        public string? Areas { get; set; }
        public decimal? Salary { get; set; }
        public string? HomePhone { get; set; }
        public string? PhotoPath { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? RetireDate { get; set; }
        public int? AddressId { get; set; }       
        public List<int>? DeveloperProjectId { get; set; }
        public int? TarifId { get; set; }       
        public List<int>? RechnungPositionsId { get; set; }


    }

    public class TheDeveloperWithAuftragsDTO : DeveloperDTO
    {
        public int DeveloperId { get; set; }
        public List<Auftrag>? Auftrags { get; set; }
        
    }



}
