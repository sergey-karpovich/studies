using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Domain.Entities
{
    public class WorkTime
    {
        [Key]
        public long Id { get; set; }
        [Column(TypeName = "DECIMAL")]
        public decimal? Hours { get; set; }
        [Column(TypeName = "DECIMAL")]
        public decimal? LastRate { get; set; }
        public int? NumMonth { get; set; }
        public int? NumYear { get; set; }
        public long EmployeeId { get; set; }
        public long ProjectId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
    }
}
