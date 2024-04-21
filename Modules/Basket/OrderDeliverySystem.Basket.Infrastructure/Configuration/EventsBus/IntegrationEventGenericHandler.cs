using OrderDeliverySystem.CommonModule.Infrastructure.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Infrastructure.Configuration.EventsBus
{
    internal class IntegrationEventGenericHandler<T> : IIntegrationEventHandler<T>
         where T : IntegrationEvent
    {
        public async Task Handle(T @event)
        {
            using (var scope = BasketCompositionRoot.BeginLifetimeScope())
            {
                await Console.Out.WriteLineAsync("IntegrationEventGenericHandler");
            }
        }
    }
}
