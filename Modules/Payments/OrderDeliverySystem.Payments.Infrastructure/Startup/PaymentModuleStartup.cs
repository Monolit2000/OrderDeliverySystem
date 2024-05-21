using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderDeliverySystem.CommonModule.Infrastructure.Domain;
using OrderDeliverySystem.Payments.Application.Contract;
using OrderDeliverySystem.Payments.Infrastructure.Contract;
using OrderDeliverySystem.Payments.Infrastructure.EventBus;
using OrderDeliverySystem.Payments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Payments.Domain.PaymentAggregate;
using OrderDeliverySystem.Payments.Infrastructure.Domain;

namespace OrderDeliverySystem.Payments.Infrastructure.Startup
{
    public static class PaymentModuleStartup
    {
        public static IServiceCollection AddPaymentModule(
      this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionNew");

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(IPaymentModule).Assembly);
            });


            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<PaymentContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IPaymentRepository, PaymentRepository>();
           

            services.AddScoped<IPaymentModule, PaymentModule>();
            services.AddEventBusModule();
            return services;

        }
    }
}
