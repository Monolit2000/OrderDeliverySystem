using Autofac;
using Microsoft.Extensions.Hosting;
using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Infrastructure.Configuration.EventsBus
{
    internal class EventsBusModule : Module
    {
        private readonly IAsyncEventBus _eventsBus;

        public EventsBusModule(IAsyncEventBus eventsBus)
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

                //builder.RegisterType<IntegrationEventProcessorJob>()
                //    .As<IHostedService>()
                //    .InstancePerLifetimeScope();

                //builder.RegisterType<IntegrationEventProcessorJob>()
                //.As<IHostedService>()  // Сначала указываем, что это хост-сервис
                //.SingleInstance();


                //builder.Services.AddScoped<IHostedService, IntegrationEventProcessorJob>();
            }
        }
    }
}
