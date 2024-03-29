﻿using EmployeeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Domain.Entities
{
    public class Auftrag
    {
        public int AuftragId { get; set; }
        public string? JobNr { get; set; }
        public string? AuftragNr { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }

        //public List<DeveloperAuftrag>? DeveloperAuftrag { get; set; } 
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }
        public int? ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
