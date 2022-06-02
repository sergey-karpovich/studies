using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Company.AutoGenModels
{
    [Keyless]
    public partial class EmployeeTerritory
    {
        [Column("EmployeeID", TypeName = "int")]
        public long EmployeeId { get; set; }
        [Column("TerritoryID", TypeName = "nvarchar")]
        public string TerritoryId { get; set; } = null!;
    }
}
