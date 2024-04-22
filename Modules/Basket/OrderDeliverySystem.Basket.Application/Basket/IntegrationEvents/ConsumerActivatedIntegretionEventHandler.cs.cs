using MediatR;
using OrderDeliverySystem.CommonModule.Infrastructure.EventBus;
using OrderDeliverySystem.UserAccess.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.IntegrationEvents
{
    public class ConsumerActivatedIntegretionEventHandler : INotificationHandler<ConsumerActivatedIntegretionEvent>
    {
        public async Task Handle(ConsumerActivatedIntegretionEvent notification, CancellationToken cancellationToken)
        {
            await Console.Out.WriteLineAsync("ConsumerActivatedIntegretionEventHandler Basket");
        }
    }
}
