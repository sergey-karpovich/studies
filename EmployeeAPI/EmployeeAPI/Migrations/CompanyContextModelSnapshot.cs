﻿// <auto-generated />
using System;
using EmployeeAPI.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeAPI.Migrations
{
    [DbContext(typeof(CompanyContext))]
    partial class CompanyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeAPI.Models.Employee", b =>
                {
                    b.Property<long?>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("EmployeeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("EmployeeId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar (150)");

                    b.Property<string>("Areas")
                        .HasColumnType("nvarchar (100)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar (150)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar (150)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar (1000)");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar (100)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar (100)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime");

                    b.Property<string>("HomePhone")
                        .HasColumnType("nvarchar (50)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar (100)");

                    b.Property<string>("Notes")
                        .HasColumnType("ntext");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("image");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar (1000)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar (100)");

                    b.Property<decimal?>("Rate")
                        .HasColumnType("decimal");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar (150)");

                    b.Property<int?>("ReportsTo")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex(new[] { "LastName" }, "LastName");

                    b.HasIndex(new[] { "PostalCode" }, "PostalCodeEmployees");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeAPI.Models.Project", b =>
                {
                    b.Property<long>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ProjectId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ProjectId"), 1L, 1);

                    b.Property<decimal?>("Budjet")
                        .HasColumnType("DECIMAL");

                    b.Property<DateTime?>("DateOfAdoption")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Description")
                        .HasColumnType("VARCHAR (200)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("VARCHAR (20)");

                    b.HasKey("ProjectId");

                    b.HasIndex("ProjectId")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EmployeeAPI.Models.ProjectEmployeeJunction", b =>
                {
                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateJoined")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectEmployeeJunction");
                });

            modelBuilder.Entity("EmployeeAPI.Models.WorkTime", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Hours")
                        .HasColumnType("DECIMAL");

                    b.Property<decimal?>("LastRate")
                        .HasColumnType("DECIMAL");

                    b.Property<int?>("NumMonth")
                        .HasColumnType("int");

                    b.Property<int?>("NumYear")
                        .HasColumnType("int");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("WorkTimes");
                });

            modelBuilder.Entity("EmployeeAPI.Models.ProjectEmployeeJunction", b =>
                {
                    b.HasOne("EmployeeAPI.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeAPI.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeAPI.Models.WorkTime", b =>
                {
                    b.HasOne("EmployeeAPI.Models.Employee", null)
                        .WithMany("WorkTimes")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeAPI.Models.Employee", b =>
                {
                    b.Navigation("WorkTimes");
                });
#pragma warning restore 612, 618
        }
    }
}
