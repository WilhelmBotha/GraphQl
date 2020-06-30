﻿// <auto-generated />
using System;
using DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataContext.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200630132144_LastTimeUpAdded")]
    partial class LastTimeUpAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataContext.Models.Server", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HealthCheckUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HttpStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastTimeUp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Servers");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Body = "",
                            HealthCheckUri = "http://httpstat.us/200",
                            HttpStatus = "",
                            LastTimeUp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Check 1",
                            Status = ""
                        },
                        new
                        {
                            Id = "2",
                            Body = "",
                            HealthCheckUri = "http://httpstat.us/202",
                            HttpStatus = "",
                            LastTimeUp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Check 2",
                            Status = ""
                        },
                        new
                        {
                            Id = "3",
                            Body = "",
                            HealthCheckUri = "http://httpstat.us/400",
                            HttpStatus = "",
                            LastTimeUp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Check 3",
                            Status = ""
                        },
                        new
                        {
                            Id = "4",
                            Body = "",
                            HealthCheckUri = "http://httpstat.us/500",
                            HttpStatus = "",
                            LastTimeUp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Check 4",
                            Status = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}