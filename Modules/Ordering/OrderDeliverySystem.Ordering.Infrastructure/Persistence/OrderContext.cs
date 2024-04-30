using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Ordering.Domain.BuyerAggregate;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Infrastructure.Persistence
{
    public class OrderContext : DbContext
    {

        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        { }


        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Buyer> Buyers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ordering");
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
