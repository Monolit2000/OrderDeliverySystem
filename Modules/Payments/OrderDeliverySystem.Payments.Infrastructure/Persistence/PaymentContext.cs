using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Payments.Infrastructure.Startup;

namespace OrderDeliverySystem.Payments.Infrastructure.Persistence
{
    public class PaymentContext : DbContext 
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        }
    }
}
