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
    [Migration("20240423195802_new_TestMigration__DatabaseTesBasket")]
    partial class new_TestMigration__DatabaseTesBasket
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

            modelBuilder.Entity("OrderDeliverySystem.Basket.Domain.Baskets.CustomerBasket", b =>
                {
                    b.Property<Guid>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("BuyerChatId")
                        .HasColumnType("bigint")
                        .HasColumnName("BuyerChatId");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BuyerId");

                    b.HasKey("BasketId");

                    b.ToTable("Basket", "Basket");
                });
#pragma warning restore 612, 618
        }
    }
}
