﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderDeliverySystem.Ordering.Infrastructure.Persistence;

#nullable disable

namespace OrderDeliverySystem.Ordering.Infrastructure.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20240524093114_newBuyerOrderProperty")]
    partial class newBuyerOrderProperty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ordering")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderDeliverySystem.Ordering.Domain.BuyerAggregate.Buyer", b =>
                {
                    b.Property<Guid>("BuyerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("BuyerChatId")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuyerId");

                    b.ToTable("Buyers", "ordering");
                });

            modelBuilder.Entity("OrderDeliverySystem.Ordering.Domain.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.ComplexProperty<Dictionary<string, object>>("OrderStatus", "OrderDeliverySystem.Ordering.Domain.OrderAggregate.Order.OrderStatus#OrderStatus", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("OrderStatus");
                        });

                    b.HasKey("OrderId");

                    b.HasIndex("BuyerId");

                    b.ToTable("Orders", "ordering");
                });

            modelBuilder.Entity("OrderDeliverySystem.Ordering.Domain.OrderAggregate.OrderItem", b =>
                {
                    b.Property<Guid>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Units")
                        .HasColumnType("int");

                    b.ComplexProperty<Dictionary<string, object>>("DeliveryOptions", "OrderDeliverySystem.Ordering.Domain.OrderAggregate.OrderItem.DeliveryOptions#DeliveryOptions", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Address");

                            b1.Property<decimal>("DeliveryCost")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("DeliveryCost");

                            b1.Property<DateTime>("DeliveryDateTime")
                                .HasColumnType("datetime2")
                                .HasColumnName("DeliveryDateTime");

                            b1.Property<string>("DeliveryMethod")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("DeliveryMethod");

                            b1.Property<bool>("IsSelfPickup")
                                .HasColumnType("bit")
                                .HasColumnName("IsSelfPickup");
                        });

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems", "ordering");
                });

            modelBuilder.Entity("OrderDeliverySystem.Ordering.Domain.OrderAggregate.Order", b =>
                {
                    b.HasOne("OrderDeliverySystem.Ordering.Domain.BuyerAggregate.Buyer", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");
                });

            modelBuilder.Entity("OrderDeliverySystem.Ordering.Domain.OrderAggregate.OrderItem", b =>
                {
                    b.HasOne("OrderDeliverySystem.Ordering.Domain.OrderAggregate.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("OrderDeliverySystem.Ordering.Domain.OrderAggregate.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
