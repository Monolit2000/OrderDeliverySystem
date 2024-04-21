using Autofac;
using Microsoft.Extensions.Hosting;
using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using OrderDeliverySystem.CommonModule.Infrastructure.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Infrastructure.Configuration.EventsBus
{
    internal class EventsBusModule : Module
    {
        private readonly IEventsBus _eventsBus;

        public EventsBusModule(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus;
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_eventsBus != null)
            {
                builder.RegisterInstance(_eventsBus).SingleInstance();
            }
            else
            {

                builder.RegisterType<InMemoryMessageQueue>()
                    .SingleInstance();

                builder.RegisterType<AsyncEventBus>()
                    .As<IAsyncEventBus>()
                    .SingleInstance();

                builder.RegisterType<IntegrationEventProcessorJob>()
                    .As<IHostedService>()
                    .InstancePerLifetimeScope();
            }
        }
    }
}
