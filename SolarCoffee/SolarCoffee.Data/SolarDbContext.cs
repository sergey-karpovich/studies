﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolarCoffee.Data.Models;

namespace SolarCoffee.Data;
public class SolarDbContext :IdentityDbContext
{
    public SolarDbContext() { }

    public SolarDbContext(DbContextOptions<SolarDbContext> options ): base(options) { }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<CustomerAddress> CustomerAdresses { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductInventory> ProductInventories { get; set; }
    public virtual DbSet<ProductInventorySnapshot> ProductInventoriesSnapshots { get; set; }
    public virtual DbSet<SalesOrder> SalesOrders { get; set; }
    public virtual DbSet<SalesOrderItem> SalesOrderItems { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
