using MediatR;
using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate.DomainEvents;
using OrderDeliverySystem.Ordering.IntegrationEvents;


namespace OrderDeliverySystem.Ordering.Application.Orders.Events
{
    public class OrderPaidDomainEventHandler : INotificationHandler<OrderPaidDomainEvent>
    {
        private readonly IAsyncEventBus _eventBus;

        public OrderPaidDomainEventHandler(IAsyncEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(OrderPaidDomainEvent notification, CancellationToken cancellationToken)
        {
            await _eventBus.PublishAsync(new OrderPaidIntegretionEvent(notification.BuyerId, notification.OrderId));
        }
    }
}
