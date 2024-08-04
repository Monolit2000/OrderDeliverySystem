using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using OrderDeliverySystem.Ordering.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Infrastructure.Domain.Orders
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasConversion(
                       id => id.Value, // Convert OrderId to Guid for storage
                       value => new OrderId(value)) // Convert Guid from storage back to OrderId
                   .HasColumnName("Id")
                   .IsRequired();

            builder.Property(o => o.OrderNumber)
                  .ValueGeneratedOnAdd();

            builder.ComplexProperty(o => o.OrderStatus, b =>
            {
                b.IsRequired();
                b.Property(a => a.Value).HasColumnName("OrderStatus");
            });

            // Configuring the relationship between Order and Buyer
            builder.HasOne(o => o.Buyer)
                   .WithMany()
                   .HasForeignKey(o => o.BuyerId)
                   .OnDelete(DeleteBehavior.Restrict); // Adjust this based on your needs

            builder.HasMany(o => o.OrderItems)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }

    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {

            builder.HasKey(x => x.OrderItemId);


            builder.Property(e => e.Discount)
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18,2)");

            builder.ComplexProperty(o => o.DeliveryOptions, b =>
            {
                b.IsRequired();
                b.Property(a => a.IsSelfPickup).HasColumnName("IsSelfPickup");
                b.Property(a => a.DeliveryMethod).HasColumnName("DeliveryMethod");
                b.Property(a => a.DeliveryCost).HasColumnName("DeliveryCost");
                b.Property(a => a.DeliveryDateTime).HasColumnName("DeliveryDateTime");
                b.Property(a => a.Address).HasColumnName("Address");
            });

            builder.ComplexProperty(o => o.Status, b =>
            {
                b.IsRequired();
                b.Property(a => a.Value).HasColumnName("Status");
            });

            builder.HasMany<OrderItemStatusChange>()
                .WithOne()
                .HasForeignKey(oisc => oisc.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }



namespace OrderDeliverySystem.Ordering.Infrastructure.Domain.Orders
    {
        public class OrderItemStatusChangeConfiguration : IEntityTypeConfiguration<OrderItemStatusChange>
        {
            public void Configure(EntityTypeBuilder<OrderItemStatusChange> builder)
            {
                builder.HasKey(oisc => oisc.Id);

                builder.Property(p => p.Id)
                   .HasConversion(
                       id => id.Value, // Convert OrderId to Guid for storage
                       value => new OrderItemStatusChangeId(value)) // Convert Guid from storage back to OrderId
                   .HasColumnName("Id")
                   .IsRequired();

                builder.Property(oisc => oisc.ItemId)
                    .IsRequired();

                builder.ComplexProperty(oisc => oisc.Status, b =>
                {
                    b.IsRequired();
                    b.Property(a => a.Value).HasColumnName("Status");
                });

                builder.Property(oisc => oisc.ChangedDate)
                    .IsRequired();
            }
        }
    }
}
