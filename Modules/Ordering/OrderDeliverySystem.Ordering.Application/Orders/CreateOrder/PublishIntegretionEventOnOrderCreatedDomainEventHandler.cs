using MediatR;
using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using OrderDeliverySystem.CommonModule.Infrastructure.EventBus;
using OrderDeliverySystem.Ordering.Domain.Orders.Events;
using OrderDeliverySystem.Ordering.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.CreateOrder
{
    public class PublishIntegretionEventOnOrderCreatedDomainEventHandler(
        IAsyncEventBus eventBus) : INotificationHandler<OrderCreatedDomainEvent>
    {
        public async Task Handle(OrderCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await eventBus.PublishAsync(new OrderCreatedIntegrationEvent(
                notification.BuyerId, 
                notification.OrderId.Value));
        }
    }
}
