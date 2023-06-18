﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebUj.Models;

#nullable disable

namespace WebUj.Migrations
{
    [DbContext(typeof(APIDbContext))]
    [Migration("20230615003746_Initial Create")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebUj.Models.Component", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("RequiredQuantity")
                        .HasColumnType("int");

                    b.Property<int>("StorageID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("WebUj.Models.ComponentsToProject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ComponentID")
                        .HasColumnType("int");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ComponentsToProjects");
                });

            modelBuilder.Entity("WebUj.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebUj.Models.Progress", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("Completed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Draft")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Failed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("InProgress")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("New")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Scheduled")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Wait")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Progresses");
                });

            modelBuilder.Entity("WebUj.Models.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.Property<int?>("ComponentsID")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int?>("FullPrice")
                        .HasColumnType("int");

                    b.Property<int>("ProgressID")
                        .HasColumnType("int");

                    b.Property<int?>("RequiredTime")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("WorkPrice")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Projets");
                });

            modelBuilder.Entity("WebUj.Models.Storage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Cell")
                        .HasColumnType("int");

                    b.Property<int>("Column")
                        .HasColumnType("int");

                    b.Property<int?>("MaxQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("Reserved")
                        .HasColumnType("int");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.Property<int>("Shelf")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Storages");
                });
#pragma warning restore 612, 618
        }
    }
}
