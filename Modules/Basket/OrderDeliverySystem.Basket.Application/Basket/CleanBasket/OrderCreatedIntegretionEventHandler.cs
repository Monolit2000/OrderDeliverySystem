using MediatR;
using OrderDeliverySystem.Ordering.IntegrationEvents;

namespace OrderDeliverySystem.Basket.Application.Basket.CleanBasket
{
    public class OrderCreatedIntegretionEventHandler(
        IMediator mediator) : INotificationHandler<OrderCreatedIntegrationEvent>
    {
        public async Task Handle(OrderCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await mediator.Send(new CleanBasketCommand
            {
                BuyerId = notification.BuyerId
            });
        }
    }
}
