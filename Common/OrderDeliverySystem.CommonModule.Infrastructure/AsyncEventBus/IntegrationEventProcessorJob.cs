using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;

namespace OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus
{
    public class IntegrationEventProcessorJob : BackgroundService
    {
        private IPublisher _publisher;
        private InMemoryMessageQueue _inMemoryMessageQueue;

        public IntegrationEventProcessorJob(IPublisher publisher, InMemoryMessageQueue inMemoryMessageQueue)
        {
            _publisher = publisher;
            _inMemoryMessageQueue = inMemoryMessageQueue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            await foreach(IIntegrationEvent @event in _inMemoryMessageQueue.Reder.ReadAllAsync(stoppingToken))
            {
                await _publisher.Publish(@event, stoppingToken);
            }
        }
    }
}
