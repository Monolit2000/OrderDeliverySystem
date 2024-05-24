using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Infrastructure.Persistence
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {


            builder.HasKey(x => x.OrderId);


            builder.ComplexProperty(o => o.OrderStatus, b =>
            {
                b.IsRequired();
                b.Property(a => a.Value).HasColumnName("OrderStatus");
            });

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
                b.Property(a => a.IsSelfPickup).HasColumnName("IsSelfPickup");
                b.Property(a => a.DeliveryMethod).HasColumnName("DeliveryMethod");
                b.Property(a => a.DeliveryCost).HasColumnName("DeliveryCost");
                b.Property(a => a.DeliveryDateTime).HasColumnName("DeliveryDateTime");
                b.Property(a => a.Address).HasColumnName("Address");
            });

        }



    }

}
