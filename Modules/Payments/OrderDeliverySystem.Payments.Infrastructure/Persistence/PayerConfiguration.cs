using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDeliverySystem.Payments.Domain.Payers;

namespace OrderDeliverySystem.Payments.Infrastructure.Persistence
{
    public class PayerConfiguration : IEntityTypeConfiguration<Payer>
    {
        public void Configure(EntityTypeBuilder<Payer> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasConversion(
                       id => id.Value, // Convert PayerId to underlying type (assumed to be Guid here)
                       value => new PayerId(value)) // Convert underlying type back to PayerId
                   .HasColumnName("Id")
                   .IsRequired();

            builder.Property(p => p.Name)
                   .HasMaxLength(100) // Set the maximum length as needed
                   .IsRequired();

            builder.Property(p => p.Email)
                   .HasMaxLength(255); // Set the maximum length as needed

            builder.Property(p => p.PhoneNumber)
                   .HasMaxLength(20) // Set the maximum length as needed
                   .IsRequired();

            // Настройка навигационного свойства, если оно есть
            // builder.HasMany(p => p.Payments) // Если у вас есть коллекция Payments в Payer
            //        .WithOne() // Настройка связи с Payment
            //        .HasForeignKey(p => p.PayerId);
        }
    }
}