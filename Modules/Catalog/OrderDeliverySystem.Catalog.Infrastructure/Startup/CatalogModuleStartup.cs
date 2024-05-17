using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderDeliverySystem.Catalog.Application.Contract;
using OrderDeliverySystem.Catalog.Infrastructure.Persistence;
using OrderDeliverySystem.CommonModule.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using OrderDeliverySystem.Catalog.Infrastructure.Domain;
using OrderDeliverySystem.Catalog.Infrastructure.Startup.EventBus;

namespace OrderDeliverySystem.Catalog.Infrastructure.Startup
{
    public static class CatalogModuleStartup
    {

        public static IServiceCollection AddCatalogModule(
         this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnectionNew");

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ICatalogModule).Assembly);
            });


            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<CatalogContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddScoped<ICatalogModule, CatlogModule>();
            services.AddEventBusModule();
            return services;
        }

    }
}
