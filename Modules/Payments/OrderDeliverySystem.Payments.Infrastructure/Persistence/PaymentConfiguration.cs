﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystem.Payments.Domain.PaymentAggregate;

namespace OrderDeliverySystem.Payments.Infrastructure.Persistence
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.PaymentId );

            builder.Property(p => p.Amount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.OwnsOne(o => o.PaymentStatus, b =>
            {
                b.Property(a => a.Value).HasColumnName("PaymentStatus").IsRequired();
            });
        }
    }

}
