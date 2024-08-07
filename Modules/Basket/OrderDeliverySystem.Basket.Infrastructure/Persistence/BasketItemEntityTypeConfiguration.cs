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
            builder.ToTable("BasketItem", "Basket");

            builder.HasKey(bi => bi.BasketItemId);

            builder.Property(bi => bi.BasketItemId).IsRequired().ValueGeneratedNever();

            builder.Property(bi => bi.ProductId).IsRequired();

            builder.Property(bi => bi.CustomerBasketId).IsRequired();

            builder.Property(bi => bi.ProductName).IsRequired().HasMaxLength(100);

            builder.Property(bi => bi.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(bi => bi.Quantity).IsRequired();

            builder.Property(bi => bi.IsDelivery).IsRequired();

            builder.Property(bi => bi.DeliveryDateTime).HasColumnName("DeliveryDateTime").IsRequired(); 

            builder.Property(bi => bi.Day).IsRequired();

            builder.Property(bi => bi.ProductImageUrl).IsRequired(false).HasMaxLength(200);

            builder.HasOne(bi => bi.CustomerBasket).WithMany(cb => cb.Items).HasForeignKey(bi => bi.CustomerBasketId).OnDelete(DeleteBehavior.Cascade);

            builder.ComplexProperty(x => x.OptionalItem, optionItem =>
            {
                optionItem.Property(o => o.IsAdded).HasColumnName("IsAdded");
                optionItem.Property(o => o.Name).HasColumnName("OptionItem_Name").IsRequired(false);
                optionItem.Property(o => o.Description).HasColumnName("OptionItem_Description").IsRequired(false);
                optionItem.Property(o => o.Price).HasColumnName("OptionItem_Price").HasColumnType("decimal(18,2)");
            });


        }
    }
}
