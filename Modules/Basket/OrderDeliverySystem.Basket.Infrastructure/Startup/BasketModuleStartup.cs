using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderDeliverySystem.Basket.Application.Contracts;
using OrderDeliverySystem.Basket.Infrastructure.Persistence;
using OrderDeliverySystem.CommonModule.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Basket.Domain.Baskets;
using OrderDeliverySystem.Basket.Infrastructure.Domain.Baskets;
using OrderDeliverySystem.Basket.Infrastructure.Startup.EventBus;
using OrderDeliverySystem.CommonModule.Infrastructure.Domain;

namespace OrderDeliverySystem.Basket.Infrastructure.Startup
{
    public static class BasketModuleStartup
    {
        public static IServiceCollection AddBasketModule(
          this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(IBasketModule).Assembly);
            });

            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<BasketContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

                options.UseSqlServer(connectionString);
            });


            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBasketModule, BasketModule>();
            services.AddEventBusModule();
            return services;
        }
    }
}
