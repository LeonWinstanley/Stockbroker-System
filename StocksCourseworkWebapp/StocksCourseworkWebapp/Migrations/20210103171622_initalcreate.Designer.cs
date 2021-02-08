﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StocksCourseworkWebapp.Contexts;

namespace StocksCourseworkWebapp.Migrations
{
    [DbContext(typeof(WebAppContext))]
    [Migration("20210103171622_initalcreate")]
    partial class initalcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("StocksCourseworkWebapp.Models.DatabaseObjects.AccountDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<bool>("loggedIn")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("AccountDetails");
                });
#pragma warning restore 612, 618
        }
    }
}