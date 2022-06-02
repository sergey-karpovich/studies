﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Company.Models
{
    public class CompanyContext : DbContext
    {
        

        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options){}
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Project>? Projects{get;set;}
        public DbSet<WorkTime>? WorkTimes{get;set;}
        
        
    }
}