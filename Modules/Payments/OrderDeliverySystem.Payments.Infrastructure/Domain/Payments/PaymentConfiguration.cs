using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Payments.Domain.Payments;
using OrderDeliverySystem.Payments.Domain.Payers;

namespace OrderDeliverySystem.Payments.Infrastructure.Domain.Payments
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasConversion(
                       id => id.Value, value => new PaymentId(value))
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
                     id => id.Value, value => new PayerId(value))
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



            //// Настройка отношения один ко многим с Payers
            //builder.HasOne<Payers>()
            //       .WithMany() // Опционально укажите коллекцию навигации в Payers, если она есть
            //       .HasForeignKey(p => p.PayerId) // Ссылка на PayerId
            //       .OnDelete(DeleteBehavior.Restrict); // Установите поведение удаления (опционально)
        }
    }
}