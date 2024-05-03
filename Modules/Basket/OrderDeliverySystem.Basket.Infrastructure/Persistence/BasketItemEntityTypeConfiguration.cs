using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Basket.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Infrastructure.Persistence
{
    internal class BasketItemEntityTypeConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            // Установка ключа
          //  builder.HasKey(bi => bi.ProductId); // Поскольку продукт может быть идентифицирован по ProductId

            // Конфигурация необходимых полей
            builder.Property(bi => bi.ProductName);

            builder.Property(bi => bi.UnitPrice);// Настройка точности для decimal

            // Если необходимы индексы или уникальность
            //builder.HasIndex(bi => bi.ProductId); // Индекс для ускорения поиска
        }
    }
}
