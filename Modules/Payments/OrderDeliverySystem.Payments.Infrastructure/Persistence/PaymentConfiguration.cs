using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Payments.Domain.Payments;

namespace OrderDeliverySystem.Payments.Infrastructure.Persistence
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasConversion(
                       id => id.Value, // Convert PaymentId to Guid for storage
                       value => new PaymentId(value)) // Convert Guid from storage back to PaymentId
                   .HasColumnName("Id")
                   .IsRequired();

            builder.Property(p => p.Amount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.OwnsOne(o => o.PayerId, b =>
            {
                b.Property(a => a.Value).HasColumnName("PayerId").IsRequired();
            });

            builder.OwnsOne(o => o.OrderId, b =>
            {
                b.Property(a => a.Value).HasColumnName("OrderId").IsRequired();
            });

            builder.OwnsOne(o => o.PaymentStatus, b =>
            {
                b.Property(a => a.Value).HasColumnName("PaymentStatus").IsRequired();
            });
        }
    }
}
