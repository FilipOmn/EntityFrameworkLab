﻿// <auto-generated />
using System;
using EntityFrameworkLabb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkLabb.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220407121906_A")]
    partial class A
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFrameworkLabb.Models.Employe", b =>
                {
                    b.Property<int>("EmployeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EntityFrameworkLabb.Models.LeaveApplication", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ApplicationId");

                    b.HasIndex("EmployeId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("EntityFrameworkLabb.Models.LeaveApplication", b =>
                {
                    b.HasOne("EntityFrameworkLabb.Models.Employe", "Employe")
                        .WithMany()
                        .HasForeignKey("EmployeId");
                });
#pragma warning restore 612, 618
        }
    }
}
