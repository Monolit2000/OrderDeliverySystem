﻿using Microsoft.EntityFrameworkCore;
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

            builder.ToTable("Basket", "Basket");

            // Установка ключа
            builder.HasKey(cb => cb.CustomerBasketId); // Assuming `Id` is inherited from `Entity`




            builder.HasKey(cb => cb.CustomerBasketId);

            builder.Property(cb => cb.CustomerBasketId)
                   .IsRequired()
                   .ValueGeneratedNever();

            builder.Property(cb => cb.BuyerId)
                   .IsRequired();

            //builder.HasMany(cb => cb.Items)
            //       .WithOne()
            //       .HasForeignKey(bi => bi.CustomerBasketId);





            //builder.Property(p => p.BuyerId).HasColumnName("BuyerId").IsRequired(); 
           // builder.Property(p => p.BuyerChatId).HasColumnName("BuyerChatId");
  
            
            //// Указание свойства для BuyerId
            //builder.Property(cb => cb.BuyerId)
            //       .IsRequired(); // Показывает, что это обязательное поле


            //builder.Property(c => c.BuyerChatId);



           



            // Конфигурация связи один-ко-многим
            //builder.HasMany(cb => cb.Items)
            //       .WithOne()
            //       .HasForeignKey("CustomerBasketId") // Создание внешнего ключа в BasketItem
            //       .OnDelete(DeleteBehavior.Cascade); // Опция каскадного удаления
        }
    }
}
