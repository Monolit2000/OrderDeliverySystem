using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using OrderDeliverySystem.Catalog.Domain.Establishments;


namespace OrderDeliverySystem.Catalog.Infrastructure.Persistence
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        { }

        public DbSet<CatalogItem> CatalogItems { get; set; }

        //public DbSet<OptionItemDr> OptionItems { get; set; }

        public DbSet<CatalogType> CatalogTypes { get; set; }

        public DbSet<Establishment> Establishments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("catalog");

            //modelBuilder.Entity<CatalogItem>().HasKey(k => k.CatalogItemId);

            modelBuilder.Entity<CatalogType>().HasKey(k => k.CatalogTypeId);

            modelBuilder.Entity<Establishment>().HasKey(e => e.EstablishmentId);

            //CatalogItemSeeder.Seed(modelBuilder);

            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CatalogItemConfiguration());

            //modelBuilder.ApplyConfiguration(new OptionItemConfiguration());

        }
    }
}
