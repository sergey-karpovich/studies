﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Domain.Entities
{
    public class Developer
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
        public Address? Address { get; set; }
        public List<DeveloperProject>? DeveloperProject { get; set; } 
        public int? TarifId { get; set; }
        public Tarif? Tarif { get; set; }
        public List<RechnungPosition>? RechnungPositions { get; set; }


    }
}
