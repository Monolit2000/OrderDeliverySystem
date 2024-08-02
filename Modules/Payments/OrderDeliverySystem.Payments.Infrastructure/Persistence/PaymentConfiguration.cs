using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Payments.Domain.Payments;
using OrderDeliverySystem.Payments.Domain.Payers;

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

            //builder.OwnsOne(o => o.PayerId, b =>
            //{
            //    b.Property(a => a.Value).HasColumnName("PayerId").IsRequired();
            //});

              builder.Property(p => p.PayerId)
                   .HasConversion(
                       id => id.Value, // Convert PayerId to Guid for storage
                       value => new PayerId(value)) // Convert Guid from storage back to PayerId
                   .HasColumnName("PayerId")
                   .IsRequired();


            builder.OwnsOne(o => o.OrderId, b =>
            {
                b.Property(a => a.Value).HasColumnName("OrderId").IsRequired();
            });

            builder.OwnsOne(o => o.PaymentStatus, b =>
            {
                b.Property(a => a.Value).HasColumnName("PaymentStatus").IsRequired();
            });

            //// Настройка отношения один ко многим с Payer
            //builder.HasOne<Payer>()
            //       .WithMany() // Опционально укажите коллекцию навигации в Payer, если она есть
            //       .HasForeignKey(p => p.PayerId) // Ссылка на PayerId
            //       .OnDelete(DeleteBehavior.Restrict); // Установите поведение удаления (опционально)
        }
    }
}