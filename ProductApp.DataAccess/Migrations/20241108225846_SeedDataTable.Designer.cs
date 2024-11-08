﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductApp.DataAccess;

#nullable disable

namespace ProductApp.DataAccess.Migrations
{
    [DbContext(typeof(ProductAppDbContext))]
    [Migration("20241108225846_SeedDataTable")]
    partial class SeedDataTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductApp.DataAccess.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "P001",
                            CreatedDate = new DateTime(2024, 11, 8, 22, 58, 45, 651, DateTimeKind.Utc).AddTicks(2395),
                            ImageUrl = "https://example.com/images/keyboard.png",
                            IsDeleted = false,
                            Price = 29.99m,
                            ProductName = "Kablosuz Klavye"
                        },
                        new
                        {
                            Id = 2,
                            Code = "P002",
                            CreatedDate = new DateTime(2024, 11, 8, 22, 58, 45, 651, DateTimeKind.Utc).AddTicks(2398),
                            ImageUrl = "https://example.com/images/mouse.png",
                            IsDeleted = false,
                            Price = 19.99m,
                            ProductName = "Bluetooth Mouse"
                        });
                });

            modelBuilder.Entity("ProductApp.DataAccess.SupportForm.ContactForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ContactForms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 11, 8, 22, 58, 45, 651, DateTimeKind.Utc).AddTicks(2354),
                            IsDeleted = false,
                            Message = "X ürünü mevcut mu?",
                            Status = "Beklemede",
                            Subject = "Ürün Sorgusu",
                            UpdatedDate = new DateTime(2024, 11, 8, 22, 58, 45, 651, DateTimeKind.Utc).AddTicks(2356),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 11, 3, 22, 58, 45, 651, DateTimeKind.Utc).AddTicks(2358),
                            IsDeleted = false,
                            Message = "1234 numaralı siparişin durumu?",
                            Status = "Çözüldü",
                            Subject = "Sipariş Durumu",
                            UpdatedDate = new DateTime(2024, 11, 8, 22, 58, 45, 651, DateTimeKind.Utc).AddTicks(2363),
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 11, 6, 22, 58, 45, 651, DateTimeKind.Utc).AddTicks(2365),
                            IsDeleted = false,
                            Message = "Ürün kurulumunda yardıma ihtiyacım var.",
                            Status = "Devam Ediyor",
                            Subject = "Teknik Destek",
                            UpdatedDate = new DateTime(2024, 11, 8, 22, 58, 45, 651, DateTimeKind.Utc).AddTicks(2366),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("ProductApp.DataAccess.Users.UserApp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Customer");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TokenCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Password = "Admin",
                            Role = "Admin",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "Admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}