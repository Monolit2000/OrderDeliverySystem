﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Basket.Domain.Baskets;
using OrderDeliverySystem.Basket.Infrastructure.Domain.Baskets;

namespace OrderDeliverySystem.Basket.Infrastructure.Persistence
{
    public class BasketContext : DbContext
    {

        public DbSet<CustomerBasket> Baskets { get; set; }

        public BasketContext(DbContextOptions options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("basket");

          // modelBuilder.ApplyConfiguration(new BasketEntityTypeConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

    }
}
