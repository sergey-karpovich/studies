using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace EmployeeAPI.Models
{
    [Index("LastName", Name = "LastName")]
    [Index("PostalCode", Name = "PostalCodeEmployees")]
    public class Employee
    {
        // public Employee()
        // {            
        // }

        [Key]
        [Column("EmployeeID")]
        public long? EmployeeId { get; set; }
        [Column(TypeName = "nvarchar (100)")]
        public string? FirstName { get; set; }
        [Column(TypeName = "nvarchar (100)")]
        public string? LastName { get; set; }
        [Column(TypeName = "nvarchar (1000)")]
        public string? Description { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? Rate { get; set; }
        [Column(TypeName = "nvarchar (100)")]
        public string? Areas { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HireDate { get; set; }
        [Column(TypeName = "nvarchar (50)")]
        public string? HomePhone { get; set; }
        [Column(TypeName = "nvarchar (1000)")]
        public string? PhotoPath { get; set; }


        [Column(TypeName = "nvarchar (150)")]
        public string? Address { get; set; }
        [Column(TypeName = "nvarchar (150)")]
        public string? City { get; set; }
        [Column(TypeName = "nvarchar (150)")]
        public string? Region { get; set; }
        [Column(TypeName = "nvarchar (100)")]
        public string? PostalCode { get; set; }
        [Column(TypeName = "nvarchar (150)")]
        public string? Country { get; set; }
        [Column(TypeName = "nvarchar (100)")]
        public string? Extension { get; set; }
        [Column(TypeName = "image")]
        public byte[]? Photo { get; set; }
        [Column(TypeName = "ntext")]
        public string? Notes { get; set; }
        [Column(TypeName = "int")]
        public long? ReportsTo { get; set; }
        public IEnumerable<WorkTime>? WorkTimes { get; set; }
        public IEnumerable<ProjectEmployeeJunction>?
            ProjectsEmployees
        { get; set; }
    }
}
