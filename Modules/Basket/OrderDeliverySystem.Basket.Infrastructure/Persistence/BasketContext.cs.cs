using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Basket.Domain.Baskets;
using OrderDeliverySystem.Basket.Infrastructure.Domain.Baskets;


namespace OrderDeliverySystem.Basket.Infrastructure.Persistence
{
    public class BasketContext : DbContext
    {
        public BasketContext(DbContextOptions<BasketContext> options)
           : base(options)
        {

        }
        public DbSet<CustomerBasket> Baskets { get; set; }

        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("basket");

           // base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BasketItemEntityTypeConfiguration());

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(BasketEntityTypeConfiguration).Assembly);


            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //base.OnModelCreating(modelBuilder);
        }

    }
}
