using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Models
{
    public class WorkTime
    {
        public long Id { get; set; }
        public int? NumMonth { get; set; }
        public int? Hours { get; set; }
        [Column(TypeName = "DECIMAL")]
        public decimal? LastRate { get; set; }        
        public long EmployeeId { get; set; }
        public long ProjectId { get; set; }
    }
}
