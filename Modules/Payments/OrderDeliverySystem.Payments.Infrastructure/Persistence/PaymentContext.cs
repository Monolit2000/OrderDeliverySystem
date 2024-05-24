using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Payments.Domain.PaymentAggregate;
using OrderDeliverySystem.Payments.Infrastructure.Startup;

namespace OrderDeliverySystem.Payments.Infrastructure.Persistence
{
    public class PaymentContext : DbContext 
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        { }

        public DbSet<Payment> Payments { get; set; }
  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("payments");

            modelBuilder.ApplyConfiguration(new PaymentConfiguration());

        }
    }
}
