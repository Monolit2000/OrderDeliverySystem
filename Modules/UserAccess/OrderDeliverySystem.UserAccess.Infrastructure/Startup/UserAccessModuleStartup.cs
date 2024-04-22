using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderDeliverySystem.CommonModule.Infrastructure.Domain;
using OrderDeliverySystem.UserAccess.Application.Contracts;
using OrderDeliverySystem.UserAccess.Domain.Users;
using OrderDeliverySystem.UserAccess.Infrastructure.Domain.Users;
using OrderDeliverySystem.UserAccess.Infrastructure.Persistence;
using OrderDeliverySystem.UserAccess.Infrastructure.Startup.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Infrastructure.Startup
{
    public static class UserAccessModuleStartup
    {
        public static IServiceCollection AddUserAccessModule(
           this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(IUserAccessModule).Assembly /*Assembly.GetExecutingAssembly()*/);
            });

            //services.AddDbContext<UserAccessContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<UserAccessContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAccessModule, UserAccessModule>();
            services.AddEventBusModule();
            return services;
        }
    }
}
