﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderDeliverySystem.Catalog.Infrastructure.Persistence;

#nullable disable

namespace OrderDeliverySystem.Catalog.Infrastructure.Migrations
{
    [DbContext(typeof(CatalogContext))]
    partial class CatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("TimeToItemExist")
                        .HasColumnType("datetime2");

                    b.HasKey("CatalogItemId");

                    b.ToTable("Catalog", "catalog");

                    b.HasData(
                        new
                        {
                            CatalogItemId = new Guid("e101f376-28f1-4e58-b368-4fbd4c1b6e7b"),
                            Description = "Classic cheese pizza with tomato and basil.",
                            Name = "Margherita Pizza",
                            PictureFileName = "margherita.jpg",
                            PictureUri = "/images/margherita.jpg",
                            Price = 9.99m,
                            ProductId = new Guid("e47c1bb5-c80f-4fdf-92c8-a09c526fe99d"),
                            TimeToItemExist = new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CatalogItemId = new Guid("ee72ad66-c9d0-4ebb-8c7f-11165ad72cae"),
                            Description = "Pizza with pepperoni slices.",
                            Name = "Pepperoni Pizza",
                            PictureFileName = "pepperoni.jpg",
                            PictureUri = "/images/pepperoni.jpg",
                            Price = 11.99m,
                            ProductId = new Guid("4d4db0d7-b712-4202-a7ee-43f1511de90b"),
                            TimeToItemExist = new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CatalogItemId = new Guid("81b82d30-b9ed-4224-a6e4-fe369b931251"),
                            Description = "Traditional Caesar salad with croutons and parmesan.",
                            Name = "Caesar Salad",
                            PictureFileName = "caesar.jpg",
                            PictureUri = "/images/caesar.jpg",
                            Price = 7.99m,
                            ProductId = new Guid("69f0f3e8-730d-486c-81af-ed2a28368d7e"),
                            TimeToItemExist = new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CatalogItemId = new Guid("36e6d8a3-2f29-4ce5-9e48-d54cae05b747"),
                            Description = "Spaghetti with a rich Bolognese sauce.",
                            Name = "Spaghetti Bolognese",
                            PictureFileName = "spaghetti.jpg",
                            PictureUri = "/images/spaghetti.jpg",
                            Price = 12.99m,
                            ProductId = new Guid("1f9c7fe7-af3a-4466-b0a7-815ceef1e97d"),
                            TimeToItemExist = new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CatalogItemId = new Guid("c6c5ecb9-e34b-421f-b08c-436d94708a1e"),
                            Description = "Chicken wings with spicy sauce.",
                            Name = "Chicken Wings",
                            PictureFileName = "wings.jpg",
                            PictureUri = "/images/wings.jpg",
                            Price = 8.99m,
                            ProductId = new Guid("a49c128d-5fb9-4c8a-adfb-aa95c1557a64"),
                            TimeToItemExist = new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CatalogItemId = new Guid("0a7e047f-647b-4f05-a94c-40da55b4332c"),
                            Description = "Classic cheeseburger with fries.",
                            Name = "Cheeseburger",
                            PictureFileName = "cheeseburger.jpg",
                            PictureUri = "/images/cheeseburger.jpg",
                            Price = 10.99m,
                            ProductId = new Guid("06c933f6-e18d-4ace-ab5b-df40ebd70323"),
                            TimeToItemExist = new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CatalogItemId = new Guid("03fbb2ac-1315-4ea0-ba8e-98b5feed36f1"),
                            Description = "Fried fish with chips.",
                            Name = "Fish and Chips",
                            PictureFileName = "fishchips.jpg",
                            PictureUri = "/images/fishchips.jpg",
                            Price = 13.99m,
                            ProductId = new Guid("a5a24f46-8752-4129-a5d6-8c539e5dc351"),
                            TimeToItemExist = new DateTime(2024, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CatalogItemId = new Guid("dc5586fc-7780-418a-bbb9-e0e815973f26"),
                            Description = "Traditional Italian dessert with mascarpone.",
                            Name = "Tiramisu",
                            PictureFileName = "tiramisu.jpg",
                            PictureUri = "/images/tiramisu.jpg",
                            Price = 6.99m,
                            ProductId = new Guid("97bf5035-765e-484a-a406-a49daa709a04"),
                            TimeToItemExist = new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CatalogItemId = new Guid("299cfa7b-fa60-46cf-b940-224238c5eee9"),
                            Description = "Chicken with creamy Alfredo sauce.",
                            Name = "Chicken Alfredo",
                            PictureFileName = "alfredo.jpg",
                            PictureUri = "/images/alfredo.jpg",
                            Price = 14.99m,
                            ProductId = new Guid("36b99a8d-7aa9-42b3-a13c-23218a226343"),
                            TimeToItemExist = new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CatalogItemId = new Guid("bf5407a7-e249-4714-a1aa-8815c24509a4"),
                            Description = "Classic Margarita cocktail.",
                            Name = "Margarita",
                            PictureFileName = "margarita.jpg",
                            PictureUri = "/images/margarita.jpg",
                            Price = 5.99m,
                            ProductId = new Guid("f3328699-95bf-4332-8ab4-174a3932baa7"),
                            TimeToItemExist = new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CatalogItemId = new Guid("6950fa3d-c5cb-4bc7-ad5f-f0302f5096e7"),
                            Description = "Refreshing Mojito with mint and lime.",
                            Name = "Mojito",
                            PictureFileName = "mojito.jpg",
                            PictureUri = "/images/mojito.jpg",
                            Price = 5.99m,
                            ProductId = new Guid("d9600883-6914-4cd8-b13d-f9484183563b"),
                            TimeToItemExist = new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CatalogItemId = new Guid("8f0b7e9d-bc5d-41a8-9ef2-9f2d45efbc9b"),
                            Description = "Tropical cocktail with pineapple and coconut.",
                            Name = "Pina Colada",
                            PictureFileName = "pinacolada.jpg",
                            PictureUri = "/images/pinacolada.jpg",
                            Price = 6.99m,
                            ProductId = new Guid("05aa92f5-30c8-4b1b-9d55-836b7f60571b"),
                            TimeToItemExist = new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CatalogItemId = new Guid("ec90d4c9-79f6-40e7-b65e-1234fc73cf91"),
                            Description = "Coffee with steamed milk.",
                            Name = "Cappuccino",
                            PictureFileName = "cappuccino.jpg",
                            PictureUri = "/images/cappuccino.jpg",
                            Price = 4.99m,
                            ProductId = new Guid("98e7ee5c-5641-4c8e-b480-7ad5e770a293"),
                            TimeToItemExist = new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CatalogItemId = new Guid("daaacbb7-2955-4407-a0a9-d71fcb5f66ee"),
                            Description = "Strong coffee shot.",
                            Name = "Espresso",
                            PictureFileName = "espresso.jpg",
                            PictureUri = "/images/espresso.jpg",
                            Price = 2.99m,
                            ProductId = new Guid("2a591b61-9a3b-4e48-82ee-383e6227ae1f"),
                            TimeToItemExist = new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("OrderDeliverySystem.Catalog.Domain.Catalog.CatalogType", b =>
                {
                    b.Property<Guid>("CatalogTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CatalogTypeId");

                    b.ToTable("CatalogTypes", "catalog");
                });

            modelBuilder.Entity("OrderDeliverySystem.Catalog.Domain.Catalog.Establishment", b =>
                {
                    b.Property<Guid>("EstablishmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstablishmentId");

                    b.ToTable("Establishments", "catalog");
                });
#pragma warning restore 612, 618
        }
    }
}
