using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDeliverySystem.Basket.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Infrastructure.Persistence
{
    internal class BasketEntityTypeConfiguration : IEntityTypeConfiguration<CustomerBasket>
    {
        public void Configure(EntityTypeBuilder<CustomerBasket> builder)
        {
            // Установка ключа
            builder.HasKey(cb => cb.BasketId); // Assuming `Id` is inherited from `Entity`

            // Указание свойства для BuyerId
            builder.Property(cb => cb.BuyerId)
                   .IsRequired(); // Показывает, что это обязательное поле

            // Конфигурация связи один-ко-многим
            //builder.HasMany(cb => cb.Items)
            //       .WithOne()
            //       .HasForeignKey("BasketId") // Создание внешнего ключа в BasketItem
            //       .OnDelete(DeleteBehavior.Cascade); // Опция каскадного удаления
        }
    }
}
