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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("basket");

            modelBuilder.ApplyConfiguration(new BasketEntityTypeConfiguration());

           // modelBuilder.ApplyConfiguration(new BasketItemEntityTypeConfiguration());
            

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //base.OnModelCreating(modelBuilder);
        }

    }
}
