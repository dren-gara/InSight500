﻿// <auto-generated />
using System;
using InSight500.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InSight500.API.Migrations
{
    [DbContext(typeof(InSight500DbContext))]
    partial class InSight500DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InSight500.API.Data.IncomeStatement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FiscalDateEnding")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("GrossProfit")
                        .HasColumnType("numeric");

                    b.Property<decimal>("NetIncome")
                        .HasColumnType("numeric");

                    b.Property<decimal>("OperatingIncome")
                        .HasColumnType("numeric");

                    b.Property<string>("ReportedCurrency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalRevenue")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("IncomeStatements");
                });
#pragma warning restore 612, 618
        }
    }
}
