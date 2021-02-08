﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StocksCourseworkAPI.Contexts;

namespace StocksCourseworkAPI.Migrations.Stock
{
    [DbContext(typeof(StockContext))]
    [Migration("20210117160924_addExtraColumnsToSymbolTable")]
    partial class addExtraColumnsToSymbolTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("SharedClasses.StocksCandleClass", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Close")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("High")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Low")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Open")
                        .HasColumnType("TEXT");

                    b.Property<string>("Symbol")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<long>("Volume")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("CandleData");
                });

            modelBuilder.Entity("SharedClasses.StocksSharedClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("AvailableShares")
                        .HasColumnType("REAL");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanySymbol")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("StockPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StocksData");
                });

            modelBuilder.Entity("SharedClasses.StocksSymbolsClass", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Figi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mic")
                        .HasColumnType("TEXT");

                    b.Property<string>("Symbol")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("SymbolData");
                });
#pragma warning restore 612, 618
        }
    }
}
