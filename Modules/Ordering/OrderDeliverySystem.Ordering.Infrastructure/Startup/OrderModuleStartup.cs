using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderDeliverySystem.CommonModule.Infrastructure.Domain;
using OrderDeliverySystem.Ordering.Application.Contract;
using OrderDeliverySystem.Ordering.Domain.BuyerAggregate;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using OrderDeliverySystem.Ordering.Infrastructure.Domain;
using OrderDeliverySystem.Ordering.Infrastructure.Persistence;
using OrderDeliverySystem.Ordering.Infrastructure.Startup.EventBus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Infrastructure.Startup
{
    public static class OrderModuleStartup
    {
        public static IServiceCollection AddOrderModule(
       this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(IOrderingModule).Assembly);
            });


            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<OrderContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IBuyerRepository, BuyerRepository>();

            services.AddScoped<IOrderingModule, OrderingModule>();
            services.AddEventBusModule();
            return services;

        }
    }
}
