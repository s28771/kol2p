﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Data;

#nullable disable

namespace WebApplication2.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Car", b =>
                {
                    b.Property<int>("IdCar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCar"));

                    b.Property<int>("IdColor")
                        .HasColumnType("int");

                    b.Property<int>("IdModel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PricePerDay")
                        .HasColumnType("int");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.HasKey("IdCar");

                    b.HasIndex("IdColor");

                    b.HasIndex("IdModel");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            IdCar = 1,
                            IdColor = 1,
                            IdModel = 1,
                            Name = "bbbb",
                            PricePerDay = 150,
                            Seats = 5,
                            VIN = "bbbb"
                        },
                        new
                        {
                            IdCar = 2,
                            IdColor = 1,
                            IdModel = 2,
                            Name = "bvbvb",
                            PricePerDay = 34,
                            Seats = 3,
                            VIN = "bvbvbv"
                        });
                });

            modelBuilder.Entity("Car_Rental", b =>
                {
                    b.Property<int>("IdCar_Rental")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCar_Rental"));

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("Disscount")
                        .HasColumnType("int");

                    b.Property<int>("IdCar")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("IdCar_Rental");

                    b.HasIndex("IdCar");

                    b.HasIndex("IdClient");

                    b.ToTable("CarRentals");

                    b.HasData(
                        new
                        {
                            IdCar_Rental = 1,
                            DateFrom = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Disscount = 15,
                            IdCar = 1,
                            IdClient = 1,
                            TotalPrice = 1000
                        },
                        new
                        {
                            IdCar_Rental = 2,
                            DateFrom = new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Disscount = 0,
                            IdCar = 2,
                            IdClient = 2,
                            TotalPrice = 420
                        });
                });

            modelBuilder.Entity("Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdClient");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            IdClient = 1,
                            Adress = "nnn",
                            FirstName = "nnn",
                            LastName = "nnn"
                        },
                        new
                        {
                            IdClient = 2,
                            Adress = "kkkk",
                            FirstName = "kkk",
                            LastName = "kkk"
                        });
                });

            modelBuilder.Entity("Color", b =>
                {
                    b.Property<int>("IdColor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdColor"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdColor");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            IdColor = 1,
                            Name = "zolty"
                        },
                        new
                        {
                            IdColor = 2,
                            Name = "pomarancz"
                        });
                });

            modelBuilder.Entity("WebApplication2.Models.Model", b =>
                {
                    b.Property<int>("IdModel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdModel"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdModel");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            IdModel = 1,
                            Name = "xxxx"
                        },
                        new
                        {
                            IdModel = 2,
                            Name = "ccc"
                        });
                });

            modelBuilder.Entity("Car", b =>
                {
                    b.HasOne("Color", "Color")
                        .WithMany("Cars")
                        .HasForeignKey("IdColor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Models.Model", "Model")
                        .WithMany("Cars")
                        .HasForeignKey("IdModel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Car_Rental", b =>
                {
                    b.HasOne("Car", "Car")
                        .WithMany("CarRentals")
                        .HasForeignKey("IdCar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Client", "Client")
                        .WithMany("CarRentals")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Car", b =>
                {
                    b.Navigation("CarRentals");
                });

            modelBuilder.Entity("Client", b =>
                {
                    b.Navigation("CarRentals");
                });

            modelBuilder.Entity("Color", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("WebApplication2.Models.Model", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}