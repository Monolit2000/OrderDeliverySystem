using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDeliverySystem.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Infrastructure.Persistence
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "users");

            builder.HasKey(x => x.UserId);

            builder.Property(p => p.IsActivated).HasColumnName("IsActivated");
            builder.Property(p => p.ChatId).HasColumnName("ChatId");
            builder.Property(p => p.FirstName).HasColumnName("FirstName");
            builder.Property(p => p.LastName).HasColumnName("LastName");
            builder.Property(p => p.Name).HasColumnName("Name");



            builder.ComplexProperty(c => c.PhoneNumber, b =>
            {
                b.IsRequired();
                b.Property(p => p.Number).HasColumnName("PhoneNumber");
            });


            builder.ComplexProperty(c => c.Role, b =>
            {
                b.IsRequired();
                b.Property(p => p.Value).HasColumnName("Role");
            });
        }

    }
}

