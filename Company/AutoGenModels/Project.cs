using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Company.AutoGenModels
{
    [Index("ProjectId", IsUnique = true)]
    public partial class Project
    {
        [Key]
        [Column("ProjectID")]
        public long ProjectId { get; set; }
        [Column(TypeName = "VARCHAR (20)")]
        public string? ProjectName { get; set; }
        [Column(TypeName = "VARCHAR (200)")]
        public string? Description { get; set; }
        [Column(TypeName = "DATETIME")]
        public byte[]? DateOfAdoption { get; set; }
        [Column(TypeName = "DATETIME")]
        public byte[]? Deadline { get; set; }
        [Column(TypeName = "DECIMAL")]
        public byte[]? Budjet { get; set; }
    }
}
