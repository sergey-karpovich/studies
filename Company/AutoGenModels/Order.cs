﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Company.AutoGenModels
{
    [Index("CustomerId", Name = "CustomerID")]
    [Index("CustomerId", Name = "CustomersOrders")]
    [Index("EmployeeId", Name = "EmployeeID")]
    [Index("EmployeeId", Name = "EmployeesOrders")]
    [Index("OrderDate", Name = "OrderDate")]
    [Index("ShipPostalCode", Name = "ShipPostalCode")]
    [Index("ShippedDate", Name = "ShippedDate")]
    [Index("ShipVia", Name = "ShippersOrders")]
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("OrderID")]
        public long OrderId { get; set; }
        [Column("CustomerID", TypeName = "nchar (5)")]
        public string? CustomerId { get; set; }
        [Column("EmployeeID", TypeName = "int")]
        public long? EmployeeId { get; set; }
        [Column(TypeName = "datetime")]
        public byte[]? OrderDate { get; set; }
        [Column(TypeName = "datetime")]
        public byte[]? RequiredDate { get; set; }
        [Column(TypeName = "datetime")]
        public byte[]? ShippedDate { get; set; }
        [Column(TypeName = "int")]
        public long? ShipVia { get; set; }
        [Column(TypeName = "money")]
        public byte[]? Freight { get; set; }
        [Column(TypeName = "nvarchar (40)")]
        public string? ShipName { get; set; }
        [Column(TypeName = "nvarchar (60)")]
        public string? ShipAddress { get; set; }
        [Column(TypeName = "nvarchar (15)")]
        public string? ShipCity { get; set; }
        [Column(TypeName = "nvarchar (15)")]
        public string? ShipRegion { get; set; }
        [Column(TypeName = "nvarchar (10)")]
        public string? ShipPostalCode { get; set; }
        [Column(TypeName = "nvarchar (15)")]
        public string? ShipCountry { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Orders")]
        public virtual Customer? Customer { get; set; }
        [ForeignKey("EmployeeId")]
        [InverseProperty("Orders")]
        public virtual Employee? Employee { get; set; }
        [ForeignKey("ShipVia")]
        [InverseProperty("Orders")]
        public virtual Shipper? ShipViaNavigation { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
