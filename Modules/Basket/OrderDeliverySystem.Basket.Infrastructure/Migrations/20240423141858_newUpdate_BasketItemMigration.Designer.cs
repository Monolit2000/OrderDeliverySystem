﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderDeliverySystem.Basket.Infrastructure.Persistence;

#nullable disable

namespace OrderDeliverySystem.Basket.Infrastructure.Migrations
{
    [DbContext(typeof(BasketContext))]
    [Migration("20240423141858_newUpdate_BasketItemMigration")]
    partial class newUpdate_BasketItemMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("basket")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderDeliverySystem.Basket.Domain.Baskets.BasketItem", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<Guid>("BasketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("OldUnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.HasIndex("BasketId");

                    b.HasIndex("ProductId");

                    b.ToTable("BasketItem", "basket");
                });

            modelBuilder.Entity("OrderDeliverySystem.Basket.Domain.Baskets.CustomerBasket", b =>
                {
                    b.Property<Guid>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("BuyerChatId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BasketId");

                    b.ToTable("Baskets", "basket");
                });

            modelBuilder.Entity("OrderDeliverySystem.Basket.Domain.Baskets.BasketItem", b =>
                {
                    b.HasOne("OrderDeliverySystem.Basket.Domain.Baskets.CustomerBasket", null)
                        .WithMany("Items")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderDeliverySystem.Basket.Domain.Baskets.CustomerBasket", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}