using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Domain.Entities
{
    [Index("ProjectId", IsUnique = true)]
    public partial class Project
    {
        [Key]
        [Column("ProjectId")]
        public long ProjectId { get; set; }
        [Column(TypeName = "VARCHAR (20)")]
        public string? ProjectName { get; set; }
        [Column(TypeName = "VARCHAR (200)")]
        public string? Description { get; set; }
        [Column(TypeName = "DATETIME")]
        public DateTime? DateOfAdoption { get; set; }
        [Column(TypeName = "DATETIME")]
        public DateTime? Deadline { get; set; }
        [Column(TypeName = "DECIMAL")]
        public decimal? Budjet { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        //public IEnumerable<ProjectEmployeeJunction>?
        //    ProjectsEmployees
        //{ get; set; }
    }
}
