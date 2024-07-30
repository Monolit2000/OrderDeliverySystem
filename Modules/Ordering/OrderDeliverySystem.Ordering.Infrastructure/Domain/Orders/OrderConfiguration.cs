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

            //builder.OwnsMany(o => o.OrderItems, oi =>
            //{
            //    oi.HasKey(i => i.OrderItemId);

            //    oi.Property(e => e.Discount)
            //        .HasColumnType("decimal(18,2)");

            //    oi.Property(e => e.UnitPrice)
            //        .HasColumnType("decimal(18,2)");

            //    oi.OwnsOne(o => o.DeliveryOptions, b =>
            //    {
            //        b.Property(a => a.IsSelfPickup).HasColumnName("IsSelfPickup").IsRequired();
            //        b.Property(a => a.DeliveryMethod).HasColumnName("DeliveryMethod").IsRequired();
            //        b.Property(a => a.DeliveryCost).HasColumnName("DeliveryCost").HasColumnType("decimal(18,2)").IsRequired();
            //        b.Property(a => a.Deadline).HasColumnName("Deadline").IsRequired();
            //        b.Property(a => a.Address).HasColumnName("Address").IsRequired();
            //    });
            //});

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
        }
    }
}
