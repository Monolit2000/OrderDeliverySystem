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
    [Migration("20240504221455_newBAsskdfksgjsdfdfg")]
    partial class newBAsskdfksgjsdfdfg
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
                    b.Property<Guid>("BasketItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BasketItemId");

                    b.ToTable("BasketItems", "basket");
                });

            modelBuilder.Entity("OrderDeliverySystem.Basket.Domain.Baskets.CustomerBasket", b =>
                {
                    b.Property<Guid>("CustomerBasketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("BuyerChatId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomerBasketId");

                    b.ToTable("Basket", "Basket");
                });
#pragma warning restore 612, 618
        }
    }
}
