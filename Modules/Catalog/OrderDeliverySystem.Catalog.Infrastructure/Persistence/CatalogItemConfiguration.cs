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
            //builder.Property(p => p.Establishment).HasColumnName("Establishment");
     



        }
    }
}