using Microsoft.Extensions.Logging;
using OrderDeliverySystem.CommonModule.Infrastructure.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Serilog;

namespace OrderDeliverySystem.UserAccess.Infrastructure.Configuration.EventsBus
{
    public class EventsBusStartup 
    {
        public static void Initialize(
           Serilog.ILogger logger)
        {
            SubscribeToIntegrationEvents(logger);
        }

        private static void SubscribeToIntegrationEvents(Serilog.ILogger logger)
        {
            //var eventBus = UserAccessCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();

            //SubscribeToIntegrationEvent<BuyerCreatedIntegrationEvent>(eventBus, logger);
        }

        private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, Serilog.ILogger logger)
            where T : IntegrationEvent
        {
            logger.Information("Subscribe to {@IntegrationEvent}", typeof(T).FullName);
            eventBus.Subscribe(
                new IntegrationEventGenericHandler<T>());
        }
    }
}
