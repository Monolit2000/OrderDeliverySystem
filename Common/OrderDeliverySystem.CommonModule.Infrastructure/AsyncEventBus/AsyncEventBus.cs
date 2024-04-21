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

        public AsyncEventBus(InMemoryMessageQueue inMemoryMessageQueue)
        {
            _inMemoryMessageQueue = inMemoryMessageQueue;
        }

        public async Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken)
            where T : class, IIntegrationEvent
        {
            await _inMemoryMessageQueue.Write.WriteAsync(integrationEvent, cancellationToken);
        }
    }

  
}
