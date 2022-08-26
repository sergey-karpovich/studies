﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Company.AutoGenModels
{
    [Table("Order Details")]
    [Index("OrderId", Name = "OrderID")]
    [Index("OrderId", Name = "OrdersOrder_Details")]
    [Index("ProductId", Name = "ProductID")]
    [Index("ProductId", Name = "ProductsOrder_Details")]
    public partial class OrderDetail
    {
        [Key]
        [Column("OrderID", TypeName = "int")]
        public long OrderId { get; set; }
        [Key]
        [Column("ProductID", TypeName = "int")]
        public long ProductId { get; set; }
        [Column(TypeName = "money")]
        public byte[] UnitPrice { get; set; } = null!;
        [Column(TypeName = "smallint")]
        public long Quantity { get; set; }
        [Column(TypeName = "real")]
        public double Discount { get; set; }

        [ForeignKey("OrderId")]
        [InverseProperty("OrderDetails")]
        public virtual Order Order { get; set; } = null!;
        [ForeignKey("ProductId")]
        [InverseProperty("OrderDetails")]
        public virtual Product Product { get; set; } = null!;
    }
}
