using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Application.Dtos
{
    internal class WorkTimeDTO
    {
        public long Id { get; set; }
        public decimal? Hours { get; set; }
        public decimal? LastRate { get; set; }
        public int? NumMonth { get; set; }
        public int? NumYear { get; set; }
        public long EmployeeId { get; set; }
        public long ProjectId { get; set; }
        public DateTime? Date { get; set; }
    }
}
