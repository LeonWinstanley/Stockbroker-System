﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StocksCourseworkWebapp.Contexts;

namespace StocksCourseworkWebapp.Migrations
{
    [DbContext(typeof(WebAppContext))]
    [Migration("20210122190416_addedDefaultCurrencySelector")]
    partial class addedDefaultCurrencySelector
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("StocksCourseworkWebapp.Models.DatabaseObjects.AccountDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("AccountBalance")
                        .HasColumnType("REAL");

                    b.Property<double>("AccountBalanceAvailable")
                        .HasColumnType("REAL");

                    b.Property<string>("DefaultCurrency")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AccountDetails");
                });

            modelBuilder.Entity("StocksCourseworkWebapp.Models.DatabaseObjects.UserHoldings", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("TEXT");

                    b.Property<double>("PriceBought")
                        .HasColumnType("REAL");

                    b.Property<double>("PriceSold")
                        .HasColumnType("REAL");

                    b.Property<string>("Symbol")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("TimeBought")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<double>("amount")
                        .HasColumnType("REAL");

                    b.HasKey("id");

                    b.ToTable("UserHoldings");
                });
#pragma warning restore 612, 618
        }
    }
}