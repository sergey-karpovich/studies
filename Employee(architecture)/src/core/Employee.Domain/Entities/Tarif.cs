﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Domain.Entities
{
    public class Tarif
    {        
        public int TarifId { get; set; }        
        public decimal Amount { get; set; }
        public string TarifType { get; set; }
        public string DisplayedName { get; set; }
        public int? ClientId { get; set; }
        public Client? Client  { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }        
        
    }
}
