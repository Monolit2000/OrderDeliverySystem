using MediatR;
using OrderDeliverySystem.Basket.Application.Basket.CleanBasket;
using OrderDeliverySystem.Ordering.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.IntegrationEventHandlers
{
    public class OrderPaidIntegretionEventHandler : INotificationHandler<OrderPaidIntegretionEvent>
    {
        private readonly IMediator _mediator;

        public OrderPaidIntegretionEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(OrderPaidIntegretionEvent notification, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CleanBasketCommand 
            {
                BuyerId = notification.BuyerId 
            });
        }
    }
}
