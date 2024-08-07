using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Infrastructure.Persistence
{
    public class CatalogItemConfiguration : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("Catalog", "catalog");

            builder.HasKey(x => x.CatalogItemId);

            builder.Property(p => p.ProductId).HasColumnName("ProductId");
            builder.Property(p => p.Price).HasColumnName("Price");
            builder.Property(p => p.PictureFileName).HasColumnName("PictureFileName");
            builder.Property(p => p.PictureUri).HasColumnName("PictureUri");
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
            builder.Property(p => p.Description).HasColumnName("Description");
            builder.Property(p => p.TimeToItemExist).HasColumnName("TimeToItemExist");

            builder.ComplexProperty(x => x.OptionItem, optionItem =>
            {
                optionItem.Property(o => o.Name).HasColumnName("OptionItem_Name").IsRequired(false);
                optionItem.Property(o => o.Description).HasColumnName("OptionItem_Description").IsRequired(false); 
                optionItem.Property(o => o.Price).HasColumnName("OptionItem_Price").HasColumnType("decimal(18,2)"); 
            });

        }
    }


    public class OptionItemConfiguration : IEntityTypeConfiguration<OptionItemDr>
    {
        public void Configure(EntityTypeBuilder<OptionItemDr> builder)
        {
            builder.ToTable("OptionItemDr", "catalog");

            builder.HasKey(x => x.OptionItemId);

            builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
            builder.Property(p => p.Description).HasColumnName("Description").IsRequired();
            builder.Property(p => p.Price).HasColumnName("Price");
            builder.Property(p => p.PictureUri).HasColumnName("PictureUri");


            //// Configure one-to-one relationship with OptionItemDr
            //builder.HasOne(p => p.OptionItemDr)
            //       .WithOne()
            //       .HasForeignKey<CatalogItem>(p => p.CatalogItemId);
        }
    }
}