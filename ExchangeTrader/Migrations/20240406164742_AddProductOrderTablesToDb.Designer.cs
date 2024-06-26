﻿// <auto-generated />
using System;
using DataModels.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExchangeTrader.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240406164742_AddProductOrderTablesToDb")]
    partial class AddProductOrderTablesToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataModels.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("accountID")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("broker")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("clientOrderId")
                        .HasColumnType("nvarchar(8)");

                    b.Property<long>("entryTime")
                        .HasColumnType("bigint");

                    b.Property<string>("orderStatus")
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("orderType")
                        .HasColumnType("nvarchar(10)");

                    b.Property<long>("price")
                        .HasColumnType("bigint");

                    b.Property<int>("productID")
                        .HasColumnType("int");

                    b.Property<long>("quantity")
                        .HasColumnType("bigint");

                    b.Property<string>("side")
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("symbol")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("timeInForce")
                        .HasColumnType("nvarchar(3)");

                    b.Property<long>("transactionTime")
                        .HasColumnType("bigint");

                    b.Property<long?>("userId")
                        .HasColumnType("bigint");

                    b.HasKey("OrderId");

                    b.HasIndex("productID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataModels.Models.Product", b =>
                {
                    b.Property<int>("productID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productID"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("field")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("lotSize")
                        .HasColumnType("int");

                    b.Property<string>("qouteCurrency")
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("settleCurrency")
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("tickSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("productID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataModels.Models.Order", b =>
                {
                    b.HasOne("DataModels.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataModels.Models.Product", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
