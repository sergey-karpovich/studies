﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Company.AutoGenModels
{
    public partial class Shipper
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("ShipperID")]
        public long ShipperId { get; set; }
        [Column(TypeName = "nvarchar (40)")]
        public string CompanyName { get; set; } = null!;
        [Column(TypeName = "nvarchar (24)")]
        public string? Phone { get; set; }

        [InverseProperty("ShipViaNavigation")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
