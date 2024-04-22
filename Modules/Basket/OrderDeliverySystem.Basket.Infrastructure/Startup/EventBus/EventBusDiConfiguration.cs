using Microsoft.Extensions.DependencyInjection;
using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Infrastructure.Startup.EventBus
{
    public static class EventBusDiConfiguration
    {
        public static IServiceCollection AddEventBusModule(
          this IServiceCollection services)
        {

            services.AddSingleton<InMemoryMessageQueue>();

            services.AddSingleton<IAsyncEventBus, AsyncEventBus>();

            return services;
        }
    }
}
