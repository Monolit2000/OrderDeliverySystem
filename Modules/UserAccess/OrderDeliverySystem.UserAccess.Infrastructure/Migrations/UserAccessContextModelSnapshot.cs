﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderDeliverySystem.UserAccess.Infrastructure.Persistence;

#nullable disable

namespace OrderDeliverySystem.UserAccess.Infrastructure.Migrations
{
    [DbContext(typeof(UserAccessContext))]
    partial class UserAccessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("userAccess")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderDeliverySystem.UserAccess.Domain.Users.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WorkAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("WorkAddress");

                    b.Property<long>("ChatId")
                        .HasColumnType("bigint")
                        .HasColumnName("ChatId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit")
                        .HasColumnName("IsActivated");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.ComplexProperty<Dictionary<string, object>>("PhoneNumber", "OrderDeliverySystem.UserAccess.Domain.Users.User.PhoneNumber#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PhoneNumber");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Role", "OrderDeliverySystem.UserAccess.Domain.Users.User.Role#UserRole", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Role");
                        });

                    b.HasKey("UserId");

                    b.ToTable("Users", "users");
                });
#pragma warning restore 612, 618
        }
    }
}
