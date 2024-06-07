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

            builder.ToTable("Basket", "Basket");

            builder.HasKey(cb => cb.CustomerBasketId); 


            builder.HasKey(cb => cb.CustomerBasketId);

            builder.Property(cb => cb.CustomerBasketId)
                   .IsRequired()
                   .ValueGeneratedNever();

            builder.Property(cb => cb.BuyerId)
                   .IsRequired();


        }
    }
}
