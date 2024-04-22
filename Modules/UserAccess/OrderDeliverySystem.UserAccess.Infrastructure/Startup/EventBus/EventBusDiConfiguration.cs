using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using OrderDeliverySystem.UserAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Infrastructure.Startup.EventBus
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
