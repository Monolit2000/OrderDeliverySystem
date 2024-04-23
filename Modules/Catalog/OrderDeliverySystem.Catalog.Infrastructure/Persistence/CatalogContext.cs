using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Infrastructure.Persistence
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        { }

        public DbSet<CatalogItem> Baskets { get; set; }

        public DbSet<CatalogType> CatalogTypes { get; set; }

        public DbSet<Establishment> Establishments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("catalog");

            modelBuilder.ApplyConfiguration(new CatalogItemConfiguration());
        }
    }
}
