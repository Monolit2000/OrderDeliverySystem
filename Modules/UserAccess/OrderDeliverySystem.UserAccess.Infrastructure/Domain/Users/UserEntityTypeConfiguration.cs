using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDeliverySystem.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Infrastructure.Domain.Users
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        //public void Configure(EntityTypeBuilder<User> builder)
        //{
        //    builder.ToTable("Users", "users");

        //    builder.HasKey(x => x.UserId);

        //    builder.Property<PhoneNumber>("PhoneNumber").HasColumnName("PhoneNumber");
        //    builder.Property<bool>("IsActive").HasColumnName("IsActive");
        //    builder.Property<string>("FirstName").HasColumnName("FirstName");
        //    builder.Property<string>("LastName").HasColumnName("LastName");
        //    builder.Property<string>("Name").HasColumnName("Name");

        //    builder.OwnsMany<UserRole>("Reoles", b =>
        //    {
        //        b.WithOwner().HasForeignKey("UserId");
        //        b.ToTable("UserRoles", "users");
        //        b.Property<Guid>("UserId");
        //        b.Property<string>("Value").HasColumnName("RoleCode");
        //        b.HasKey("UserId", "Value");
        //    });
        //}


        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "users");

            builder.HasKey(x => x.UserId);

            builder.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber");
            builder.Property(p => p.IsActivated).HasColumnName("IsActivated");
            builder.Property(p => p.FirstName).HasColumnName("FirstName");
            builder.Property(p => p.LastName).HasColumnName("LastName");
            builder.Property(p => p.Name).HasColumnName("Name");

            builder.HasMany(p => p.Roles)
                   .WithMany()
                   .UsingEntity(j => j.ToTable("UserRoles", "users"));
        }

    }
}
