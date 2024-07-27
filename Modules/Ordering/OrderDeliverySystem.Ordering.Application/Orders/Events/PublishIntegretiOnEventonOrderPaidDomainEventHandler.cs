using MediatR;
using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using OrderDeliverySystem.Ordering.Domain.Orders.Events;
using OrderDeliverySystem.Ordering.IntegrationEvents;


namespace OrderDeliverySystem.Ordering.Application.Orders.Events
{
    public class PublishIntegretiOnEventonOrderPaidDomainEventHandler : INotificationHandler<OrderPaidDomainEvent>
    {
        private readonly IAsyncEventBus _eventBus;

        public PublishIntegretiOnEventonOrderPaidDomainEventHandler(IAsyncEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(OrderPaidDomainEvent notification, CancellationToken cancellationToken)
        {
            await _eventBus.PublishAsync(new OrderPaidIntegretionEvent(notification.BuyerId, notification.OrderId.Value));
        }
    }
}
