﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderDeliverySystem.Catalog.Infrastructure.Persistence;

#nullable disable

namespace OrderDeliverySystem.Catalog.Infrastructure.Migrations
{
    [DbContext(typeof(CatalogContext))]
    [Migration("20240423225419_newCatalogMigration")]
    partial class newCatalogMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("catalog")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderDeliverySystem.Catalog.Domain.Catalog.CatalogItem", b =>
                {
                    b.Property<Guid>("CatalogItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CatalogTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PictureFileName");

                    b.Property<string>("PictureUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PictureUri");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Price");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductId");

                    b.HasKey("CatalogItemId");

                    b.HasIndex("CatalogTypeId");

                    b.ToTable("Catalog", "catalog");
                });

            modelBuilder.Entity("OrderDeliverySystem.Catalog.Domain.Catalog.CatalogType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CatalogTypes", "catalog");
                });

            modelBuilder.Entity("OrderDeliverySystem.Catalog.Domain.Catalog.Establishment", b =>
                {
                    b.Property<Guid>("EstablishmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CatalogItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstablishmentId");

                    b.HasIndex("CatalogItemId")
                        .IsUnique();

                    b.ToTable("Establishments", "catalog");
                });

            modelBuilder.Entity("OrderDeliverySystem.Catalog.Domain.Catalog.CatalogItem", b =>
                {
                    b.HasOne("OrderDeliverySystem.Catalog.Domain.Catalog.CatalogType", "CatalogType")
                        .WithMany()
                        .HasForeignKey("CatalogTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogType");
                });

            modelBuilder.Entity("OrderDeliverySystem.Catalog.Domain.Catalog.Establishment", b =>
                {
                    b.HasOne("OrderDeliverySystem.Catalog.Domain.Catalog.CatalogItem", null)
                        .WithOne("Establishment")
                        .HasForeignKey("OrderDeliverySystem.Catalog.Domain.Catalog.Establishment", "CatalogItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderDeliverySystem.Catalog.Domain.Catalog.CatalogItem", b =>
                {
                    b.Navigation("Establishment")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
