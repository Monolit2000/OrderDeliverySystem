using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderDeliverySystem.CommonModule.Infrastructure.Domain;
using OrderDeliverySystem.Notifications.Application.Contract;
using OrderDeliverySystem.Notifications.Infrastructure.Application.Contract;
using OrderDeliverySystem.Notifications.Infrastructure.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Notifications.Infrastructure.Startup
{
    public static class NotificationsModuleStartup
    {
        public static IServiceCollection AddNotificationModule(
     this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionNew");

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(INotificationsModule).Assembly);
            });

            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            //services.AddDbContext<NotificationContext>((sp, options) =>
            //{
            //    options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            //    options.UseSqlServer(connectionString);
            //});
            services.AddScoped<INotificationsModule, NotificationsModule>();

            //services.AddScoped<INotificationsApi, NotificationsApi>();

            services.AddEventBusModule();
            return services;

        }

    }
}
