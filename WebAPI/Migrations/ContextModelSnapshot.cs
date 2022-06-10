﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Models;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebAPI.Models.Solax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float?>("AcPower")
                        .HasColumnType("real");

                    b.Property<float?>("ConsumeEnergy")
                        .HasColumnType("real");

                    b.Property<float?>("FeedInEnergy")
                        .HasColumnType("real");

                    b.Property<float?>("FeedInPower")
                        .HasColumnType("real");

                    b.Property<string>("InverterSn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InverterStatus")
                        .HasColumnType("int");

                    b.Property<int?>("InverterType")
                        .HasColumnType("int");

                    b.Property<float?>("PowerDc1")
                        .HasColumnType("real");

                    b.Property<float?>("PowerDc2")
                        .HasColumnType("real");

                    b.Property<DateTime?>("UploadTime")
                        .HasColumnType("datetime2");

                    b.Property<float?>("YieldToday")
                        .HasColumnType("real");

                    b.Property<float?>("YieldTotal")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Solax");
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}