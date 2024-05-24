using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus
{
    public class AsyncEventBus : IAsyncEventBus
    {
        private InMemoryMessageQueue _inMemoryMessageQueue;
        private readonly ILogger<AsyncEventBus> _logger;
        public AsyncEventBus(
            InMemoryMessageQueue inMemoryMessageQueue,
            ILogger<AsyncEventBus> logger)
        {
            _inMemoryMessageQueue = inMemoryMessageQueue;
            _logger = logger;   
        }

        public async Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken)
            where T : class, IIntegrationEvent
        {
            //_logger.LogInformation("Publishing {Event}", integrationEvent.GetType().FullName);
            await _inMemoryMessageQueue.Write.WriteAsync(integrationEvent, cancellationToken);
        }
    }

  
}
