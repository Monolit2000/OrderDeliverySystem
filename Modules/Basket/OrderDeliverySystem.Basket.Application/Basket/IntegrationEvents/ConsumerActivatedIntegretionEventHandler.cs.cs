using MediatR;
using OrderDeliverySystem.Basket.Application.Basket.CreateBasket;
using OrderDeliverySystem.UserAccess.IntegrationEvents;

namespace OrderDeliverySystem.Basket.Application.Basket.IntegrationEvents
{
    public class ConsumerActivatedIntegretionEventHandler : INotificationHandler<ConsumerActivatedIntegretionEvent>
    {
        private readonly IMediator _mediator;

        public ConsumerActivatedIntegretionEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Handle(ConsumerActivatedIntegretionEvent notification, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CreateBasketCommand(
                notification.UserId,
                notification.ChatId));
        }
    }
}
