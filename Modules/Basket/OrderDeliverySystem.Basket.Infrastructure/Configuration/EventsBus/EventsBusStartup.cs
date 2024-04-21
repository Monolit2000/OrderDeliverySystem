using Autofac;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.Json;
using OrderDeliverySystem.Basket.Application.IntegrationEventsHandler;
using OrderDeliverySystem.CommonModule.Infrastructure.EventBus;
using OrderDeliverySystem.UserAccess.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Infrastructure.Configuration.EventsBus
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
            var eventBus = BasketCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();


        }

        private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, Serilog.ILogger logger)
            where T : IntegrationEvent
        {
            logger.Information("Subscribe to {@IntegrationEvent}", typeof(T).FullName);

            eventBus.Subscribe( new IntegrationEventGenericHandler<T>());
        }

        private static void SubscribeToIntegrationEventHandler<T>( IIntegrationEventHandler<T> integrationEventHandler,  IEventsBus eventBus, Serilog.ILogger logger)
          where T : IntegrationEvent
        {
            logger.Information("Subscribe to {@IntegrationEvent}", typeof(T).FullName);

            eventBus.Subscribe<T>(integrationEventHandler);


           // eventBus.Subscribe(new IntegrationEventGenericHandler<T>());
        }
    }
}
