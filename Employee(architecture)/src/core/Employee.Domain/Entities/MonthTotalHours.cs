﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Domain.Entities
{
    public  class MonthTotalHours
    {
        public int MonthTotalHoursId { get; set; }
        public int DeveloperId { get; set; }
        public int ProjectId { get; set; }
        public int TarifId { get; set; }
        public decimal TotalHours { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}