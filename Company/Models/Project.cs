using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Company.Models
{
    [Index("ProjectID", IsUnique = true)]
    public partial class Project
    {
        [Key]
        [Column("ProjectID")]
        public long ProjectID { get; set; }
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
        public IEnumerable<ProjectEmployeeJunction>?
            ProjectsEmployees{get;set;}
    }

}