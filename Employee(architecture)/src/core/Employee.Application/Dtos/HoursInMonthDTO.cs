using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Application.Dtos
{
    public class HoursInMonthDTO
   
    {
        public int HoursInMonthId { get; set; }
        public int DeveloperId { get; set; }
        public int? AuftragId { get; set; }
        public int? TarifId { get; set; }
        public decimal TotalHours { get; set; }
        public int Month { get; set; }
    }
}
