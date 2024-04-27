using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;

namespace OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus
{
    public class IntegrationEventProcessorJob : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private InMemoryMessageQueue _inMemoryMessageQueue;

        public IntegrationEventProcessorJob(IServiceProvider serviceProvider, InMemoryMessageQueue inMemoryMessageQueue)
        {
            _serviceProvider = serviceProvider; 
            _inMemoryMessageQueue = inMemoryMessageQueue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {           
            using var scope = _serviceProvider.CreateScope();

            var mediatr = GetMediatorServices(scope);

            await Console.Out.WriteLineAsync("ExecuteAsync Start IntegrationEventProcessorJob");

            await foreach (IIntegrationEvent @event in _inMemoryMessageQueue.Reder.ReadAllAsync(stoppingToken))
            {
                await mediatr.Publish(@event, stoppingToken);
            }           
        }


        private IMediator GetMediatorServices(IServiceScope scope)
        {
            var mediator = scope.ServiceProvider.GetService<IMediator>();
            if (mediator == null)
                throw new ArgumentNullException(nameof(IMediator), "Cant resolve IMediator from service provider");

            return mediator;
        }

    }
}
