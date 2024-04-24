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

        public DbSet<CatalogItem> CatalogItems { get; set; }

        public DbSet<CatalogType> CatalogTypes { get; set; }

        public DbSet<Establishment> Establishments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("catalog");

            //modelBuilder.Entity<CatalogItem>().HasKey(k => k.CatalogItemId);

            modelBuilder.Entity<CatalogType>().HasKey(k => k.CatalogTypeId);

            modelBuilder.Entity<Establishment>().HasKey(e => e.EstablishmentId);

            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CatalogItemConfiguration());
        }
    }
}
